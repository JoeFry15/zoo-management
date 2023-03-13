using System.ComponentModel.DataAnnotations;

namespace zoo_mgmt.Models.Request
{
    public class AddAnimalRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public string Sex { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime AquiredDate { get; set; }

    }
}