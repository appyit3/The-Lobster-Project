docker build: docker build -t lobsterapi .
run: docker run -p 3000:3000 --name lobsterapi -d lobsterapi
visit http://localhost:3000/WeatherForecast
authenticate - give username and password in post method body: http://localhost:3000/authenticate
docker exec -it lobsterapi bash
