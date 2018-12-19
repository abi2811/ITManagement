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

7. Available requests [current]:

GET /api/users - get all user
GET /api/users/user@email.com - get user by email
PUT /api/users - add user, request with JSON body (firstname, lastname, email, departament)
GET /api/departaments - get all departaments in company
GET /api/departaments/'name' - get deparament by name
PUT /api/departaments - add departament, request with JSON body (name)
GET /api/deviceevents - get all device events
GET /api/deviceevents/'internalNumber' - get events by device internal number
GET /api/devicetypes - get all device types
GET /api/devicetypes/'name' - get device type by name
PUT /api/devicetypes - add device type, request with JSON body (name)
GET /api/users - get all users
GET /api/users/'email' - get user by email
PUT /api/users - add user, request with JSON body (username, email, password)
GET /api/devices - get all devices 
GET /api/devices/'internalNumber' - get device by internal number
GET /api/devices/client - get client devices, request with JSON body (email)

POST /api/devices/changeserialnumber - change serial number with JSON body (InternalNumber, NewSerialNumber)

POST /api/devices/changename - change model device with JSON body (InternalNumber, NewName)

POST /api/devices/changeinternalnumber - change internal number with JSON body (InternalNumber 'present internal number', NewInternalNumber)

POST /api/devices/returndevice - mark device as available with JSON body (InternalNumber, ClientEmail)

POST /api/devices/changeclient - change client with JSON body (Email 'client email', InternalNumber 'internal company device number')

PUT /api/devices - add device, request with JSON body (Name 'ex. Model'], InternalNumber 'internal company device number',             SerialNumber 'device s/n' , DeviceType 'type name')


