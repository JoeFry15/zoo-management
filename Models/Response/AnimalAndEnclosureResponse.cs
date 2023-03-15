namespace zoo_mgmt.Models.Database;

public class AnimalAndEnclosureResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }

    public string Classification { get; set; }

    public string Sex { get; set; }

    public DateTime BirthDate { get; set; }

    public DateTime AcquiredDate { get; set; }
    public int EnclosureId { get; set; }
    public string EnclosureName { get; set; }
}