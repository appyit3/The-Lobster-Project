get mongo: sudo docker pull mongo -> in case you don't have it
done: /mongodata has already been created and commited.
run with volume: docker run -it -v /home/appy/Github/The-Lobster-Project/database/mongodata:/data/db --name mongodb -d mongo
run bash in mongo: docker exec -it mongodb bash
run mongoshell with command (mongo command is deprecated): mongosh
>db.users.find().forEach(printjson)