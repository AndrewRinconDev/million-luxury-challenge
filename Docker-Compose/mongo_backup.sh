#!/bin/bash
# mongo_backup.sh

# Install Environment file
source ./.env

# Backup MongoDB
docker exec -i ml-mongodb mongodump --uri "mongodb://user:password@localhost:27018/?authMechanism=SCRAM-SHA-1" --db $MONGO_DB_NAME --authenticationDatabase admin --archive >./mongo_backup/test_backup.dump
