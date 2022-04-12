# .Net Test Task

The database file is located in the root folder, its called database.db

To run this project in your local environment you should open the file appsettings.json and change the value REST_APIContext to the full path to the database file, ex: "Data Source = C:/Users/xxxx/repos/REST_API/database.db"

There are three endpoints for this API:
  - **Login:** _[Post]_ **URL:**/api/Users/login
  - **Update Balance:** _[Put]_ **URL:**/api/Users/updateBalance
  - **Delete User:** _[Delete]_ **URL:**/api/Users/deleteUser/{UserToDelete}  <br><br>
   
The data to consume the endpoints should be formated as indicated bellow:<br>
<br>**Login:**<br>
The body of the request should be a JSON object with the following format:<br>
_{<br>
  "login": "string",<br>
  "password": "string"<br>
}<br>_
<br>
**Update Balance**<br>
The body of the request should be a JSON object with the following format:<br>
_{<br>
  "login": "string",<br>
  "USD_Balance": 0<br>
}<br>_
<br>
**Delete User:**<br>
The User to be deleted should be appended to the URL in place of {UserToDelete} and the body of the request should be a JSON object with the following format:<br>
_{<br>
  "login": "string"<br>
}<br>_
Login being the Login parameter of the user making the call and UserToDelete being the Login value of the user to delete.
