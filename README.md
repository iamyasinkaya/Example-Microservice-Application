
# Example Microservice Application

This project includes a sample application developed using microservice architecture. Platform service and command service are orchestrated using Kubernetes (k8s).

## Getting started

You can follow the steps below to run the project in your local environment.

#### Requirements

- Docker
- Kubernetes (k8s)

#### Installation

1. Clone Repository:
   ```bash
   git clone https://github.com/iamyasinkaya/Example-Microservice-Application.git

2. To start platform and command services:
   ```bash
   cd Example-Microservice-Application
   kubectl apply -f k8s/platform-service.yaml
   kubectl apply -f k8s/command-service.yaml

3. Check the status of the services:
   ```bash
   kubectl get pods

4. To test the application:
 ```bash
http://localhost:<PORT>/platform
http://localhost:<PORT>/command
```
### Contributing

If you would like to contribute to this project, please first review the file [CONTRIBUTING.md](CONTRIBUTING.md).

### License

This project is licensed under the [MIT License](LICENSE). Check the license file for detailed information.
