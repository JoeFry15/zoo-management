namespace zoo_mgmt.Models.Database;

public class Enclosure
{
    public int EnclosureId { get; set; }
    public string EnclosureName { get; set; }
    public int Size { get; set; }
    public List<Animal> Animals { get; set; }
}