package main

import (
	"context"
	"flag"
	"fmt"
	"os"
	"sync"

	"github.com/aws/aws-sdk-go-v2/service/sqs"
	"github.com/joho/godotenv"
	log "github.com/sirupsen/logrus"
	"github.com/snapdocs/the-acme-lender/pkg/aws"
	"github.com/snapdocs/the-acme-lender/pkg/snapdocs"
	"github.com/tidwall/gjson"
)

//ScanbackDocumentsCreated handle the document.created event
func ScanbackDocumentsCreated(closingUUID string, documentUUID string) error {
	err := aws.SecretToEnvVariables(fmt.Sprintf("%s/example-snapdocs-event-listener/oauth", os.Getenv("ENV")))
	if err != nil {
		log.Error("Failed to load AWS secret", err)
		return err
	}
	client := snapdocs.NewSnapdocsApiClient(os.Getenv("SNAPDOCS_API_URL"))

	return client.DownloadDocument(closingUUID, documentUUID)
}

//eventAlreaydProcessed check whether the event id has been already processed
func eventAlreaydProcessed(eventId string) bool {
	//check whether the event id has been processed to prevent duplicate events
	return false
}

//ProcessSnapdocsEvent process any Snapdocs event
func ProcessSnapdocsEvent(body string) error {

	bodyJson := gjson.Parse(body)
	bodyJson.Get("event_id")
	eventId := bodyJson.Get("event_id").String()
	if eventAlreaydProcessed(eventId) {
		//skip
		log.Warnf("event %v has already been seen before", eventId)
		return nil
	}
	eventName := bodyJson.Get("event_name").String()

	if eventName == "document.created" {
		documentType := bodyJson.Get("document_type").String()
		if documentType == "scanback_documents" {
			err := ScanbackDocumentsCreated(bodyJson.Get("closing_uuid").String(), bodyJson.Get("document_uuid").String())
			if err != nil {
				log.Error("ScanbackDocumentsCreated failed", err)
				return fmt.Errorf("failed to process event %s %v", body, err)
			}
		}
	}
	return nil
}

var listenerNumnber int

func init() {
	flag.IntVar(&listenerNumnber, "n", 10, "the number of event worker")
}

func main() {

	//load env
	err := godotenv.Load()
	if err != nil {
		log.Fatal("Error loading .env file", err)
	}
	ctx, cancel := context.WithCancel(context.Background())
	defer cancel()

	wg := &sync.WaitGroup{}
	wg.Add(listenerNumnber)
	var queueName = os.Getenv("QUEUE_NAME")
	sqsClient, err := aws.GetSqsClient()
	if err != nil {
		log.Fatal(err)
	}
	log.Infoln("created sqs client")
	for i := 1; i <= listenerNumnber; i++ {
		log.Infof("staring worker %d", i)
		go startWorker(ctx, wg, i, sqsClient, queueName)
	}
	wg.Wait()
}

//startWorker start a SQS consumer to listen to SQS queue and process the event
func startWorker(ctx context.Context, wg *sync.WaitGroup, id int, client *sqs.Client, queueName string) error {
	defer wg.Done()

	for {
		select {
		case <-ctx.Done():
			log.Infof("worker %d is done\n", id)
			return nil
		default:
		}

		output, err := client.ReceiveMessage(ctx, &sqs.ReceiveMessageInput{
			QueueUrl: &queueName,
		})
		if err != nil {
			log.Errorf("worker %d failed to receive message from SQS %v ", id, err)
		}
		for _, message := range output.Messages {
			err := ProcessSnapdocsEvent(*message.Body)
			if err != nil {
				log.Error(err)
			}
			//delete the message from the queue regardless the result of operation
			_, err = client.DeleteMessage(ctx, &sqs.DeleteMessageInput{
				QueueUrl:      &queueName,
				ReceiptHandle: message.ReceiptHandle,
			})
			if err != nil {
				log.Error("failed to delete the message after processing", err)
			}
		}

	}
}
