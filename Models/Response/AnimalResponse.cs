using zoo_mgmt.Models.Database;

namespace zoo_mgmt.Models.Response
{
    public class AnimalResponse
    {
        private readonly Animal _animal;

        public AnimalResponse(Animal animal)
        {
            _animal = animal;
        }
        public int Id => _animal.Id;
        public string Name => _animal.Name;
        public string Species => _animal.Species;
        public string Classification => _animal.Classification;
        public string Sex => _animal.Sex;
        public DateTime BirthDate => _animal.BirthDate;
        public DateTime AcquiredDate => _animal.AcquiredDate;

    }
}