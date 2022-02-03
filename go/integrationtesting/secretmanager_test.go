package integrationtesting

import (
	"testing"

	"github.com/snapdocs/the-acme-lender/pkg/aws"
)

func TestGetSecret(t *testing.T) {
	setup()
	type args struct {
		secretName string
	}
	tests := []struct {
		name    string
		args    args
		want    aws.SecretData
		wantErr bool
	}{
		// TODO: Add test cases.
		{
			name: "test aws secret manager get",
			args: args{
				secretName: "dev/example-snapdocs-event-listener/oauth",
			},
			want:    nil,
			wantErr: false,
		},
	}
	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			_, err := aws.GetSecret(tt.args.secretName)
			if (err != nil) != tt.wantErr {
				t.Errorf("GetSecret() error = %v, wantErr %v", err, tt.wantErr)
				return
			}
			//if !reflect.DeepEqual(got, tt.want) {
			//	t.Errorf("GetSecret() = %v, want %v", got, tt.want)
			//}
		})
	}
}
