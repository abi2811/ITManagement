# ITManagementDemo with MS SQL Server Linux (Docker)

1. Install docker from https://www.docker.com/get-started

2. Check if the docker installation was successful?
    docker --version

2. Pull MS SQL Server from CLI: 
    docker pull microsoft/mssql-server-linux

3. Check correctly downloaded MS SQL Server from CLI:
    docker images

4. Create our container with MS SQL Server
    docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=secret1!' -p 1433:1433 --name sql1 -d microsoft/mssql-server-linux:latest

5. After clone code 
    cd ITManagement/Api
    dotnet ef migrations add initial
    dotnet ef database update

6. Run code
    dotnet run

7. Test POST with postman
    https://localhost:5001/api/users

            {
                "username": "user1",
                "email": "user1@email.com",
                "password": "secret",
            }

8. Test GET with postman
    https://localhost:5001/api/users/user1@email.com

WORK!
