package integrationtesting

import (
	"os"

	log "github.com/sirupsen/logrus"

	"github.com/joho/godotenv"
)

//setup load the .env, to help integration testing with the AWS credentials etc.
func setup() {
	err := godotenv.Load()
	if err != nil {
		log.Fatal("Error loading .env file")
	}
	level, _ := log.ParseLevel(os.Getenv("LOG_LEVEL"))
	log.SetLevel(level)
}
