import json
import os
import logging
from aws_helper import load_secrets_to_environments
from snapdocs_api_client import SnapdocsApiClient
logger = logging.getLogger()
LOG_LEVEL = os.environ.get('LOG_LEVEL', 'WARNING').upper()
logger.setLevel(level=LOG_LEVEL)

success_code = 200
success_body = {
    "status": "OK",
    "code": success_code,
    "message": "webhook received successfully"
}


def download_scanback_document(closing_uuid, document_uuid):
    logger.info("downloading scanback document %s", document_uuid)
    load_secrets_to_environments(f"{os.getenv('ENV')}/example-snapdocs-event-listener/oauth")
    client = SnapdocsApiClient()
    client.download_document(closing_uuid, document_uuid)
    pass


def process_snapdocs_event(event_body):
    try:
        # check event body
        logger.debug("%s %s %s", event_body.get('event_id'), event_body.get('closing_uuid'),
                     event_body.get('event_name'))
        logger.debug("lender system attributes %s", event_body.get("payload"))
        # typically we put the message into a message broker to be processed downstream
        if event_body.get('event_name') == 'document.created':
            if event_body.get('document_type') == 'scanback_documents':
                download_scanback_document(event_body.get('closing_uuid'), event_body.get('document_uuid'))
            else:
                pass
    except Exception as e:
        logger.error(e)
        return 500, {
            "status": "Failed to process event",
            "code": 500,
            "message": f"webhook received but could not process {str(e)}"
        }
    return success_code, success_body


def handle(event, context):
    code = success_code
    response_body = success_body
    try:
        if event['body']:
            body = json.loads(event['body'])
            code, response_body = process_snapdocs_event(body)
        else:
            raise "no data found in the post body"
    except Exception as e:
        code = 400
        response_body = {
            "status": "Bad Request",
            "code": code,
            "message": f"failed to parse the webhook, {str(e)}"
        }
    finally:
        return {"statusCode": code, "body": json.dumps(response_body)}
