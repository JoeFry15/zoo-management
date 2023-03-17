using zoo_mgmt.Models.Database;

namespace zoo_mgmt.Models.Response
{
    public class ZooKeeperResponse
    {
        private readonly ZooKeeper _zooKeeper;

        public ZooKeeperResponse(ZooKeeper zooKeeper)
        {
            _zooKeeper = zooKeeper;
        }
        public int Id => _zooKeeper.ZooKeeperId;
        public string Name => _zooKeeper.Name;
    }
}