# Run container

### 1
```
git clone https://github.com/DanisimoDanik228/TestDocker.git
```
### 2
```
cd TestDocker/
sudo docker compose -f ./TestDocker/compose.yaml up -d --build
```

# Check docker
```
sudo docker ps
```
You must see this
```
CONTAINER ID   IMAGE            COMMAND                  CREATED         STATUS         PORTS                                                   NAMES
bbedd12e6670   testdocker-api   "dotnet TestDocker.d…"   1 minutes ago   Up 1 minutes   8081/tcp, 0.0.0.0:5000->8080/tcp, [::]:5000->8080/tcp   testdocker_api
8c1506c6ec92   postgres:16      "docker-entrypoint.s…"   1 minutes ago   Up 1 minutes   0.0.0.0:5432->5432/tcp, [::]:5432->5432/tcp             testdocker_postgres
```

# Check browser on 
```
http://localhost:5000/WeatherForecast/add
```
```
http://localhost:5000/WeatherForecast/get
```
