using zoo_mgmt.Models.Request;
using zoo_mgmt.Models.Database;

using NLog;

namespace zoo_mgmt.Repositories
{
    public interface IZooKeepersRepo
    {
        ZooKeeper GetById(int id);

        List<ZooKeeper> GetByPageInfo(ZooKeeperSearchRequest search);
        ZooKeeper Add(AddZooKeeperRequest newZooKeeper);
    }

    public class ZooKeepersRepo : IZooKeepersRepo
    {
        private static readonly NLog.ILogger Logger = LogManager.GetCurrentClassLogger();
        private readonly ZooManagementDbContext _context;

        public ZooKeepersRepo(ZooManagementDbContext context)
        {
            _context = context;
        }

        public List<ZooKeeper> GetByPageInfo(ZooKeeperSearchRequest search)
        {
            int firstResult = 1 + (search.PageSize * (search.Page - 1));

            IEnumerable<ZooKeeper> zooKeeperData = _context.ZooKeepers;

            if (search.Name != null)
            {
                zooKeeperData = zooKeeperData
                .Where(i => i.Name == search.Name);
            }

            var zooKeeperDataPage = search.OrderBy != null ? zooKeeperData
                .Skip(firstResult - 1).Take(search.PageSize)
                .OrderBy(o => o.GetType().GetProperty(search.OrderBy).GetValue(o))
                .ToList()
                :
                zooKeeperData
                .Skip(firstResult - 1).Take(search.PageSize)
                .OrderBy(o => o.Name)
                .ToList();

            Logger.Info("ZooKeeper search page generated.");

            return zooKeeperDataPage;
        }

        public ZooKeeper GetById(int id)
        {
            return _context.ZooKeepers
                .Single(zooKeeper => zooKeeper.Id == id);
        }

        public ZooKeeper Add(AddZooKeeperRequest newZooKeeper)
        {
            // var getEnclosureCount = _context.Animals.Where(e => e.Enclosure == newAnimal.Enclosure).Count();

            // Dictionary<string, int> Enclosures = new Dictionary<string, int>{
            //      {"Lion Enclosure", 10},
            //      {"Aviary", 50},
            //      {"Reptile House", 40},
            //      {"Giraffe Enclosure", 6},
            //      {"Hippo Enclosure", 10},
            // };

            // if (!Enclosures.ContainsKey(newAnimal.Enclosure))
            // {
            //     Logger.Warn("User attempted to add an animal with an enclosure that does not exist.");
            //     throw new Exception("This Enclosure does not exist!!");
            // }


            // if (getEnclosureCount >= Enclosures[newAnimal.Enclosure])
            // {
            //     Logger.Warn("User attempted to add an animal to a full enclosure.");
            //     throw new Exception("Too many animals in Enclosure!!");
            // }


            var insertResponse = _context.ZooKeepers.Add(new ZooKeeper
            {
                Name = newZooKeeper.Name,
            });
            _context.SaveChanges();

            return insertResponse.Entity;
        }
    }
}