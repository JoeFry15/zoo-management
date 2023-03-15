using zoo_mgmt.Models.Database;

namespace zoo_mgmt.Data
{
    public static class SampleEnclosure
    {
        public const int NumberOfEnclosures = 5;

        private static readonly IList<IList<string>> Data = new List<IList<string>>
        {
            new List<string> { "Lion Enclosure", "10" },
            new List<string> { "Aviary", "50" },
            new List<string> { "Reptile House", "40" },
            new List<string> { "Giraffe Enclosure", "6" },
            new List<string> { "Hippo Enclosure", "10" },
        };

        public static IEnumerable<Enclosure> GetEnclosure()
        {
            return Enumerable.Range(0, NumberOfEnclosures).Select(CreateRandomEnclosure);
        }

        private static Enclosure CreateRandomEnclosure(int index)
        {
            return new Enclosure
            {
                EnclosureName = Data[index][0],
                Size = int.Parse(Data[index][1]),
            };
        }
    }
}