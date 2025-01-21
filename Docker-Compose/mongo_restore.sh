
# Install Environment file
source ./.env 

# Backup MongoDB
docker exec -i ml-mongodb mongorestore --uri "mongodb://user:password@localhost:27018/?authMechanism=SCRAM-SHA-1" --nsInclude="ml-challenge.*" --archive <./mongo_backup/test_backup.dump
