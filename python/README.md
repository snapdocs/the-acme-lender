# The ACME Lender Python Version

This repository has the example Python code to help our customers to test and integrate with the Snapdocs APIs.

## Features

1. a python utility to confirm the oauth credentials
2. a simple AWS Lambda function to serve as the webhook service to listen to Snapdocs events, and download the scanback documents.
3. a python utility to manage subscriptions

## Start

````
python3 -m pip install --user virtualenv
python3 -m venv venv
chmod +x venv/bin/activate
venv/bin/activate 
python3 -m pip install --user --upgrade pip
python3 -m pip install -r requirements.txt
````

## to verify API access
create a file .env with correct URLs and credentials

````
SNAPDOCS_TOKEN_URL=
SNAPDOCS_API_URL=
SNAPDOCS_API_CLIENT_ID=
SNAPDOCS_API_CLIENT_SECRET=
SNAPDOCS_API_SCOPE=closings:create closings:mark_finished_uploading_docs closings:show 
````
then, run the Python program
````
python3 verify_oauth_credentials.py
````

## To deploy the Lambda to your AWS account

first edit the .env.dev with the correct URLs and scopes, then, add a AWS secret at AWS Secret Manager
````
secret id: dev/example-snapdocs-event-listener/oauth
key: SNAPDOCS_API_CLIENT_ID value: the client id
key: SNAPDOCS_API_CLIENT_SECRET value: the secret
````

then, install serverless framework https://www.serverless.com/framework/docs/getting-started, and deploy the lambda. Make sure you have the right permissions to create stacks at AWS.

````
npm install -g serverless
serverless plugin install -n serverless-python-requirements
serverless deploy --stage dev --region us-west-2 --verbose --aws-profile [the AWS profile name that you use]
````

