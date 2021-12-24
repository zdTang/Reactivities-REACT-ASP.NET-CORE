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
