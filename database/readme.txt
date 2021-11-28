docker build: docker build -t lobmongo .
run: docker run -it --name mongodb -d lobmongo
run bash in mongo: docker exec -it mongodb bash
run mongoshell with command (mongo command is deprecated): mongosh
>db.users.find().forEach(printjson)