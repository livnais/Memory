using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Memory.Models
{
    public class Partie
    {
        [Column(Order = 1)]
        public int ID { get; set; }
        public int NumberCards { get; set; }
        public string StateGame { get; set; }
        public string TournToPlay { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateAt { get; set; }

  
    }
}
