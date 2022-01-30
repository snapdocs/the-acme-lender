package main

import (
	"context"
	"encoding/json"
	"fmt"
	"os"

	"github.com/aws/aws-lambda-go/lambda"
	log "github.com/sirupsen/logrus"
	"github.com/snapdocs/the-acme-lender/pkg/aws"
	"github.com/snapdocs/the-acme-lender/pkg/snapdocs"
	"github.com/tidwall/gjson"
)

type LambdaResponse struct {
	StatusCode int    `json:"statusCode"`
	Body       string `json:"body"`
}

type Response struct {
	Status  string `json:"status"`
	Code    int    `json:"code"`
	Message string `json:"message"`
}

func Success() LambdaResponse {

	res := Response{
		Status:  "OK",
		Code:    200,
		Message: "Sccessfully received the webhook message",
	}
	resBody, _ := json.Marshal(res)
	return LambdaResponse{
		StatusCode: 200,
		Body:       string(resBody),
	}
}

func FailureMessage(code int, message string) LambdaResponse {
	res := Response{
		Status:  "Failure",
		Code:    code,
		Message: message,
	}
	resBody, _ := json.Marshal(res)
	return LambdaResponse{
		StatusCode: code,
		Body:       string(resBody),
	}

}

func ScanbackDocumentsCreated(closingUUID string, documentUUID string) error {
	err := aws.SecretToEnvVariables(fmt.Sprintf("%s/example-snapdocs-event-listener/oauth", os.Getenv("ENV")))
	if err != nil {
		log.Error("Failed to load AWS secret", err)
		return err
	}
	client := snapdocs.NewSnapdocsApiClient(os.Getenv("SNAPDOCS_API_URL"))

	return client.DownloadDocument(closingUUID, documentUUID)
}

func eventAlreaydProcessed(eventId string) bool {
	//check whether the event id has been processed to prevent duplicate events
	return false
}

func ProcessSnapdocsEvent(body string) LambdaResponse {
	level, _ := log.ParseLevel(os.Getenv("LOG_LEVEL"))
	log.SetLevel(level)

	bodyJson := gjson.Parse(body)
	bodyJson.Get("event_id")
	eventId := bodyJson.Get("event_id").String()
	eventName := bodyJson.Get("event_name").String()
	if eventAlreaydProcessed(eventId) {
		//skip. TODO need better repsonse
		return Success()
	}
	if eventName == "document.created" {
		documentType := bodyJson.Get("document_type").String()
		if documentType == "scanback_documents" {
			err := ScanbackDocumentsCreated(bodyJson.Get("closing_uuid").String(), bodyJson.Get("document_uuid").String())
			if err != nil {
				log.Error("ScanbackDocumentsCreated failed", err)
				return FailureMessage(500, fmt.Sprintf("failed to process %s %s %v", eventName, documentType, err))
			}
		}
	}
	return Success()
}

func Handler(ctx context.Context, event json.RawMessage) (LambdaResponse, error) {
	eventBody := gjson.Get(string(event), "body")
	res := ProcessSnapdocsEvent(eventBody.String())
	// with AWS API Gateway and Lambda proxy, we should put the "error" in the response statusCode, than raising error from Lambda integration.
	// If we raise error here, all we get is 502 error, which is not desired.
	return res, nil
}

func main() {

	lambda.Start(Handler)
}
