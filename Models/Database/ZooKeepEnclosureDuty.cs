using System.ComponentModel.DataAnnotations.Schema;

namespace zoo_mgmt.Models.Database;

public class ZooKeepEnclosureDuty
{
    public int ZooKeepEnclosureDutyId { get; set; }

    public int ZooKeeperId { get; set; }

    public int EnclosureId { get; set; }

    [ForeignKey("EnclosureId")]
     public Enclosure Enclosure { get; set; }

    [ForeignKey("ZooKeeperId")]
    public ZooKeeper ZooKeeper { get; set; }
   

    


}