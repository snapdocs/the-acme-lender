package aws

import (
	"context"
	"fmt"

	"github.com/aws/aws-sdk-go-v2/aws"
	"github.com/aws/aws-sdk-go-v2/config"
	"github.com/aws/aws-sdk-go-v2/service/sqs"
	log "github.com/sirupsen/logrus"
)

//GetSqsClient return a client for AWS SQS with the default config
func GetSqsClient() (*sqs.Client, error) {
	cfg, err := config.LoadDefaultConfig(context.TODO())
	if err != nil {
		log.Error("failed to set up aws, wrong config? ", err)
		return nil, err
	}
	return sqs.NewFromConfig(cfg), nil

}

//SendMessage sends a message to a SQS queue (FIFO queue), the msgGrpId only applies to FIFO queue to group messages to guarantee the order
func SendMessage(message string, msgGrpId string, queueName string) error {

	client, err := GetSqsClient()
	if err != nil {
		return fmt.Errorf("failed to get sqs client, wrong config? %v", err)

	}
	// Get URL of queue
	gQInput := &sqs.GetQueueUrlInput{
		QueueName: &queueName,
	}

	result, err := client.GetQueueUrl(context.TODO(), gQInput)
	if err != nil {
		log.Error("Got an error getting the queue URL:", err)
		return err
	}

	queueURL := result.QueueUrl
	smInput := &sqs.SendMessageInput{
		MessageBody:    aws.String(message),
		QueueUrl:       queueURL,
		MessageGroupId: &msgGrpId, //The message group ID is the tag that specifies that a message belongs to a specific message group. Messages that belong to the same message group are always processed one by one, in a strict order relative to the message group (however, messages that belong to different message groups might be processed out of order
	}
	output, err := client.SendMessage(context.TODO(), smInput)
	if err != nil {
		return fmt.Errorf("failed to send message %v", err)
	}
	log.Debugf("message sent. id %d", output.MessageId)
	return nil
}
