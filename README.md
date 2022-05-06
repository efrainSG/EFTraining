# EF Training

## First steps
Four projects were created: **Data** and **Domain** are *class libraries* for .NET 5.0 while **UI** is a *Console application* and **Tests** is a *Unit Test* project with NUnit and Moq.

The Data project has two classes:
  * **Samurai**: The most important properties are *Id* and *Name*
  * **Quote**: The same properties that **Samurai** class.

Some new classes were added to the Data project:
  * **BattleSamurai**: Contains Ids that points to *Samurai* and *Battle* classes, and an additional property, **DateJoined**, known in EF as *payload*
  * **Horse**: To perform a One-to-one relationship. 

## Working with EF Migrations

from the Package Manager Console, ensure that the selected project is the Data and then execute the following commands:
1. **add-migration init** /* where *init* is the name for the migration */
2. **update-database -verbose** /* to update the database using the connection string specified en the Data project, the classes in the migration created through the classes defined preiously in the project. The parameter *-verbose* allows to display the whole output of the command */

## Notes

1. I'm implementing Github Actions and at this moment I have to create a initial version of my solution, push it into the Github repository, and then I have to create my initial workflow. Finally I can initialize Gitflow in my project in order to have the workflows for each branch created subsequently.