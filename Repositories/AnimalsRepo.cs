using zoo_mgmt.Models.Request;
using zoo_mgmt.Models.Database;

namespace zoo_mgmt.Repositories
{
    public interface IAnimalsRepo
    {
        // IEnumerable<User> Search(UserSearchRequest search);
        // int Count(UserSearchRequest search);
        Animal GetById(int id);
        Animal Add(AddAnimalRequest newAnimal);
        // User Update(int id, UpdateUserRequest update);
        // void Delete(int id);
    }

    public class AnimalsRepo : IAnimalsRepo
    {
        private readonly ZooManagementDbContext _context;

        public AnimalsRepo(ZooManagementDbContext context)
        {
            _context = context;
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

        public Animal GetById(int id)
        {
            return _context.Animals
                .Single(animal => animal.Id == id);
        }

        public Animal Add(AddAnimalRequest newAnimal)
        {
            var insertResponse = _context.Animals.Add(new Animal
            {
                Name = newAnimal.Name,
                Species = newAnimal.Species,
                Classification = newAnimal.Classification,
                Sex = newAnimal.Sex,
                BirthDate = newAnimal.BirthDate,
                AcquiredDate = newAnimal.AcquiredDate,
            });
            _context.SaveChanges();

            return insertResponse.Entity;
        }

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