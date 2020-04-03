using System.ComponentModel.DataAnnotations.Schema;

namespace Memory.Models
{
    public class Carte
    {

        public int ID { get; set; }
        public string Image { get; set; }
        public string FindBy { get; set; }
        [ForeignKey("Partie")]
        [Column(Order = 1)]
        public int PartieId { get; set; }
    }
}
