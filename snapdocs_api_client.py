import os
import logging
from requests import Session

import enum

logger = logging.getLogger()
LOG_LEVEL = os.environ.get('LOG_LEVEL', 'WARNING').upper()
logger.setLevel(level=LOG_LEVEL)


class StandardSigningMethod(enum.Enum):
    wet_only = "wet_only"
    hybrid = "hybrid"
    hybrid_with_enote = "hybrid_with_enote"


class FullEclosingSigningMethod(enum.Enum):
    full_eclosing_with_enote = "full_eclosing_with_enote"
    full_eclosing = "full_eclosing"


class SnapdocsApiClient():

    def refresh_oauth_token(self):
        token_url = os.environ.get('SNAPDOCS_TOKEN_URL')

        data = {
            "client_id": os.environ.get('SNAPDOCS_API_CLIENT_ID'),
            "client_secret": os.environ.get('SNAPDOCS_API_CLIENT_SECRET'),
            "scope": os.environ.get('SNAPDOCS_API_SCOPE'),
            'grant_type': 'client_credentials'
        }
        print(data)
        access_token_response = self.session.post(token_url, data=data)
        access_token_response.raise_for_status()
        return access_token_response.json()['access_token']

    def __init__(self):
        super().__init__()
        self.session = Session()
        self.snapdocs_api_url = os.environ.get('SNAPDOCS_API_URL')
        # get auth token
        auth_token = self.refresh_oauth_token()
        self.headers = {
            'Authorization': f"Bearer {auth_token}"
        }

    def download_document(self, closing_uuid, document_uuid):
        api_endpoint = f"{self.snapdocs_api_url}/closings/{closing_uuid}/documents/{document_uuid}"
        headers = {
            'Accept': 'application/pdf'
        }

        api_call_response = self.session.get(url=api_endpoint, headers={**headers, **self.headers})
        api_call_response.raise_for_status()
        print(api_call_response.text)

    def get_all_subscriptions(self):
        api_endpoint = f"{self.snapdocs_api_url}/subscriptions"
        headers = {
            'Accept': 'application/json'
        }

        api_call_response = self.session.get(url=api_endpoint, headers={**headers, **self.headers})
        api_call_response.raise_for_status()
        print(api_call_response.text)

    def create_subscription(self, event, webhook_url, desc):
        api_endpoint = f"{self.snapdocs_api_url}/subscriptions"
        headers = {
            'Accept': 'application/json'
        }
        body = {
            "events": [
                event
            ],
            "description": desc,
            "webhook_url": webhook_url
        }
        api_call_response = self.session.post(url=api_endpoint, data=body, headers={**headers, **self.headers})
        api_call_response.raise_for_status()
        print(api_call_response.text)

    def delete_subscription(self, sub_id):
        api_endpoint = f"{self.snapdocs_api_url}/subscriptions/{sub_id}"
        headers = {
            'Accept': 'application/json'
        }

        api_call_response = self.session.delete(url=api_endpoint, headers={**headers, **self.headers})
        api_call_response.raise_for_status()
        print(api_call_response.text)

    def make_borrower(self):
        borrower = {
            "first_name": "Primary",
            "middle_name": "Middle",
            "last_name": "Signer",
            "suffix": "Jr",
            "email": "primary.signer@snapdocs.com",
            "phone": "2343234333",
            "address": "123 Example Ln",
            "city": "San Francisco",
            "state": "California",
            "zip": "94107",
            "ssn_last_4": "1234"
        }
        return borrower

    def make_closing_user(self):
        user = {
            "first_name": "Closer",
            "last_name": "User",
            "phone": "1234567890",
            "email": "email@example.com",
            "roles": [
                "loan_officer",
                "closer"
            ]
        }
        return user

    def make_settlement_agent(self):
        agent = {
            "first_name": "Settlement",
            "last_name": "Agent",
            "phone": "1234567890",
            "email": "settlement.agent@snapdocs.com"
        }

        return agent

    def make_external_identifer(self):
        external_identifier = {
            "value": "dafafda",
            "external_type": "loan_id",
            "external_system": "other_los"
        }
        return external_identifier

    # A closing with signing_method of wet_only, hybrid, or hybrid_with_enote

    def create_standard_closing(self, signing_method: StandardSigningMethod, borrowers, closing_users,
                                external_identifiers, settlement_agents):
        body = {
            "file_number": "a",
            "reference_id": "vdd",
            "source": "test",
            "signing_method": signing_method,
            "appointment_earliest_at": "2020-12-04",
            "appointment_latest_at": "2020-12-04",
            "appointment_date": "2020-12-04",
            "appointment_time": "9:00 am",
            "appointment_location_address": "123 Main St",
            "appointment_location_city": "Denver",
            "appointment_location_state": "CO",
            "appointment_location_zip": "80212",
            "funding_team_email": "funding-team@lender.com",
            "property_street_address": "California",
            "property_city": "123 Test Ln",
            "property_state": "California",
            "property_zip": "94107",
            "settlement_office_email": "settlementoffice@example.com",
            "settlement_office_name": "Settlement Office",
            "settlement_office_address": "123 Test Settlement Office",
            "settlement_office_city": "San Francisco",
            "settlement_office_state": "California",
            "settlement_office_zip": "94107",
            "borrowers": borrowers,
            'closing_users': closing_users,
            "external_identifiers": external_identifiers,
            "settlement_agents": settlement_agents
        }
        api_endpoint = f"{self.snapdocs_api_url}/closings"
        headers = {
            'Accept': 'application/json'
        }

        api_call_response = self.session.post(url=api_endpoint, data=body, headers={**headers, **self.headers})
        api_call_response.raise_for_status()
        print(api_call_response.text)

    def create_full_eclosing(self):
        pass
