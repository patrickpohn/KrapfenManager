using System;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : Controller
    {
        // GET
        public async Task<IActionResult> Index()
        {
            return Ok("User");
        }
        
        [HttpPost]
        public IActionResult AddUser([FromBody]User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);

            var existingUser = BL.BL.Instance.GetUserByName(user.Name);
            
            if (existingUser != null) return Ok(existingUser);
            user.Id ??= Guid.NewGuid();
            return Ok(BL.BL.Instance.AddUser(user));
        }
        
        public IActionResult GetUser([FromBody]Guid id)
        {
            return Ok(BL.BL.Instance.GetUserById(id));
        }

        public IActionResult GetAllUser()
        {
            return Ok(BL.BL.Instance.GetAllUser());
        }

        [HttpPost]
        public IActionResult EditUser([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values);
            if (BL.BL.Instance.GetUserById(user.Id) == null) return NotFound("No User Found");
            return Ok(BL.BL.Instance.UpdateUser(user));
        }

        [HttpPost]
        public IActionResult DeleteUser([FromBody]User user)
        {
            if (user.Id == null) return BadRequest("No Id");
            BL.BL.Instance.DeleteUser(user);
            return Ok("User deleted");
        }
    }
}