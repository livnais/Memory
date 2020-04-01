using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Memory.Models
{
    public class ScorePartie
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Winner { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Player1 { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Player2 { get; set; }

        public int ScorePlayer1 { get; set; }
        public int ScorePlayer2 { get; set; }

        public int PartieId { get; set; }
    }
}
