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