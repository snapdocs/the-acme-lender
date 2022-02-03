package main

import (
	"context"
	"encoding/json"
	"fmt"
	"os"

	"github.com/aws/aws-lambda-go/lambda"
	log "github.com/sirupsen/logrus"
	"github.com/snapdocs/the-acme-lender/pkg/aws"
	"github.com/tidwall/gjson"
)

//LambaResponse specifies the data structure of Lambda output to API gateway.
type LambdaResponse struct {
	StatusCode int    `json:"statusCode"`
	Body       string `json:"body"`
}

type Response struct {
	Status  string `json:"status"`
	Code    int    `json:"code"`
	Message string `json:"message"`
}

//Success() create the message for API gateway with code 200
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

//FailureMessage create a message for API gateway with non-2xx code
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

//sendToQueue send message to SQS queue, whose name is set by the environment variable
func sendToQueue(body string, queueName string) error {
	//message group id for FIFO queue.
	msgGrpId := queueName
	return aws.SendMessage(body, msgGrpId, queueName)

}

//validate function has basic validation of the http request body
func validate(event string) error {
	// basic validation to check whether the required fields.
	return nil
}

//Handler is the Lambda handler, it does (very) basic validation, then pass the event to SQS queue to be processed.
func Handler(ctx context.Context, event json.RawMessage) (LambdaResponse, error) {
	eventBody := gjson.Get(string(event), "body")
	err := validate(eventBody.String())
	// with AWS API Gateway and Lambda proxy, we should put the "error" in the response statusCode, than raising error from Lambda integration.
	// If we raise error here, all we get is 502 error, which is not desired.
	if err != nil {
		return FailureMessage(400, fmt.Sprintf("invalid event %v", err)), nil
	}
	err = sendToQueue(eventBody.String(), os.Getenv("QUEUE_NAME"))
	if err != nil {
		log.Errorf("failed to send message to queue %v ", err)
	}
	return Success(), nil
}

func main() {

	lambda.Start(Handler)
}
