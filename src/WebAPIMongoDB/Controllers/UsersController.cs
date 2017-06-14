using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using WebAPIMongoDB.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIMongoDB.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        DataAccess objds;

        public UsersController(DataAccess d)
        {
            objds = d;
        }

        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return objds.GetUsers();
        }

        [HttpGet("{id:length(24)}")]
        public IActionResult Get(string id)
        {
            var user = objds.GetUser(new ObjectId(id));
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Users p)
        {
            objds.Create(p);
            return new OkObjectResult(p);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, [FromBody]Users p)
        {
            var recId = new ObjectId(id);
            var user = objds.GetUser(recId);
            if (user == null)
            {
                return NotFound();
            }

            objds.Update(recId, p);
            return new OkResult();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = objds.GetUser(new ObjectId(id));
            if (user == null)
            {
                return NotFound();
            }

            objds.RemoveUser(user.Id);
            return new OkResult();
        }
    }
}
