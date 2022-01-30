package main

import (
	"log"
	"os"

	"github.com/joho/godotenv"
	"github.com/snapdocs/the-acme-lender/pkg/snapdocs"
)

func main() {
	err := godotenv.Load()
	if err != nil {
		log.Fatal("Error loading .env file", err)
	}
	apiClient := snapdocs.NewSnapdocsApiClient(os.Getenv("SNAPDOCS_API_URL"))
	res, err := apiClient.GetSubscriptions()
	if err != nil {
		log.Fatalf("failed to call the subscriptions endpoint %v", err)
	}
	log.Println(res)

}
