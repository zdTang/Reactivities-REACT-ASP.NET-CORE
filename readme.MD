# unit of Work Pattern

https://dotnettutorials.net/lesson/unit-of-work-csharp-mvc/

# Repository pattern

https://dotnettutorials.net/lesson/repository-design-pattern-csharp/

# Looks like the "Migration" folder will be crated besides the Dbcontext class file

need to install microsoft.entityframework.design package first
When run "dotnet ef" command, I am in the root folder

## changed gitignore. to prevent syn "appsettings.json" file. but don't know it works. For security, we should not push "appsettings.json" file to the Git repository.

# About Typescript pro and con

Complicated to use typescripts and now it's much improved and it's much more pleasurable to work with in react and if you come from a strongly typed language such as C sharp for example then you will really like using TypeScript I used to hate JavaScript with a passion because of the annoyance of being able to make such silly mistakes and spend ages trying to debug the application let's type script changed all of that for me and I much prefer to work with it and normal JavaScript it can be annoying though because there is of course more up front code we need to tell our types what type they are we need to create interfaces or types to tell how compiler about what types we're using also some third party libraries do not have TypeScript definition files included with them so I included it in the TypeScript rocks section and it also comes in the TypeScript is annoying every now and again you'll come across a package that you want to use that does not include a TypeScript definition file now there is a strong TypeScript community and it's quite unusual to find a package that you want to use that does not have a TypeScript definition file it either will come with the package itself or the community have created a TypeScript definition file fallout package and it's easy enough just to add it along side the package that we're using we need to do this a few times in this application and it's not a big deal and the other thing that you might find it annoying about typescripts is that the strict mode is because that means it's doing its job and it's protecting you from assigning something that could be null to something and even with these minor annoyances in TypeScript it really does pay for itself yes there is a little bit more upfront code yes sometimes fed party libraries don't have TypeScript definition files and yes strict mode can be somewhat annoying at times but if typescript catches just one time poo that you're about to make that it's already paid for itself most likely as if you don't catch that error until runtime then you've gotta go back through your code where you get no warnings about what you've done wrong and you have to find that i to give.

# CORS policy

as the Server and the Client comes from different URL

# Semantic - ui

not this one: https://semantic-ui.com/
this one: https://react.semantic-ui.com/usage

# 4-3 CQRS

CQRS stands for Command and Query Responsibility Segregation  
Read this: https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs

# 4-4 Creating our first Query handler

using a third party library called "MediatoR"  
https://github.com/jbogard/MediatR  
Before, our Api controller depends on "dbContext", By now, the "Mediator" depends on "dbContext"  
and Api controller depends on "Mediator"  
About mediator design pattern, see here:  
https://www.dofactory.com/net/mediator-design-pattern

# 4-5 - Thin controllers in the API

Move DI operation into the Base class. understand how inherit works.  
Understand how to assess Services via Http.context

# 4-7 - Adding a Create handler

Create a "create" Handler, understand how those Asynchronous operations.

# 4-9 - Adding AutoMapper

Install autoMapper,
Dependency Injection to Services
Creating Mapping profile
use Mapper

# 4-11 - Startup class housekeeping

create class extension.
this is an good demo to use extension.

# 4-12 - Cancellation tokens

watch his tutorial again if using cancellation token is necessary.
It seems the cancellation token is used when Client cancel the request.

# 5-3 - Adding an Activity interface

for any Json, can go to website of "json to ts" to generate interface automatically.

# 5-5 - Adding some style to the nav bar

Add style to component. Semantic ui is not very good, because they are not updated.  
can implement Max's approach

# 5- 7 - Creating an activity list

Learn how to use interface. and how to use semantic React UI components.  
As I did before, I replaced Button component with native "button"

# 5-8 - Creating a details view

the Button component still causes Error even after I updated it to the latest version.
will fix this issue after finished this tutorial

# 5-9 - Creating an Activity form

