namespace API.Entities;

// You can think of each entity as a separate table in a database.
// So here, for example, we have the AppUser table, uses the C# class to represent an entry in a table in a database.
// The objects we make of this class will be a row in the AppUser table in the database.
// Entity Framework needs public properties to function, so ensure your properties are public.
// Each property will be a column in our table. 

public class AppUser
{
  // By calling this property 'Id', the compiler knows that this will be the primary key.
  // Also, because it is an integer, it will be auto-incremented each time a new record is added to the DB.
  public int Id { get; set; }
  public required string UserName { get; set; }
}
