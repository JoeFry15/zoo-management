using Microsoft.AspNetCore.Mvc;
using zoo_mgmt.Models.Request;
using zoo_mgmt.Models.Response;
using zoo_mgmt.Repositories;
using zoo_mgmt.Models.Database;

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

        // [HttpGet("search/{searchQuery}/{pageSize}/{pageNumber}")]
        // public ActionResult<List<Animal>> Search([FromRoute] string searchQuery, int pageSize, int pageNumber)
        // {
        //     var animal = _animals.GetByPageInfo(searchQuery,pageSize, pageNumber);
        //     return animal;
        // }


        [HttpGet("search")]
        public ActionResult<List<AnimalAndEnclosureResponse>> Search([FromQuery] AnimalSearchRequest search)
        {
            var animal = _animals.GetByPageInfo(search);
            return animal;
        }


        [HttpGet("species")]
        public ActionResult<List<string>> ListSpecies()
        {
            var animal = _animals.GetListOfSpecies();
            return animal;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] AddAnimalRequest newAnimal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var animal = _animals.Add(newAnimal);
                var url = Url.Action("GetById", new { id = animal.Id });
                var responseViewModel = new AnimalResponse(animal);
                return Created(url, responseViewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("enclosure/{id}")]
        public ActionResult<List<AnimalAndEnclosureResponse>> EnclosureGetById([FromRoute] int id)
        {
            var animal = _animals.GetAnimalsInEnclosure(id);
            return animal;
        }
    }
}
