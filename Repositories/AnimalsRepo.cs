using zoo_mgmt.Models.Request;
using zoo_mgmt.Models.Database;
using System;
using NLog;
using NLog.Fluent;

namespace zoo_mgmt.Repositories
{
    public interface IAnimalsRepo
    {
        // IEnumerable<User> Search(UserSearchRequest search);
        // int Count(UserSearchRequest search);
        Animal GetById(int id);

        List<Animal> GetByPageInfo(AnimalSearchRequest search);
        List<string> GetListOfSpecies();
        Animal Add(AddAnimalRequest newAnimal);
        // User Update(int id, UpdateUserRequest update);
        // void Delete(int id);
    }

    public class AnimalsRepo : IAnimalsRepo
    {
        private static readonly NLog.ILogger Logger = LogManager.GetCurrentClassLogger();
        private readonly ZooManagementDbContext _context;

        public AnimalsRepo(ZooManagementDbContext context)
        {
            _context = context;
        }

        public List<Animal> GetByPageInfo(AnimalSearchRequest search)
        {
            int firstResult = 1 + (search.PageSize * (search.Page - 1));

            IEnumerable<Animal> animalData = _context.Animals;

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

            var animalDataPage = search.OrderBy != null ? animalData
                .Skip(firstResult - 1).Take(search.PageSize)
                .OrderBy(o => o.GetType().GetProperty(search.OrderBy).GetValue(o))
                .ToList()
                :
                animalData
                .Skip(firstResult - 1).Take(search.PageSize)
                .OrderBy(o => o.Species)
                .ToList();

            Logger.Info("Animal search page generated.");

            return animalDataPage;
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
            var getEnclosureCount = _context.Animals.Where(e => e.Enclosure == newAnimal.Enclosure).Count();

            Dictionary<string, int> Enclosures = new Dictionary<string, int>{
                 {"Lion Enclosure", 10},
                 {"Aviary", 50},
                 {"Reptile House", 40},
                 {"Giraffe Enclosure", 6},
                 {"Hippo Enclosure", 10},
            };

            if (!Enclosures.ContainsKey(newAnimal.Enclosure))
            {
                Logger.Warn("User attempted to add an animal with an enclosure that does not exist.");
                throw new Exception("This Enclosure does not exist!!");
            }


            if (getEnclosureCount >= Enclosures[newAnimal.Enclosure])
            {
                Logger.Warn("User attempted to add an animal to a full enclosure.");
                throw new Exception("Too many animals in Enclosure!!");
            }


            var insertResponse = _context.Animals.Add(new Animal
            {
                Name = newAnimal.Name,
                Species = newAnimal.Species,
                Classification = newAnimal.Classification,
                Sex = newAnimal.Sex,
                BirthDate = newAnimal.BirthDate,
                AcquiredDate = newAnimal.AcquiredDate,
                Enclosure = newAnimal.Enclosure,
            });
            _context.SaveChanges();

            return insertResponse.Entity;
        }


        // public IEnumerable<User> Search(UserSearchRequest search)
        // {
        //     return _context.Users
        //         .Where(p => search.Search == null ||
        //                     (
        //                         p.FirstName.ToLower().Contains(search.Search) ||
        //                         p.LastName.ToLower().Contains(search.Search) ||
        //                         p.Email.ToLower().Contains(search.Search) ||
        //                         p.Username.ToLower().Contains(search.Search)
        //                     ))
        //         .OrderBy(u => u.Username)
        //         .Skip((search.Page - 1) * search.PageSize)
        //         .Take(search.PageSize);
        // }

        // public int Count(UserSearchRequest search)
        // {
        //     return _context.Users
        //         .Count(p => search.Search == null ||
        //                     (
        //                         p.FirstName.ToLower().Contains(search.Search) ||
        //                         p.LastName.ToLower().Contains(search.Search) ||
        //                         p.Email.ToLower().Contains(search.Search) ||
        //                         p.Username.ToLower().Contains(search.Search)
        //                     ));
        // }

        // public User Update(int id, UpdateUserRequest update)
        // {
        //     var user = GetById(id);

        //     user.FirstName = update.FirstName;
        //     user.LastName = update.LastName;
        //     user.Username = update.Username;
        //     user.Email = update.Email;
        //     user.ProfileImageUrl = update.ProfileImageUrl;
        //     user.CoverImageUrl = update.CoverImageUrl;

        //     _context.Users.Update(user);
        //     _context.SaveChanges();

        //     return user;
        // }

        // public void Delete(int id)
        // {
        //     var user = GetById(id);
        //     _context.Users.Remove(user);
        //     _context.SaveChanges();
        // }

        // public static byte[] getSalt()
        // {
        //     byte[] salt = new byte[128 / 8];
        //     using (var rngCsp = new RNGCryptoServiceProvider())
        //     {
        //         rngCsp.GetNonZeroBytes(salt);
        //     }

        //     return salt;
        // }

        // public static string getHashCode(string password, byte[] salt)
        // {
        //     string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        //        password: password,
        //        salt: salt,
        //        prf: KeyDerivationPrf.HMACSHA256,
        //        iterationCount: 100000,
        //        numBytesRequested: 256 / 8));

        //     return hashed;
        // }

    }
}