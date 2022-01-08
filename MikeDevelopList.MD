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

# Mediator

Notice those Handler, some are "query", some are "Command"
Mediator sometimes Send a Query, sometimes Send a Command
Understand CQRS pattern !

# 4-8 Add Edit hander

Each handler is either a Command or Query
In the Controllor, we just "Send" a Query or Command, the Handler we defined will deal with for us

# AUTOMAPPER

1. about DI. for the automapper, we register it in the startup project APP, while we can inject it in all related libraries, such as Application project.


# IServiceCollection 

For those extension method, Is it necessary to return IServiceCollection ?

# 4-12 cancellationToken

watch his tutorial, and learn how to use cancellationToken.
For some use cases, maybe need long time to grab data from remote DB or processing data.  during the period. if the user who send the request cancel the request (close the browser or close the web page....), how the server react for this.

I found a example of Runtime error while static compile time cannot find Error.  ILogger !   if you use ILogger without specify the type, use ILogger<>, the complier cannot detect this error. But Runtime will report error

# 10-8  Validation summary

1, use custome Middleware to handle Exception  
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/write?view=aspnetcore-6.0  
2, validate coming Quest:  happens during the Model-binding  
  a. FluentValidation // https://fluentvalidation.net/  
  b. Data Model Notation
3, validate Response: we can customize the reponse Information based on our requirement:   
  For CURD, for Get, Update, Edit operations, the framework need find the specified Activity within the database, if no found, by default, the Framework will return null and it is a 204.   But we can change it and return NotFound() 

4. Handle response, we should know all possible return value and dicide what kind of data we will tell the client. we as developer will define how to  return status.I think we can also work with the front end. to send a detailed  information to them. for example, if we want find specified Activity, if not find ,we can return NULL 204, We can also return NotFound. we can create a Response Class to standardize the return object. 


