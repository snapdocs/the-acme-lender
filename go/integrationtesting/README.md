# Integration tesitng of the API

It is Unit Test with real hosts.

To run individual testing of the client method:

````
go test -v github.com/snapdocs/the-acme-lender/integrationtesting -run TestSnapdocsApiClient_GetSubscriptions
go test -v github.com/snapdocs/the-acme-lender/integrationtesting -run TestSnapdocsApiClient_DownloadDocument

````