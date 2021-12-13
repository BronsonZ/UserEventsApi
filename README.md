# LoyalHealth Backend Intern Assessment

This is my User Events API that I created for the LoyalHealth Backend Intern Assessment.

It is written in C# using the .NET 5 Web API framework. It uses Entity Framework 5 for interaction with the database. It contains three endpoints. GET /api/userevents returns a JSON with the most frequent event, the number of times that event occured, and the average number of times that action was taken per user. POST /api/userevents allows creation of an event by passing in the Usernmae of the user, the action they took (either copy, link, or print), and the data associated with that action, such as the link clicked or the text they copied. GET /api/userevents/{id} returns the specific event with the key value of {id}.

It connects to a local instance of Microsoft SQL Server Express 2019. The password for the SQL server is: My@Password

I believe it should satisfy all base deliverables as well as some of the bonuses. It utulizies dependency injection and the repository pattern when interacting with the database. I attempted to dockerize the project but ran into problems connecting to the database so I gave it up because I didn't want to waste too much time. I did not get around to creating automated unit tests but I have tested extensively manually using the swagger open api interface.

Thank you so much for looking at my project and if you have any questions pleare reach out.

Bronson Zell

bzell007@gmail.com