package snapdocs

import (
	"context"
	"fmt"
	"io/ioutil"
	"net/http"
	"os"
	"strings"

	log "github.com/sirupsen/logrus"
	"golang.org/x/oauth2/clientcredentials"
)

//the API client of Snapdocs API
type SnapdocsApiClient struct {
	HttpClient *http.Client
	ApiUrl     string
}

//newOAuthConfig create the oauth "client-credential" config with the client id, secret from enrionment variables
func newOAuthConfig() *clientcredentials.Config {
	return &clientcredentials.Config{
		ClientID:     os.Getenv("SNAPDOCS_API_CLIENT_ID"),
		ClientSecret: os.Getenv("SNAPDOCS_API_CLIENT_SECRET"),
		Scopes:       strings.Split(os.Getenv("SNAPDOCS_API_SCOPE"), " "),
		TokenURL:     os.Getenv("SNAPDOCS_TOKEN_URL"),
	}
}

//newHttpClient create a OAuth http client which can refresh the token when necessary
func newHttpClient() *http.Client {

	cfg := newOAuthConfig()
	return cfg.Client(context.Background())

}

//NewSnapdocsApiClient returns the client for Snapdocs API, that can be used to call the Snapdocs endpoints.
func NewSnapdocsApiClient(apiUrl string) *SnapdocsApiClient {
	return &SnapdocsApiClient{
		ApiUrl:     apiUrl,
		HttpClient: newHttpClient(),
	}
}

//GetSubscriptions make request to the /subscriptions endpoint
func (p *SnapdocsApiClient) GetSubscriptions() (string, error) {
	url := p.ApiUrl + "/subscriptions"
	resp, err := p.HttpClient.Get(url)
	if err != nil {
		log.Error("Failed to query", err)
		return "", err
	}
	err = RaiseForStatus(resp)
	if err != nil {
		return "", err
	}
	defer resp.Body.Close()
	body, err := ioutil.ReadAll(resp.Body)
	if err != nil {
		log.Error("Failed to parse response", err)
		return "", err
	}

	return string(body), nil
}

//DownloadDocument make request to the /closing/{closing_uuid}/documents/{document_uuid} endpoint
func (p *SnapdocsApiClient) DownloadDocument(closingUUID string, documentUUID string) error {

	url := fmt.Sprintf("%s/closings/%s/documents/%s", p.ApiUrl, closingUUID, documentUUID)
	request, err := http.NewRequest("GET", url, nil)
	if err != nil {
		log.Error("Failed to create the request", err)
		return err
	}
	request.Header.Set("Accept", "application/pdf")
	resp, err := p.HttpClient.Do(request)

	if err != nil {
		log.Errorf("Failed to fetch from %v %v ", url, err)
		return err
	}
	err = RaiseForStatus(resp)
	if err != nil {
		return err
	}

	return nil
}

//RaiseForStatus check the response status code, raise error if it is not 2xx
func RaiseForStatus(resp *http.Response) error {
	code := resp.StatusCode
	statusOk := code >= 200 && code < 300
	if !statusOk {
		body, err := ioutil.ReadAll(resp.Body)
		if err != nil {
			log.Error("Failed to parse response", err)
		}
		return fmt.Errorf("http response code %d %s", code, string(body))
	}
	return nil
}
