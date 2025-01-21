
# Million Luxury Assessment

The API was developed with .netCore 6, Mongo DB for the database with a hexagonal architecture and repository pattern for handling injections, with the respective Unit tests. The frontend was developed with React 19 and NextJS 15, For styling, tailwind css and some pure css styles with a simple responsive design for Mobile first were used and consumption of API services with fetch and the corresponding Unit Tests.

Copyrighted images were used for demonstration purposes only.

Assessment carried out as a selection process.


## Prerequisites

- Mongo DB Installed
- NodeJS Installed


## Run Locally

### 1. Run Backend

Clone the project

```bash
  git clone https://github.com/AndrewRinconDev/million-luxury-challenge.git
```

Restore Database
- Connect Locally with console or IDE as MongoDB Compass on

```bash
  mongodb://localhost:27017
``` 

- Create Database called **ml-challenge**
- Create Collection called **properties**
- Click **Add Data** button and import from JSON or CSV file
- Attach the **ml-challenge.properties.json** file 


***Note:** If the Mongo connection use other port, database or Collection name you should change in the appsettings.json file in the api project*

Open de solution and confirma that the Api project is the startup project

```bash
  Run the project
```

After a few seconds a swagger web page will open *(https://localhost:7015/swagger/index.html)* with the available endpoints, to confirm that the database connection is correct you can try to run the first endpoint without placing any filter and you will confirm the correct connection.

### 2. Run frontend

Open project
```bash
  cd .\frontend
```

Install dependencies

```bash
  npm install
```

Start the server

```bash
  npm run dev
```

***Important:** Confirm that the backend is running on port **7815**, if not configure it in the contants/global.ts file*


## Running Tests

To run tests, run the following command

```bash
  npm run test
```


## Authors

- [@AndrewRinconDev](https://www.github.com/AndrewRinconDev)
