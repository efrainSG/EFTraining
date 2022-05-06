# EF Training

## First steps
Four projects were created: **Data** and **Domain** are *class libraries* for .NET 5.0 while **UI** is a *Console application* and **Tests** is a *Unit Test* project with NUnit and Moq.

The Data project has two classes:
  * **Samurai**: The most important properties are *Id*
  * **Quote**

## Working with EF Migrations

from the Package Manager Console, ensure that the selected project is the Data and then execute the following commands:
1. **add-migration init** /* where *init* is the name for the migration */
2. **update-database -verbose** /* to update the database using the connection string specified en the Data project, the classes in the migration created through the classes defined preiously in the project. The parameter *-verbose* allows to display the whole output of the command */