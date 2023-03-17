using zoo_mgmt.Models.Database;

namespace zoo_mgmt.Data
{
    public static class SampleZooKeepEnclosureDuty
    {
        public const int NumberOfDuties = 20;

        public static IEnumerable<ZooKeepEnclosureDuty> GetDuties()
        {
            return Enumerable.Range(0, NumberOfDuties).Select(CreateRandomDuties);
        }

        private static ZooKeepEnclosureDuty CreateRandomDuties(int index)
        {
            List<ZooKeeper> Data = SampleZooKeeper.GetZooKeepers().ToList();
            List<Enclosure> EnclosureData = SampleEnclosures.GetEnclosures();

            Random rnd = new Random();

            int zooKeepRandomIndex = rnd.Next(0,10);

            int rndIndex = rnd.Next(0, 5);

            return new ZooKeepEnclosureDuty
            {
                
                ZooKeeper = Data[zooKeepRandomIndex],
                Enclosure = EnclosureData[rndIndex]

            };
        }
    }
}