add a form, without wire up any logic.

# 5-10 - Selecting an activity to view

wire up single activity  
be care of prop interface  
will use useContext to do this section as it pass props through multiple components.

# 6-2 - Setting up axios

notice how to use axios and promise

# 7-6 - MobX strict mode
https://mobx.js.org/actions.html

# 7-10 - Using a Javascript map object to store the activities

https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects



# 8-3 - Adding routes.mp4

## "exact" key word to match 
<Route exact path="/" component={HomePage} />

# 8-4 - Adding nav links

Notice how use NavLink to replace a Button click Event  
At this moment, the single Activity cannot be loaded properly.

# 8-6 - Getting an individual activity

To display a single activity, first,check if it is in the Memory. then use AXIOS to fetch it from Server  
As we use Route to display Components, so that some Click Event which was used to toggle View's display can be removed  
At this moment, the single Activity cannot be loaded properly.

# 8-8 - Adding the edit activity route

concel button doesn't work, looks like the route is not correct.
# 9-7 - Adding the activity filter component

for the original calendar's style, it doesn't fit our output. so that we can find its style's class name, and create another same-name class style to overwritten partial of its original style, such as width.

# 10-2  - Validation with data annotations

add notion on the Domain is easy. the framework can valid it. for example, if we add [Required] on one field, the Framework will check it if we add a [webapi] attribute on our Controller. and we don't need to use state.valid().
But this validate approach is not we want.


# 10-3 

Be aware how to use fluentValidation to validate a batch of fields

# 10-4 null response
if we request a non-exist Activity, the Controllor cannot find the record and will return 204,  204 is not an Error.   for this scenario, what kind of infromation are we suppose to propmt?  

1. approach one: add code at Controller to validate result.
2. Exception is a little heavy in data-flow, we should avoid using it. here, if we throw a exception and don't handle it, will crush the application.

# 10-5 Handling API Error responses part 2

1, Add Result class to wrap result for responding.
2 Approach one. Handle it within Controllor
3,Move the Handle Result logic to the Base controllor--GOOD APPROACH


# 10-6
The Create-Command, originally, it returns nothing. but we can let it return something.

Debug what the Unit Represent?

# 10-8 - Handling exceptions

1. Learn how to create a custom Middleware
2. how to Serialize a class to JSON
3, how to apply a customeMiddleware 


# 12-2 - Adding a user entity

1. Install EntityFramework.identity package
2. Add several fields ---will see the magic ..

# 12-4 - Configuring Identity in the Startup class

When VS import Package for you, be careful, it could be a wrong resource. 
it could cause very tricky issue.

1. Create Extension method.
2. use Extension method to DI Identity and Authorization Services.

# 12-5 - Adding seed users

Seeding + Migration
The another Seeding solution is add logic on the Middleware, which one is better ?

# 12 -7 - Adding an account controller
what is Login?
Login is a process when an User connect to a server with an ID, and the server granted the User some authority based on the ID. Usually, the user will offer the user a Token. 
1. User tell Server, I am coming, and my name is ID....   
2. Server validate ID, and give the User a Token(Base on the TD's group) ....
3. User use the Token to make the sequential request.


# 12-8  Jwt
what is Claim
https://docs.microsoft.com/en-us/aspnet/core/security/authorization/claims?view=aspnetcore-6.0
what is JWT, How to decrypt it?
https://jwt.io/

AddAuthentication and UseAuthentication: https://pretagteam.com/question/what-exactly-is-useauthentication-for


# 12-11 - Storing secrets in development
Secret Manager

https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows

Don't know how to use "Secret Manager"

# 12-12 - Creating an auth policy

Here, we create and config authentication at middleware level.  
For the first time user login, we should let him in and grant him a token.  then all other endpoints need this token as a ticket.

How UserManager been injected?   it is injected by addIdentityCore().

https://stackoverflow.com/questions/55361533/addidentity-vs-addidentitycore


 