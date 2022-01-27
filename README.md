# The example code to demonstrate integration with Snapdocs API

This repository has the example code to help our customers to test and integrate with the Snapdocs APIs.

## Features

1. a python utility to confirm the oauth credentials
2. a simple AWS Lambda function to serve as the webhook service to listen to Snapdocs events, and download the scanback documents.
3. a python utility to manage subscriptions

## Configuration

This python project uses .env to load configuration items. For local testing, you can create a file ".env" as below

````
SNAPDOCS_TOKEN_URL=https://auth.cs-demo0.snpd.io/oauth/token
SNAPDOCS_API_URL=https://api.cs-demo0.snpd.io/api/v1
SNAPDOCS_API_CLIENT_ID=...
SNAPDOCS_API_CLIENT_SECRET=...
LOG_LEVEL=INFO
````
If you want to test the AWS Lambda and API Gateway for the webhook service, then the oauth client id and secret should be deployed through AWS Secret Manager.
In that case, your .env file (or .env.dev) remove the client id and secret variables.

## Secrets
Only needed when you deploy the Lambda example to AWS
Go to AWS Console, select the "Secret Manager" service, add a new secret (check the "Other type of secret")
Add two rows of key-value pairs.
````
key:client_id
value: the oauth client id
````
and
````
key: client_secret
value: the oauth client secret
````
Use the "DefaultEncryptionKey"

On the next screen, enter the secret name "dev/example-snapdocs-event-listener/oauth", accept all the default values and store the secret.

## Webhook Service (Listener)

The webhook (a lambda behind API gateway) has endpoint "dev/example-snapdocs-event-listener/oauth", that we can register at Snapdocs and receive events.


## Deploy the Snapdocs event listener example (webhook service) to AWS

First, install the serverless framework at your local computer

````
npm install -g serverless
serverless plugin install -n serverless-python-requirements
````

Deploy to AWS, for example us-west-2 region, environment "dev"
````
serverless deploy --stage dev --region us-west-2 --verbose --aws-profile [the AWS profile name that you use]
````

you should see something like below in the output
````
✔ Service deployed to stack example-snapdocs-event-listener-dev (131s)

endpoint: POST - https://....execute-api.us-west-2.amazonaws.com/dev/listen/snapdocs
functions:
  snapdocs-event-listener: example-snapdocs-event-listener-dev-snapdocs-event-listener (5.8 MB)

Stack Outputs:
  SnapdocsDasheventDashlistenerLambdaFunctionQualifiedArn: ...
  ServiceEndpoint: https://....execute-api.us-west-2.amazonaws.com/dev
  ServerlessDeploymentBucketName: ...

````

The "https://....execute-api.us-west-2.amazonaws.com/dev/listen/snapdocs" is the webhook url that you will use
later to register at Snapdocs

To do a quick test of the webhook service

````
curl --location --request POST 'https://.....execute-api.us-west-2.amazonaws.com/dev/listen/snapdocs' \
--header 'Content-Type: application/json' \
--data-raw '{
  "event_id": "572f592a-fbec-49d9-a28a-88d8e38175be",
  "closing_uuid": "23e4567-e89b-12d3-a456-426614174000",
  "event_name": "document.created",
  "document_uuid": "cfdc4924-86a5-4353-8ec3-26368b9157c4",
  "document_type": "scanback_documents",
  "created_at": 1618936005,
  "payload": {
    "external_identifiers": [
      {
        "external_system": "other_los",
        "external_type": "file_number",
        "value": "1234"
      }
    ]
  }
}'
````

## Register the webhook


## Create a closing

## Upload Documents