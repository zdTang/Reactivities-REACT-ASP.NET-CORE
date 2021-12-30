# Do the first migration

1. in the Data project, create DataDbContext file and its constructor
2. create relevant Data Model
3. Go to the startup project and Register the DbContext class(Need install Dependency as well.  the EntityFrameworkCore.Design has everything)
4. Both the Data and Startup Projects need those Dependencies.!

# Update database

this project put code at the Startup.cs, I don't think it is good enough.
the Rocky project looks better.

# the Location of SQLITE database

Notice the location of SQLITE database
Seeding database.

# CORS policy

https://stackoverflow.com/questions/62933791/why-web-api-not-giving-the-cors-error-in-browsers-like-chrome-and-edge-and-in-th

# MEDIATOR pattern
all classes only depends on mediator other than other cless.  
A good example is Airport communication tower  
https://www.programmingwithwolfgang.com/mediator-pattern-in-asp-net-core-3-1/

# Marker interface
In the class: List, they used  Empty interface  

https://stackoverflow.com/questions/7552677/are-empty-interfaces-code-smell  
https://stackoverflow.com/questions/1023068/what-is-the-purpose-of-a-marker-interface  
https://stackoverflow.com/questions/55761661/what-is-an-empty-interface-used-for/55761700

# In in Generic 

https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/in-generic-modifier

does this article make sense: https://agirlamonggeeks.com/2019/05/29/vs-in-generic-interfaces-contravariance-vs-covariance-the-easier-part-1/
 
# Mediator

As in the BaseApiController, we have no way to inject the class, so that we use "httpContext" to access the Service 