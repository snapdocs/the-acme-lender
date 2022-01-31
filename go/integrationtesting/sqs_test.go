package integrationtesting

import (
	"testing"

	"github.com/snapdocs/the-acme-lender/pkg/aws"
)

func TestSendMessage(t *testing.T) {
	setup()
	type args struct {
		message   string
		queueName string
	}
	tests := []struct {
		name    string
		args    args
		wantErr bool
	}{
		// TODO: Add test cases.
		{
			name: "test aws sqs send message",
			args: args{
				message:   "simple tesing",
				queueName: "dev-example-snapdocs-listener-go.fifo",
			},
			wantErr: false,
		},
	}
	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			if err := aws.SendMessage(tt.args.message, "testing", tt.args.queueName); (err != nil) != tt.wantErr {
				t.Errorf("SendMessage() error = %v, wantErr %v", err, tt.wantErr)
			}
		})
	}
}
