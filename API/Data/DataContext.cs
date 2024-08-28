using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

// Using the primary constructor to reduce boilerplate code
public class DataContext(DbContextOptions options) : DbContext(options)
{
  // Because this property is called 'Users', this is also what the linked table will be called in the DB.
  // DbSet is a generic type that can store types of entities. He were store the AppUser entity, as created in the AppUser.cs file.
  public DbSet<AppUser> Users { get; set; }
}

/*
The DbContext class is the primary class we use to directly interact with the database: It serves as the link between our entities and the database.
It serves as the conversion tool between code and SQL queries.
Entity Framework Features:
- Querying - allows us to query the database
- Change Tracking - track changes that have occurred to the database
- Saving - save changes to the database
- Concurrency - protect overwriting changes to the database made by another user at the same time
- Transactions - provides automatic transaction management
- Caching
- Built-in Conventions
- Configurations
*/
