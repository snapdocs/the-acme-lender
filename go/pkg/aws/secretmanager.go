package aws

//load the AWS secret and put in the environment varibles
import (
	"context"
	"encoding/base64"
	"encoding/json"
	"fmt"
	"os"

	"github.com/aws/aws-sdk-go-v2/aws"
	"github.com/aws/aws-sdk-go-v2/config"
	"github.com/aws/aws-sdk-go-v2/service/secretsmanager"
	log "github.com/sirupsen/logrus"
)

type SecretData map[string]interface{}

//GetSecret get the secret from AWS secret manager. It uses the default AWS config.
func GetSecret(secretName string) (SecretData, error) {
	var secretData SecretData = make(SecretData)
	cfg, err := config.LoadDefaultConfig(context.TODO())
	if err != nil {
		log.Error("failed to set up aws, wrong config? ", err)
		return nil, err
	}
	log.Debugf("region %s", cfg.Region)
	client := secretsmanager.NewFromConfig(cfg)
	input := &secretsmanager.GetSecretValueInput{
		SecretId:     aws.String(secretName),
		VersionStage: aws.String("AWSCURRENT"), // VersionStage defaults to AWSCURRENT if unspecified
	}

	result, err := client.GetSecretValue(context.TODO(), input)
	if err != nil {
		log.Error("failed to get secret ", err)
		return nil, err
	}

	// Decrypts secret using the associated KMS key.
	// Depending on whether the secret is a string or binary, one of these fields will be populated.
	if result.SecretString != nil {
		secretString := *result.SecretString
		err := json.Unmarshal([]byte(secretString), &secretData)
		if err != nil {
			log.Error("secret string is not json? ", err)
			return nil, err
		}
	} else {
		decodedBinarySecretBytes := make([]byte, base64.StdEncoding.DecodedLen(len(result.SecretBinary)))
		len, err := base64.StdEncoding.Decode(decodedBinarySecretBytes, result.SecretBinary)
		if err != nil {
			log.Error("Base64 Decode Error:", err)
			return nil, err
		}
		json.Unmarshal(decodedBinarySecretBytes[:len], &secretData)
		//decodedBinarySecret = string(decodedBinarySecretBytes[:len])

	}
	return secretData, nil
}

//SecretToEnvVariables load the AWS secret, then set to environment variables.
func SecretToEnvVariables(secretName string) error {
	secretData, err := GetSecret(secretName)
	if err != nil {
		return err
	}
	//iterate the map
	for key, value := range secretData {
		os.Setenv(key, fmt.Sprintf("%v", value))
	}
	return nil
}
