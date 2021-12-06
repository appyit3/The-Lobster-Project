docker build: docker build -t lobsterapi .
run: docker run -p 3000:3000 --name lobsterapi -d lobsterapi
visit http://localhost:3000/WeatherForecast

docker exec -it lobsterapi bash
