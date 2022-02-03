.PHONY: build clean deploy gomodgen run-local

build:
	export GO111MODULE=on

	env GOOS=linux go build -v -o bin/webhooklambda cmd/webhooklambda/main.go
	env GOOS=linux go build -v -o bin/eventprocessor cmd/eventprocessor/main.go
	env GOOS=linux GOARCH=amd64 go build -v -o bin/verifyaccess cmd/verifyaccess/main.go
clean:
	rm -rf ./bin ./vendor

deploy: clean build
	serverless deploy --stage dev --region us-west-2 --verbose

gomodgen:
	chmod u+x gomod.sh
	./gomod.sh

verify:
	go run cmd/verifyaccess/main.go

processor:
	go run cmd/eventprocessor/main.go 
