using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserList.Models;
using Microsoft.EntityFrameworkCore;
using ReactTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserList.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UsersContext db;
        public UsersController(UsersContext context)
        {
            db = context;
        }

        //GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserFromClient>>> Get()
        {
            return await db.Users.Select(x => UserConverter.ToClientUser(x)).ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserFromClient>> Get(int id)
        {
            User user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
            
            if (user == null)
                return NotFound();

            return new ObjectResult(UserConverter.ToClientUser(user));
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<UserFromClient>> Post(UserFromClient clientUser)
        {
            if (clientUser == null)
                return BadRequest();

            User user = UserConverter.ToUser(clientUser);
            db.Users.Add(UserConverter.ToUser(clientUser));
            await db.SaveChangesAsync();
            return Ok(clientUser);
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserFromClient>> Put(UserFromClient clientUser) 
        {
            if (clientUser == null)
                return BadRequest();

            if (!db.Users.Any(u => u.Id == clientUser.Id))
                return NotFound();

            db.Update(UserConverter.ToUser(clientUser));
            await db.SaveChangesAsync();
            return Ok(clientUser);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(UserFromClient clientUser)
        {
            if (clientUser == null)
                return BadRequest();

            if (!db.Users.Any(u => u.Id == clientUser.Id))
                return NotFound();

            db.Remove(UserConverter.ToUser(clientUser));
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
