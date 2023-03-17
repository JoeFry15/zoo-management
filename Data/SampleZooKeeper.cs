using zoo_mgmt.Models.Database;

namespace zoo_mgmt.Data
{
    public static class SampleZooKeeper
    {
        public const int NumberOfZooKeepers = 10;

        public static List<IList<string>> Data{get;set;}

        private static List<IList<string>> getZooKeeper()
        {
            Data = new List<IList<string>>
            {
                new List<string> { "Sophia" },
                new List<string> { "William" },
                new List<string> { "Olivia" },
                new List<string> { "James" },
                new List<string> { "Emma" },
                new List<string> { "Ethan" },
                new List<string> { "Ava" },
                new List<string> { "Alexander" },
                new List<string> { "Isabella" },
                new List<string> { "Benjamin" },
            };
            return Data;
        }

        public static IEnumerable<ZooKeeper> GetZooKeepers()
        {
            return Enumerable.Range(0, NumberOfZooKeepers).Select(CreateRandomZooKeeper);
        }

        private static ZooKeeper CreateRandomZooKeeper(int index)
        {
            List<IList<string>> Data = getZooKeeper();

            return new ZooKeeper
            {
                Name = Data[index][0],
            };
        }
    }
}