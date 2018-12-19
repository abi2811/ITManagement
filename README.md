# ITManagement [.NET CORE, MS SQL, DOCKER]

### Plan

[x] create application base with basic functions

[ ] add container IoC to code

[ ] add authorization module

[ ] add generating documents module

[ ] create SPA with Angular

[ ] deploy app to production server


### What the project does?
IT Management - an application that manages IT devices, for example: laptops, tablets, mobile phones.  

Functions: 

* device base in the company, 

* register of rented devices for employees, 

* device history, 

* generating documents for the transfer and receipt of devices, 

* generating reports

### Why the project is useful?
I used the software for such devices management but I had to cancel because of the license prices.

I decided to write the same software not only for myself. I think that it is necessary for the IT department to operate.

The IT department will know:

* how many devices are available

* who has our devices

* who had the devices before

### How users can get started with the project?
#### for tests

Setup Docker Database and install dotnet core:

1. Install docker from https://www.docker.com/get-started

2. Check if the docker installation was successful?
    docker --version

2. Pull MS SQL Server from CLI: 
    docker pull microsoft/mssql-server-linux

3. Check correctly downloaded MS SQL Server from CLI:
    docker images

4. Create our container with MS SQL Server
    docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=secret1!' -p 1433:1433 --name sql1 -d microsoft/mssql-server-linux:latest

#### for production
5. Install MS Sql database and create account sa with password 'secret1!'

6. change address sql server in ITManagement.API/appsettings.json

  "ConnectionStrings": {
    "sql": "Server=YOUR_SQL_SERVER_ADDRESS;User Id=SA;Password=secret1!;Database=ITManagement"

#### next:

7. Clone my project

8. After clone code you must go to the project folder to ITManagement/API

9. Make database migrations
    
    dotnet ef migratons add InitialDB
    
    dotnet ef database update
    
and next:

10. Run code
    dotnet run
    
### Where users can get help with your project?

For help you, can write me message: adrian.staszewski28@gmail.com

### Who maintains and contributes to the project?

This is only my project. I learn programming in C#. I have hope that I will be commercial developer.

### Available requests [current]:

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


