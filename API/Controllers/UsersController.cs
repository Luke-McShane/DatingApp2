using System;
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

// This controller returns JSON data, not a HTML page (as in traditional MVC).
// Its function is to handle HTTP requests and return appropriate data from the relevant database(s).
[ApiController]
[Route("api/[controller]")] // Endpoint would be /api/users as 'users' replaces [controller]
public class UsersController(DataContext context) : ControllerBase
{
  // Within our controller we can now create the API endpoints that the user will use to make API requests.
  // Made the code asynchronous which enables multiple requests to be handled concurrently.
  // We make the code asynchronous by wrapping the ActionResult in a task
  [HttpGet]
  public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
  {
    var users = await context.Users.ToListAsync();
    return users;
  }

  [HttpGet("{id:int}")] // api/users/1 (1 is an example of an id)
  public async Task<ActionResult<AppUser>> GetUser(int id)
  {
    var user = await context.Users.FindAsync(id);

    if (user == null) return NotFound();

    return user;
  }
}

/*
ASYNCHRONOUS PROGRAMMING

- There must be an await keyword in the code body when you use the async keyword to specify the method is asynchronous.
- All the async keyword does is *enables* the await keyword..nothing more!
- The async suffix is needed to specify a method is asynchronous.
- An async method MUST return a Task or Task<T> (or void, but this is rare).
- A Task is something that runs in the background, freeing the CPU to continue executing code until the task is finished, and then returned. 
- We return a task because it is awaitable, meaning that it can run asynchronously.
*/