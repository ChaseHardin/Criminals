# Criminals

The goal of this kata is to become familiar with C# .Net Core + ASP .Net Core + Entity Framework + SQL Server + Docker tech stack and to work through the initial pain of project setup, multiple layers of testing (including contract testing), etc. prior to the start of our client’s billable project.  

As a court administrator <br>
I want to add a new case file <br>
So that the courts can track it<br>


As a defendant <br>
I want to look up a case file <br>
So that I know how much to pay on my fine <br>


# Acceptance Criteria
Given a case file does not exist<br>
When a new case file is submitted<br>
And contains<br>
* Case title<br>
* Case description<br>

Then the database is updated with the case file<br>
And contains<br>
* Case title<br>
* Case description<br>
* Docket number<br>
* Open date<br>


Given an existing case file<br>
When a user requests the case file<br>
Then the case file is returned<br>

Given a case file does not exist<br>
When a user requests the case file<br>
Then a “Resource Not Found” response is returned<br>

# Technologies
Dotnet Core (2.1) - https://docs.microsoft.com/en-us/dotnet/core/ <br>
Asp.net Core (2.1) - https://docs.microsoft.com/en-us/aspnet/core/ <br>
Entity Framework Core (2.1) - https://docs.microsoft.com/en-us/ef/core/ <br>
SQL Server and Docker (2017) - https://hub.docker.com/r/microsoft/mssql-server-linux/ <br>


