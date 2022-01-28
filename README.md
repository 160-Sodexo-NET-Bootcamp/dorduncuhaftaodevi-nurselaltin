# Hangfire.Project

This project is about using Hangfire library of .Net Core.

This project formed  of tiers of DataAccess , Entities ,  UI  and Console.

#Entities Tier

 - User and SystemInformation class corresponds to the table in the database.I marked this class by IEntity interfaces.Because , I  report classes which marked by IEntity are table of database.

#DataAccess Tier 

 - I defined operations which I do on the database in IRepositoryBase.
 - I used Entity Framework for connect to database.But you can use Dapper Library for connect.You should fill with  operations of  Dapper  to Dapper Repository classes.
 - I used Unit of Work and Repository Pattern in here.
 - I used  MSSQL  as database.

#UI Tier

  -I created Web Api project in here . This api is doing operation with datas of user and systeminformation.

#HangfireConsole
  - Manager classes execute jobs of Hangfire .

   # SystemManager

   - This class's job save datas about users table every 15 minutes.System admin can  track "Hangfire.Project"" with GetReport end point of SystemController . This data for inform to admin. 

   # UserManager

   - This class's job update isActive column of users that created between 08.00 and 18.00 hour  every day 18.00  hour. 

#ABOUT FOLDER OF UI TIER

## ViewModel Folder 
  - You can use view models' classes when show data to user in here. 

## Common Folder 
  - You can turn view model and entities each other with MappingProfile class. This class extend from Profile class of AutoMapper.


##WebAPI

The  Web API is described below.

#USER CONTROLLER

## Get User List

### Request

`GET /User/`

    curl -X GET " https://localhost:44396/api/User/" -H  "accept: */*" -d ""

    #### Request URL
    https://localhost:44396/api/User

### Response

    HTTP/1.1 200 OK
    Date: Tue21 Dec 2021 09:40:56 GMT 
    Status: 200 OK
    Connection: close
    Content-Type: application/json; charset=utf-8

## Get User By ID

### Request

`GET /User?id`

    curl -X GET " https://localhost:44396/api/User?id" -H  "accept: */*" -d ""

    #### Request URL
    https://localhost:44396/api/User?id

### Response

    HTTP/1.1 200 OK
    Date: Tue21 Dec 2021 09:40:56 GMT 
    Status: 200 OK
    Connection: close
    Content-Type: application/json; charset=utf-8



## Create a new User

### Request

`POST /User/`

    curl -X POST "https://localhost:44392/api/User" 

### Response

    HTTP/1.1 200 OK
    Date: Tue21 Dec 2021 09:40:56 GMT 
    Status: 200 OK
    Connection: close
    Content-Type: application/json; charset=utf-8


#SYSTEM CONTROLLER

## Get System List

### Request

`GET /System/`

    curl -X GET " https://localhost:44396/api/System/" -H  "accept: */*" -d ""

    #### Request URL
    https://localhost:44396/api/System

### Response

    HTTP/1.1 200 OK
    Date: Tue21 Dec 2021 09:40:56 GMT 
    Status: 200 OK
    Connection: close
    Content-Type: application/json; charset=utf-8

