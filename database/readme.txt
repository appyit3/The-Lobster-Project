We are directly using mongo image as our DB. Preseeding is done in code itself. 
I tried the javascript approach and it worked. 
But had to create another image for it, using mongo base image and expose ports separately. Current process is less verbose.

Volumes are added mapped to repo folder (database/mongodata) so that you can easily take a backup of it (Instead of trying to figure out where the data is).
run bash in mongo: docker exec -it lobsterdb bash
run mongoshell with command (mongo command is deprecated): mongosh
>use lobsterdb
>db.users.find().forEach(printjson)