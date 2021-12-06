docker build: docker build -t lobsterweb .
run: docker run -p 4000:80 --name lobsterweb -d lobsterweb
visit http://localhost:4000
