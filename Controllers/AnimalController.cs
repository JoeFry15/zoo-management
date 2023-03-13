using Microsoft.AspNetCore.Mvc;
using zoo_mgmt.Models.Request;
using zoo_mgmt.Models.Response;
//using MyFace.Repositories;

namespace zoo_mgmt.Controllers
{
    [ApiController]
    [HttpPost("add")]
        public IActionResult Add([FromBody] AddAnimalRequest newAnimal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var animal = _users.Create(newAnimal);

            var url = Url.Action("GetById", new { id = user.Id });
            var responseViewModel = new UserResponse(user);
            return Created(url, responseViewModel);
        }
}
