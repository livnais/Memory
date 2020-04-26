using Memory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memory.Utils
{
    public class MemoryManager
    {
        public static MemoryManager MemoryInstance;
        public static int PartieId { get; set; }
        public static Partie Partie { get; set; }
        public static IList<Carte> ListCarte { get; set; }
        public static ScorePartie ScorePartie { get; set; }

        //public MemoryManager GetInstance(int _PartieId, Partie partie, IList<Carte> cartes, ScorePartie scorePartie)
        //{
        //    if(MemoryInstance == null)
        //    {
        //        MemoryInstance = new MemoryManager(_PartieId, partie,cartes,scorePartie);
                
        //    }
        //    else if (MemoryInstance!=null && _PartieId!= PartieId)
        //    {
        //        MemoryInstance.setPartieId(_PartieId);
        //        MemoryInstance.setPartie(partie);
        //        MemoryInstance.setCartes(cartes);
        //        MemoryInstance.setScorePartie(scorePartie);

        //    }
        //    return MemoryInstance;
        //}
        //public MemoryManager GetInstance()
        //{
        //    return MemoryInstance;
        //}
        //public bool isInstance(int partiId)
        //{
        //    if (MemoryInstance == null || PartieId != partiId)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //private MemoryManager(int partieId, Partie partie, IList<Carte> cartes,ScorePartie scorePartie)
        //{
        //   this.PartieId = partieId;
        //   this.Partie = partie;
        //   this.ListCarte = cartes;
        //    this.ScorePartie = scorePartie;
        //}

        //private void setPartieId(int partieId)
        //{
        //    this.PartieId = partieId;
        //}

        //private void setPartie(Partie partie)
        //{
        //    this.Partie = partie;
        //}
        //private void setCartes(IList<Carte> cartes)
        //{
        //    this.ListCarte = cartes;
        //}
        //private void setScorePartie(ScorePartie scorePartie)
        //{
        //    this.ScorePartie = scorePartie;
        //}

        //public Partie GetPartie()
        //{
        //    return this.Partie;
        //}

        //public IList<Carte> GetCartes()
        //{
        //    return this.ListCarte;
        //}
        //public ScorePartie GetScorePartie( )
        //{
        //   return this.ScorePartie;
        //}
    }
}
