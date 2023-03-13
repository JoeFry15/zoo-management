using Microsoft.AspNetCore.Mvc;
using zoo_mgmt.Models.Request;
using zoo_mgmt.Models.Response;
using zoo_mgmt.Repositories;
//using MyFace.Repositories;

namespace zoo_mgmt.Controllers
{
    [ApiController]
    [Route("/animal")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalsRepo _animals;

        public AnimalsController(IAnimalsRepo animal)
        {
            _animals = animal;
        }

        [HttpGet("{id}")]
        public ActionResult<AnimalResponse> GetById([FromRoute] int id)
        {
            var animal = _animals.GetById(id);
            return new AnimalResponse(animal);
        }

        // [HttpGet("types")]
        // public ActionResult<List<string>> ListTypes()
        // {
        //     var animal = _animals;
        //     return new List<string> animal;
        // }

        [HttpPost("add")]
        public IActionResult Add([FromBody] AddAnimalRequest newAnimal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var animal = _animals.Add(newAnimal);

            var url = Url.Action("GetById", new { id = animal.Id });
            var responseViewModel = new AnimalResponse(animal);
            return Created(url, responseViewModel);
        }
    }
}
