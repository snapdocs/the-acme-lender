from dotenv import load_dotenv
from snapdocs_api_client import SnapdocsApiClient
from aws_helper import load_secrets_to_environments
load_dotenv(".env.dev")
load_secrets_to_environments()
client = SnapdocsApiClient()
client.get_all_subscriptions()