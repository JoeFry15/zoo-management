using zoo_mgmt.Models.Request;
using zoo_mgmt.Models.Database;

using NLog;

namespace zoo_mgmt.Repositories
{
    public interface IAnimalsRepo
    {
        Animal GetById(int id);

        List<AnimalAndEnclosureResponse> GetByPageInfo(AnimalSearchRequest search);
        List<string> GetListOfSpecies();
        Animal Add(AddAnimalRequest newAnimal);
        List<AnimalAndEnclosureResponse> GetAnimalsInEnclosure(int enclosureId);
    }

    public class AnimalsRepo : IAnimalsRepo
    {
        private static readonly NLog.ILogger Logger = LogManager.GetCurrentClassLogger();
        private readonly ZooManagementDbContext _context;

        public AnimalsRepo(ZooManagementDbContext context)
        {
            _context = context;
        }

        public List<AnimalAndEnclosureResponse> GetByPageInfo(AnimalSearchRequest search)
        {
            int firstResult = 1 + (search.PageSize * (search.Page - 1));

            IEnumerable<Animal> animalData = _context.Animals;

            IEnumerable<Enclosure> enclosureData = _context.Enclosures;

            if (search.Name != null)
            {
                animalData = animalData
                .Where(i => i.Name == search.Name);
            }

            if (search.Species != null)
            {
                animalData = animalData
                .Where(i => i.Species == search.Species);
            }

            if (search.Classification != null)
            {
                animalData = animalData
                .Where(i => i.Classification == search.Classification);
            }

            if (search.AcquiredDate != null)
            {
                animalData = animalData
                .Where(i => i.AcquiredDate == search.AcquiredDate);
            }

            if (search.Age != null)
            {
                DateTime currentDate = DateTime.Now;
                DateTime requiredDate = currentDate.AddYears(-(search.Age.Value));

                animalData = animalData
                .Where(i => i.BirthDate.Year == requiredDate.Year);
            }

            IEnumerable<AnimalAndEnclosureResponse> animalList = animalData.GroupJoin(enclosureData,
            animalData => animalData.Enclosure.EnclosureId,
            enclosureData => enclosureData.EnclosureId,
            (animalData, animalDataGroup) => new AnimalAndEnclosureResponse()
            {
                Id = animalData.Id,
                Name = animalData.Name,
                Species = animalData.Species,
                Classification = animalData.Classification,
                Sex = animalData.Sex,
                BirthDate = animalData.BirthDate,
                AcquiredDate = animalData.AcquiredDate,
                EnclosureId = animalData.Enclosure.EnclosureId,
                EnclosureName = animalData.Enclosure.EnclosureName,
            });


            List<AnimalAndEnclosureResponse> animalDataPage = search.OrderBy != null ? animalList
                .OrderBy(o => o.GetType().GetProperty(search.OrderBy).GetValue(o))
                .Skip(firstResult - 1).Take(search.PageSize)
                .ToList()
                :
                animalList
                .OrderBy(o => o.Species)
                .OrderBy(o => o.EnclosureId)
                .Skip(firstResult - 1).Take(search.PageSize)
                .ToList();

            Logger.Info("Animal search page generated.");

            return animalDataPage;
        }

        public List<AnimalAndEnclosureResponse> GetAnimalsInEnclosure(int enclosureId)
        {
           

            var animals = _context.Animals.Where(a => a.EnclosureId == enclosureId).ToList();

            var enclosureName = _context.Enclosures.Where(a => a.EnclosureId == enclosureId).First().EnclosureName;

            var animalList = new List<AnimalAndEnclosureResponse>();


            foreach (var item in animals)
            {
                animalList.Add(new AnimalAndEnclosureResponse()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Species = item.Species,
                    Classification = item.Classification,
                    Sex = item.Sex,
                    BirthDate = item.BirthDate,
                    AcquiredDate = item.AcquiredDate,
                    EnclosureId = item.EnclosureId,
                    EnclosureName = enclosureName,
                });
            }

            Logger.Info("Enclosure page generated.");
            

            return animalList;
        }

        public Animal GetById(int id)
        {
            return _context.Animals
                .Single(animal => animal.Id == id);
        }

        public List<string> GetListOfSpecies()
        {
            var animalTypes = _context.Animals.GroupBy(m => m.Species)
            .Select(x => x.First().Species).ToList();

            return animalTypes;
        }

        public Animal Add(AddAnimalRequest newAnimal)
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


            var insertResponse = _context.Animals.Add(new Animal
            {
                Name = newAnimal.Name,
                Species = newAnimal.Species,
                Classification = newAnimal.Classification,
                Sex = newAnimal.Sex,
                BirthDate = newAnimal.BirthDate,
                AcquiredDate = newAnimal.AcquiredDate,
                // Enclosure_id = newAnimal.Enclosure_id,
            });
            _context.SaveChanges();

            return insertResponse.Entity;
        }
    }
}