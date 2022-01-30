package integrationtesting

import (
	"net/http"
	"os"
	"testing"

	log "github.com/sirupsen/logrus"

	"github.com/joho/godotenv"
	"github.com/snapdocs/the-acme-lender/pkg/snapdocs"
)

func setup() {
	err := godotenv.Load()
	if err != nil {
		log.Fatal("Error loading .env file")
	}
	level, _ := log.ParseLevel(os.Getenv("LOG_LEVEL"))
	log.SetLevel(level)
}

func TestSnapdocsApiClient_GetSubscriptions(t *testing.T) {

	setup()
	type fields struct {
		HttpClient *http.Client
		ApiUrl     string
	}
	tests := []struct {
		name    string
		fields  fields
		want    string
		wantErr bool
	}{
		{
			name: "get subs",
			fields: fields{
				ApiUrl: os.Getenv("SNAPDOCS_API_URL"),
			},
			want:    "",
			wantErr: false,
		},
	}
	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			p := snapdocs.NewSnapdocsApiClient(tt.fields.ApiUrl)
			_, err := p.GetSubscriptions()
			if (err != nil) != tt.wantErr {
				t.Errorf("SnapdocsApiClient.GetSubscriptions() error = %v, wantErr %v", err, tt.wantErr)
				return
			}
			//fmt.Print(got)
			//if got != tt.want {
			//	t.Errorf("SnapdocsApiClient.GetSubscriptions() = %v, want %v", got, tt.want)
			//}
		})
	}
}

func TestSnapdocsApiClient_DownloadDocument(t *testing.T) {
	setup()
	type fields struct {
		HttpClient *http.Client
		ApiUrl     string
	}
	type args struct {
		closingUUID  string
		documentUUID string
	}
	tests := []struct {
		name    string
		fields  fields
		args    args
		wantErr bool
	}{
		{
			name: "download doc",
			fields: fields{
				ApiUrl: os.Getenv("SNAPDOCS_API_URL"),
			},
			args: args{
				closingUUID:  "123456",
				documentUUID: "abcde",
			},
			wantErr: false,
		},
	}
	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			p := snapdocs.NewSnapdocsApiClient(tt.fields.ApiUrl)
			if err := p.DownloadDocument(tt.args.closingUUID, tt.args.documentUUID); (err != nil) != tt.wantErr {
				t.Errorf("SnapdocsApiClient.DownloadDocument() error = %v, wantErr %v", err, tt.wantErr)
			}
		})
	}
}
