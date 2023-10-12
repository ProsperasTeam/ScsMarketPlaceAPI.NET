

## Add a new package
1. Open a terminal/command prompt. 
2. Navigate to your project's directory. Replace `YourProjectName` with the actual name of your project directory:

```shell

cd /path/to/YourProjectName
``` 
3. Use the `dotnet add package` command to add the `Microsoft.AspNetCore.Authentication.JwtBearer` package:

```shell

dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
``` 
4. After running the command, the .NET CLI will download and add the package reference to your project. You should see output indicating that the package was added successfully. 
5. Build your project to ensure that the package reference is correctly resolved:

```shell

dotnet build
```

## To run a microservice using .NET, you typically build and run your microservice application using the `dotnet` command-line interface (CLI)

1. **Navigate to Your Microservice Project Directory** : Open a command prompt or terminal and navigate to the directory containing your microservice project. 
2. **Build the Microservice** : 
- Build your microservice project using the `dotnet build` command:

```bash

dotnet build
``` 
3. **Run the Microservice** : 
- If your microservice is a console application, you can run it using the `dotnet run` command:

```bash

dotnet run
``` 
- If your microservice is a web application (e.g., ASP.NET Core), you should publish it first and then run the published version. Publishing generates optimized and self-contained output. 
- Publish the microservice using the `dotnet publish` command:

```bash

dotnet publish -c Release -o <output_directory>
```



Replace `<output_directory>` with the path where you want the published files to be placed. 
- Navigate to the published output directory:

```bash

cd <output_directory>
``` 
- Run the microservice using `dotnet` and specify the DLL or executable file:

```bash

dotnet ScsMarketplace.TestService.dll
```

Ensure that you use the correct DLL or executable name in the command. 
4. **Verify Your Microservice** :
After running your microservice, access it through the specified endpoint (e.g., [http://localhost:5000](http://localhost:5000/) ) or interact with it as needed.


## Git
  - Untrack all files listed in your .gitignore file in one go, you can use the following command:
    ```bash
    git rm --cached $(git ls-files -i --exclude-from=.gitignore)
    ```

## Docker
1. **docker-compose build** : This command builds the images specified in your `docker-compose.yml` file. It's used to create the Docker images for your services.

```bash

docker-compose build
``` 
2. **docker-compose up** : This command starts your application's services based on the configurations defined in the `docker-compose.yml` file. It will create and start the containers.

```bash

docker-compose up
``` 
3. **docker-compose down** : This command stops and removes the containers created by `docker-compose up`. It's used to shut down your application.

```bash

docker-compose down
``` 
4. **docker-compose logs** : This command allows you to view the logs generated by your running containers. You can specify a service name to view logs for a specific service.

```bash

docker-compose logs [service_name]
``` 
5. **docker-compose exec** : This command allows you to run a command within a running container. You can use it for tasks like accessing a container's shell for debugging.

```bash

docker-compose exec [service_name] [command]
```



## Swagger
```bash
http://localhost:5000/swagger/index.html
```


## Dotnet

-   Run the services on development mode
```bash
dotnet run --environment Development
```

-  Run services on production mode
```bash
dotnet run --environment Production
```

- Add new service
```bash
dotnet new webapi -n YourMicroserviceName
```

## Adding authentication 
```bash
dotnet add package Microsoft.AspNetCore.Authentication
dotnet add package Swashbuckle.AspNetCore
```


## Configuration files
1.  configuration files should be stored on home directory (~/config) and set with specific permissions 

2.  configuration files should be stored also in the main dir of repository when using docker. They are ignored by git

3.  configuration files under ~/config are shared between every service, and for specific cofngiuration without secrets we use appsettings.json, appsettings.Development.json, appsettings.Staging.json, appsettings.Production.json



## Environments
1.  We have 3 environments:
    1.  Development - we use docker-compose to build and run the app 
    2.  Staging - we connect to the database in AWS and the app is run via Visual Code 
    3.  Production -  we run the app via ansible in AWS ec2 instances 

