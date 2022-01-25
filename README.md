# SampleWebAPIWithJasonWebToken

SampleWebAPIWithJasonWebToken is an ASP.NET Core Web API C# that provides simple WebAPI HTTPGET functionality.


## Pre-Requisite
The following are mandatory for the CoreDemoWebAPI application to run :

1. Microsoft .NET Core 5.0 Runtime or SDK.
2. Postman Application.


## Installation

1. Run Visual Studio 2019

2. Select 'Clone a repository'

 	Repository location: 
 	https://github.com/timanand/SampleWebAPIWithJasonWebToken.git

 	Path:
 	This is the location on your computer where Repository shall be copied to. For example: 'C:\DEVELOP\SampleWebAPIWithJasonWebToken\'.

 	Click on 'Clone' button.




3. On the right side, you will see the Solution Explorer window. Double click on 'Auth.Demo.sln'.



4. From 'Build' menu, select 'Rebuild Solution'. 
	--> It will say : 
		
		- Rebuild All: 1 succeeded


## Usage

Press F5 or click on the Play button icon from the toolbar in Visual Studio 2019 for the above solution.

When you run the Web application it will allow the ability to Create, Update and Delete Staff Members.

IMPORTANT NOTE: port 44305 may different on your machine, change accordingly.



GET RECORDS VIA HTTPGET

--> Run Visual Studio 2019 project, and it displays browser.


Run Postman application.

Select POST
https://localhost:44305/api/name/authenticate

Click Body
Click raw

{"username":"test1","password":"test1"}

Click Headers

In Key, type : Content-Type
In Value, type : application/json


Click 'Send'

----> 401 unauthorised because we specified incorrect passsword!


Now change : Username=test1, password=password1 ie. correct password

https://localhost:44305/api/name/authenticate
----> returns token

Copy this token



Create new tab
GET 	https://localhost:44305/api/name

Click Header
	Add key: Authorization
	Add value: Bearer <paste token string>

Click Send button.

It will display :

[
    "New Jersey",
    "New York"
]


## License & Copyright

(c) 2022 Arvinder Anand (Tim)

 
