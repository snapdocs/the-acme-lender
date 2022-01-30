.PHONY: build clean deploy gomodgen run-local

build:
	export GO111MODULE=on

	env GOOS=linux go build -v -o bin/lambda lambda.go
	env GOOS=linux GOARCH=amd64 go build -v -o bin/verifyaccess cmd/verifyaccess.go
clean:
	rm -rf ./bin ./vendor

deploy: clean build
	serverless deploy --stage dev --region us-west-2 --verbose --aws-profile iamadmin-coopers-cose

gomodgen:
	chmod u+x gomod.sh
	./gomod.sh

verify:
	go run cmd/verifyaccess.go
