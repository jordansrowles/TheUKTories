# touch the database and create the user
mongo --eval 'use theuktoriesdb'
USER='
db.createUser(
    {
      user: "theuktoriesuser",
      pwd: "password1",  // or cleartext password
      roles: [
         { role: "readWrite", db: "theuktoriesdb" }
      ]
    }
  )'
mongo theuktoriesdb --eval $USER

# import json files to seed the live database
mongoimport -u theuktoriesuser -p password1 mongodb://localhost:27017 -d theuktoriesdb public/data/austerity.json -c items
mongoimport -u theuktoriesuser -p password1 mongodb://localhost:27017 -d theuktoriesdb public/data/covidresponse.json -c items
mongoimport -u theuktoriesuser -p password1 mongodb://localhost:27017 -d theuktoriesdb public/data/premiers.json -c electionyears
