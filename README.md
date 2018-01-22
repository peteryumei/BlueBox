# BlueBox

BlueBox Movie Rental solution based on Visual Studio 2017 and ASP.NET 4.6.1 Web API Template

The Bluebox Visual Studio solution has six projects:
  BlueBox.API
  BlueBox.Services
  BlueBox.Repositories
  BlueBox.Models
  BlueBox.Common
  BlueBox.Tests

BlueBox.API provides all the controllers for Web API, only AccountController and MovieController are implemented

It uses "Individual User Accounts" for Authentication: Users login and profiles are stored in a SQL Server database (App_Data folder), 
Users also have option to sign in using their existing account for Facebook, Twitter, Google, Microsoft.

To create an account you post to the /api/account/register endpoint – that maps to AccountController.Register

endpoint: http://localhost:65291/api/Account/Register
method: POST
body:
{
  "Email": "petermei@yahoo.com",
  "Password": "Passw0rd#",
  "ConfirmPassword": "Passw0rd#"
}

To add a movie
endpoint: http://localhost:65291/api/Movie
method: POST
body:
 {
    "title": "Star War ",
    "genre": "Drama",
    "price": 3.99,
    "releaseDate": "1972-01-01"
 }
 
 To get a movie details:
 endpoint: http://localhost:65291/api/Movie/9
 method: GET
 
 To delete a movie
 endpoint: http://localhost:65291/api/Movie/9
 method: DELETE
 
 To Update a movie
 endpoint: http://localhost:65291/api/Movie/9
 method: PUT

API Help page:
http://localhost:65291/Help



