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

# XSS - Cross Site Scripting

Go to this URL:

https://localhost:5001/xss

Enter some normal text and submit to show that the next page just displays the text input

Now go back and enter this text to show that it runs as js when submitted:

<script>alert("Boom!")</script>

Show the page source and how the script element looks.

Update the XSS/SubmittedText view to html encode the text...

<div>@Html.Raw(Html.Encode(Context.Session.GetString("inputtext")))</div>

Restart the app and put the alert in the submitted text again.

Show the encoding in the source for the page.

Talk about how Html.Raw should never be used with untrusted data (i.e. anything user input)

Take out the encoding again so it's unsafe.

Show the xssCookie in the browser.

Show that you can access the cookie value using the following javascript code:

<script>
function getCookie(cookieName) {
  let cookie = {};
  document.cookie.split(';').forEach(function(el) {
    let [key,value] = el.split('=');
    cookie[key.trim()] = value;
  });
  return cookie[cookieName];
}
alert(getCookie("xssCookie"));
</script>

Show good practice if you don't need to access cookies on the client side, set to httponly and secure in XssController.

Things that you can do with XSS - Anything you can do in javascript!!
Might just be an inconvenience.
Might not be visible.
Inc. Changing URLs, changing submit button actions to send content to web service before doing normal submit.

Remember could be input by somebody else (think Facebook or Twitter feed)

# Broken Authentication

Run the web app and go to the URL:

https://localhost:5001/account/index

Login with the following account details:

Username: Phil
Password: Password1!

Show you can't change the URL to be HTTP:

http://localhost:5001/account/index

Show an invalid login shows the text 'Invalid Account'.

Show the cypress test (cypress/integration/brute-force-login/brute-force.spec.js).
Explain login details would be loaded from data.

Run test by:
Running the web app.
In a terminal, go to the MvcMovie folder.
run "npm test" command in terminal.
in the Cypress UI, run the test.

Show how fast the test is going through invalid accounts but stops at valid login details.

Show how a Backoff in the controller gradually slows down attempts.

Show how a cutoff after x attempts stops a brute force attack entirely.

