using System.ComponentModel.DataAnnotations;

namespace zoo_mgmt.Models.Request
{
    public class AddAnimalRequest
    {
        public string Name { get; set; }
        public string Species { get; set; }

        public string Classification{ get; set; }

        public string Sex { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime AcquiredDate { get; set; }

        public string Enclosure {get; set;}

    }
}