using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication71.Models;

namespace WebApplication71.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            var data = _repository.GetAllUsers();
            return Ok(data);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            var data = _repository.GetUserByID(id);
            if (data == null)
                return NotFound("no record found");
            return Ok(data);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Post(User user)
        {
            var data = _repository.AddUser(user);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host +
                "/" + HttpContext.Request.Path + "/" + user.Id, data);
        }

        [HttpPut]
        [Route("api/[controller]")]
        public IActionResult Put(User user)
        {
             bool f=_repository.UpdateUser(user);
             var data = _repository.GetAllUsers();
            if (f == true)
            {
                return Ok(data);
            }
             else
            {
                return NotFound("no record found");
            }
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public void Delete(int id)
        {
            _repository.DeleteUser(id);
             
        }
    }
}
