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

        [HttpPost("add")]
        public IActionResult Add([FromBody] AddZooKeeperRequest newZooKeeper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var zooKeeper = _zooKeeper.Add(newZooKeeper);
                var url = Url.Action("GetById", new { id = zooKeeper.Id });
                var responseViewModel = new ZooKeeperResponse(zooKeeper);
                return Created(url, responseViewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
