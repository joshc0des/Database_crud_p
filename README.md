# WPF Database CRUD Application with EF Power Tools
This is a Windows Presentation Foundation (WPF) application that allows users to perform CRUD operations on a database containing information about dogs, toys, owners, and dog-toy associations. The app was assigned by my professor for my MIS-3033 college course. It was developed using Entity Framework (EF) Power Tools.

## Database Schema
The database schema consists of four tables:

- The "Dogs" table
- The "Toys" table
- The "Owners" table
- The "DogToys" table

## Application Features
Using the WPF interface, users can perform the following CRUD operations:

Create: Users can add a new dog to the database by filling out a form that includes fields for the dog's name, breed, and age. They can also add a new toy by entering its name, type, and price.
Read: Users can view all the dogs, toys, owners, and dog-toy associations that are currently in the database. They can search for specific records using filters, such as by breed or toy type.
Update: Users can edit existing records, such as updating a dog's age or changing a toy's price.
Delete: Users can remove records from the database, such as deleting a dog or toy that is no longer needed.

## EF Power Tools
EF Power Tools were used to generate code for the data access layer of the application. This included generating entity classes for each table in the database, as well as a context class for managing database interactions.

The code was generated using the EF Power Tools Reverse Engineer feature, which allowed me to easily create the code based on the existing database schema.

## Conclusion
Overall, this WPF application provides a user-friendly way to manage data related to dogs, toys, owners, and dog-toy associations. The use of EF Power Tools made it easy to generate the necessary code for interacting with the database, while the WPF interface provides an intuitive way for users to interact with the data.
