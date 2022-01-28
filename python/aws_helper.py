import json
import os
import logging
import boto3


def load_secrets_to_environments(secret_id):
    try:
        client = boto3.client('secretsmanager')
        response = client.get_secret_value(
            SecretId=secret_id
        )

        secret = json.loads(response['SecretString'])
        # iterate each key-value pair and set to os environment variables
        for key in secret:
            os.environ[key] = secret[key]
    except Exception as e:
        logging.error(e)
        raise

if __name__ == '__main__':
    import sys
    print(sys.argv[1])
    load_secrets_to_environments(sys.argv[1])