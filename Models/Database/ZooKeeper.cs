using System.ComponentModel.DataAnnotations.Schema;

namespace zoo_mgmt.Models.Database;

public class ZooKeeper
{
    public int ZooKeeperId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<ZooKeepEnclosureDuty> ZooKeepEnclosureDuties { get; set; }

}
