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
