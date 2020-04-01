using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memory.Models
{
    public class Carte
    {
        public int ID { get; set; }
        public int Position { get; set; }
        public string Image { get; set; }
        public string FindBy { get; set; }
        public int PartieId { get; set; }
    }
}
