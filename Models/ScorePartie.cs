using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Memory.Models
{
    public class ScorePartie
    {
        public int ID { get; set; }
        public string Winner { get; set; }
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public int ScorePlayer1 { get; set; }
        public int ScorePlayer2 { get; set; }
        [ForeignKey("Partie")]
        [Column(Order = 1)]
        public int PartieId { get; set; }
    }
}
