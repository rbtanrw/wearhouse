using Microsoft.AspNetCore.Mvc;
using WearHouse.Data;
using WearHouse.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WearHouse.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<UserController>
        [HttpGet]
        public List<DataUser> Get()
        {
            var UserList = _context.DataUsers
                .Select(x => new DataUser
                {
                    UserID = x.UserID,
                    Name = x.Name,
                    Email = x.Email,
                    Password = x.Password,
                });
            return UserList.ToList();
        }

        // GET api/<UserController>/5
        [HttpGet("{Email}, {Password}")]
        public ActionResult<DataUser> Get(string Email, string Password)
        {
            var user = _context.DataUsers.FirstOrDefault(x => x.Email == Email);
            if (user == null)
            {
                return NotFound("User not found");
            }
            
            if (user.Password != Password)
            {
                return BadRequest("Incorrect password");
            }

            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost("{Name}, {Email}, {Password}")]
        public async Task<ActionResult> PostAsync(string Name, string Email, string Password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(_context.DataUsers.Any(x => x.Email == Email))
            {
                return BadRequest("User already exist");
            }

            var i = 0;
            foreach(DataUser u in _context.DataUsers)
            {
                i++;
            }

            var user = new DataUser
            {
                UserID = string.Concat("U", i.ToString("D4")),
                Name = Name,
                Email = Email,
                Password = Password,
            };

            _context.DataUsers.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
