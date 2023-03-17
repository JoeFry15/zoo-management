 
 using zoo_mgmt.Models.Database;

namespace zoo_mgmt.Data
{
    public static class SampleEnclosures
    {
 
        public static List<Enclosure> EnclosureData{get;set;}

        public static List<Enclosure> GetEnclosures(){
        
        
                EnclosureData = new List<Enclosure>
                {
                        new Enclosure()
                        {
                           // EnclosureId = 1,
                            EnclosureName = "Lion Enclosure",
                            Size = 10,
                            Animals = new List<Animal>(),
                        },
                        new Enclosure()
                        {
                           // EnclosureId = 2,
                            EnclosureName = "Aviary",
                            Size = 50,
                            Animals = new List<Animal>(),
                        },
                        new Enclosure()
                        {
                           // EnclosureId = 3,
                            EnclosureName = "Reptile House",
                            Size = 40,
                            Animals = new List<Animal>(),
                        },
                        new Enclosure()
                        {
                           // EnclosureId = 4,
                            EnclosureName = "Giraffe Enclosure",
                            Size = 6,
                            Animals = new List<Animal>(),
                        },
                        new Enclosure()
                        {
                           // EnclosureId = 5,
                            EnclosureName = "Hippo Enclosure",
                            Size = 10,
                            Animals = new List<Animal>(),
                        },
                };
        return EnclosureData;
        }
    }
}
