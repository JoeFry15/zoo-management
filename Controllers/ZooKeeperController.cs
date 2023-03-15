using Microsoft.AspNetCore.Mvc;
using zoo_mgmt.Models.Request;
using zoo_mgmt.Models.Response;
using zoo_mgmt.Repositories;
using zoo_mgmt.Models.Database;

namespace zoo_mgmt.Controllers
{
    [ApiController]
    [Route("/zookeeper")]
    public class ZooKeeperController : ControllerBase
    {
        private readonly IZooKeepersRepo _zooKeeper;

        public ZooKeeperController(IZooKeepersRepo zooKeeper)
        {
            _zooKeeper = zooKeeper;
        }

        [HttpGet("{id}")]
        public ActionResult<ZooKeeperResponse> GetById([FromRoute] int id)
        {
            var zooKeeper = _zooKeeper.GetById(id);
            return new ZooKeeperResponse(zooKeeper);
        }


        [HttpGet("search")]
        public ActionResult<List<ZooKeeper>> Search([FromQuery] ZooKeeperSearchRequest search)
        {
            var zooKeeper = _zooKeeper.GetByPageInfo(search);
            return zooKeeper;
        }


        // [HttpGet("species")]
        // public ActionResult<List<string>> ListSpecies()
        // {
        //     var animal = _animals.GetListOfSpecies();
        //     return animal;
        // }

        // [HttpPost("add")]
        // public IActionResult Add([FromBody] AddAnimalRequest newAnimal)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     try{
        //         var animal = _animals.Add(newAnimal);
        //         var url = Url.Action("GetById", new { id = animal.Id });
        //         var responseViewModel = new AnimalResponse(animal);
        //         return Created(url, responseViewModel);
        //     }catch (Exception e){
        //         return BadRequest(e.Message);
        //     }  
        // }
    }
}
