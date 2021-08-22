# SQL Injection

Make sure you have a database set up as per in the connection string in appsettings.json. You will need a User on the DB called WebSiteUser and run the SQL from the DbCreation.SQL file to create the necessary table, data and assign permissions.

Set a breakpoint in the Index action of the Movie controller to show what is in the genre parameter.

Run the web app.

Go to this URL to see all the movies:

https://localhost:5001/movies

Go to this URL to see movies filtered by genre:

https://localhost:5001/movies?genre=Comedy

Go to this URL to show that we are susceptible to SQL injection:

https://localhost:5001/movies?genre=Comedy%27%20OR%20%27true%27%20%3D%20%27true

Run this URL to drop the Movie table:

https://localhost:5001/movies?genre=Comedy%27%3Bdrop%20table%20Movie%3B

Set the data up again and show how using a parameterised query helps guard against SQL injection.

Also, mention validation and using users with least privilege can help... Security in depth.

# Broken Authentication

Run the web app and go to the URL:

https://localhost:5001/account/index

Login with the following account details:

Username: Phil
Password: Password1!

Show you can't change the URL to be HTTP:

http://localhost:5001/account/index