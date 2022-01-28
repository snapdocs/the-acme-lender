

from snapdocs_api_client import SnapdocsApiClient
from aws_helper import load_secrets_to_environments

load_secrets_to_environments()
client = SnapdocsApiClient()
client.get_all_subscriptions()