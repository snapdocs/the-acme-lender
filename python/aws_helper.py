import json
import os
import logging
import boto3


def load_secrets_to_environments(secret_id):
    try:
        client = boto3.client('secretsmanager')
        response = client.get_secret_value(
            SecretId=f"{os.getenv('ENV')}/example-snapdocs-event-listener/oauth"
        )

        oauth_credentials = json.loads(response['SecretString'])
        # iterate each key-value pair and set to os environment variables
        
        os.environ['SNAPDOCS_API_CLIENT_ID'] = oauth_credentials['client_id']
        os.environ['SNAPDOCS_API_CLIENT_SECRET'] = oauth_credentials['client_secret']
    except Exception as e:
        logging.error(e)
        raise
