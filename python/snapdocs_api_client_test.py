from dotenv import load_dotenv
from snapdocs_api_client import SnapdocsApiClient
from aws_helper import load_secrets_to_environments
import os
load_dotenv(".env.dev")
load_secrets_to_environments(f"{os.getenv('ENV')}/example-snapdocs-event-listener/oauth")
client = SnapdocsApiClient()
client.get_all_subscriptions()