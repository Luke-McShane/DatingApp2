using System;
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using API.Data;

namespace API.Controllers;

// This controller returns JSON data, not a HTML page (as in traditional MVC).
// Its function is to handle HTTP requests and return appropriate data from the relevant database(s).
[ApiController]
[Route("api/[controller]")] // Endpoint would be /api/users as 'users' replaces [controller]
public class UsersController(DataContext context) : ControllerBase
{
  // Within our controller we can now create the API endpoints that the user will use to make API requests.
  [HttpGet]
  public ActionResult<IEnumerable<AppUser>> GetUsers()
  {
    var users = context.Users.ToList();
    return users;
  }

  [HttpGet("{id:int}")] // api/users/1 (1 is an example of an id)
  public ActionResult<AppUser> GetUser(int id)
  {
    var user = context.Users.Find(id);

    if (user == null) return NotFound();

    return user;
  }
}
