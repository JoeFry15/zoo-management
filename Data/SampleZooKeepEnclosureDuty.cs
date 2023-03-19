using zoo_mgmt.Models.Database;

namespace zoo_mgmt.Data
{
    public class SampleZooKeepEnclosureDuty
    {
        private readonly ZooManagementDbContext _context;

        public SampleZooKeepEnclosureDuty(ZooManagementDbContext context)
        {
            _context = context;
        }
        public const int NumberOfDuties = 20;

        public IEnumerable<ZooKeepEnclosureDuty> GetDuties()
        {
            return Enumerable.Range(0, NumberOfDuties).Select(CreateRandomDuties);
        }

        private ZooKeepEnclosureDuty CreateRandomDuties(int index)
        {
            var ourEnclosures = _context.Enclosures;
            var ourZooKeepers = _context.ZooKeepers;

            Random rnd = new Random();

            int zooKeepRandomIndex = rnd.Next(1, 11);

            int enclosureRandomIndex = rnd.Next(1, 6);

            return new ZooKeepEnclosureDuty
            {

                ZooKeeper = ourZooKeepers.Where(b => b.ZooKeeperId == zooKeepRandomIndex).FirstOrDefault(),
                Enclosure = ourEnclosures.Where(b => b.EnclosureId == enclosureRandomIndex).FirstOrDefault(),
            };
        }
    }
}