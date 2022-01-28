import os

from dotenv import load_dotenv
from requests import Session

load_dotenv()

token_url = os.environ.get('SNAPDOCS_TOKEN_URL')

test_api_url = os.environ.get('SNAPDOCS_API_URL') + "/subscriptions"
data = {
    "client_id": os.environ.get('SNAPDOCS_API_CLIENT_ID'),
    "client_secret": os.environ.get('SNAPDOCS_API_CLIENT_SECRET'),
    "scope": "subscriptions:index",
    'grant_type': 'client_credentials'
}

s = Session()

access_token_response = s.post(token_url, data=data)
access_token_response.raise_for_status()
print(access_token_response)

tokens = access_token_response.json()

print("access token: " + tokens['access_token'])

#step B - with the returned access_token we can make as many calls as we want

api_call_headers = {'Authorization': 'Bearer ' + tokens['access_token']}
api_call_response = s.get(test_api_url, headers=api_call_headers, verify=False)
api_call_response.raise_for_status()
print(api_call_response.text)