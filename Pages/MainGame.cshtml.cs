using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Memory.Models;
using Memory.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace Memory.Pages
{
    public class MainGameModel : PageModel
    {
        public Partie Partie { get; set; }
        public ScorePartie ScorePartie { get; set; }
        public IList<Carte> Carte { get; set; }
        public string NameCard;
        public int idCard1 { get; set; }
        public int idCard2 { get; set; }

        private MemoryManager MemoryManager;
        private readonly MemoryContext _context;

        public MainGameModel(MemoryContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync(int id,int idCardSelected1)
        {
         
            if (id != 0)
            {
                idCard1 = id;
            }
            if (idCardSelected1 != 0)
            {
                idCard2 = idCardSelected1;
            }

            //ne pas utiliser un navigateur privé (cookie non enregistré)
            int PartieId = int.Parse(Request.Cookies["PartieId"]);
            if (MemoryManager.Partie!=null && MemoryManager.PartieId == PartieId)
            {
                Partie = MemoryManager.Partie;
                ScorePartie = MemoryManager.ScorePartie;
                Carte = MemoryManager.ListCarte;
            }
            else
            {
                Partie = await _context.Partie.FirstOrDefaultAsync(m => m.ID == PartieId);
                ScorePartie = await _context.ScorePartie.FirstOrDefaultAsync(m => m.PartieId == PartieId);
                Carte = await _context.Carte.Where(m => m.PartieId == PartieId).ToListAsync();
            }

        }

        public async Task<IActionResult> OnGetGameInfo(int PartieId)
        {
            Response.Cookies.Append("PartieId", PartieId.ToString());


            Partie = await _context.Partie.FirstOrDefaultAsync(m => m.ID == PartieId);
            ScorePartie = await _context.ScorePartie.FirstOrDefaultAsync(m => m.PartieId == PartieId);
            Carte = await _context.Carte.Where(m => m.PartieId == PartieId).ToListAsync();
            if(Partie == null && ScorePartie == null && Carte.Count == 0)
            {
                return RedirectToPage("./index");
            }
             MemoryManager.PartieId = PartieId;
             MemoryManager.Partie = Partie;
             MemoryManager.ScorePartie = ScorePartie;
             MemoryManager.ListCarte = Carte;
            
            return Page();
        }

        public string this[string playerName]
        {

            get
            {
                return Partie.TournToPlay==playerName ? "playerActif.svg" : "playerNotActif.svg";
            }

        }


        public  IActionResult OnGetCheckCards(int id1,int id2)
        {

            string playerInProgress = MemoryManager.Partie.TournToPlay;

            Carte imageCard1 = MemoryManager.ListCarte.Where(card => card.ID == id1).Single();
            Carte imageCard2 = MemoryManager.ListCarte.Where(card => card.ID == id2).Single();
            if(imageCard1.Image == imageCard2.Image)
            {
                imageCard1.FindBy = playerInProgress;
                imageCard2.FindBy = playerInProgress;

                _context.Carte.Update(imageCard1);
                _context.Carte.Update(imageCard2);

                if (playerInProgress == MemoryManager.ScorePartie.Player1)
                {
                    int points = MemoryManager.ScorePartie.ScorePlayer1;
                    points ++;
                    MemoryManager.ScorePartie.ScorePlayer1 = points;
                    _context.ScorePartie.Update(MemoryManager.ScorePartie);
                }
                else
                {
                    int points = MemoryManager.ScorePartie.ScorePlayer2;
                    points++;
                    MemoryManager.ScorePartie.ScorePlayer2 = points;
                    _context.ScorePartie.Update(MemoryManager.ScorePartie);
                }
            }
            else
            {
                if (playerInProgress==MemoryManager.ScorePartie.Player1)
                {
                    MemoryManager.Partie.TournToPlay = MemoryManager.ScorePartie.Player2;
                    _context.Partie.Update(MemoryManager.Partie);
                }
                else
                {
                    MemoryManager.Partie.TournToPlay = MemoryManager.ScorePartie.Player1;
                    _context.Partie.Update(MemoryManager.Partie);
                }

            }
            _context.SaveChanges();
            int countCardNotPlay = MemoryManager.ListCarte.Where(card => card.FindBy == null).Count();
            if (countCardNotPlay == 0)
            {
                if (MemoryManager.ScorePartie.ScorePlayer1 > MemoryManager.ScorePartie.ScorePlayer2)
                {
                    MemoryManager.ScorePartie.Winner = MemoryManager.ScorePartie.Player1;
                }
                else
                {
                    MemoryManager.ScorePartie.Winner = MemoryManager.ScorePartie.Player2;
                }

                MemoryManager.Partie.StateGame = StateGame.DONE.ToString();
                _context.Partie.Update(MemoryManager.Partie);
                _context.ScorePartie.Update(MemoryManager.ScorePartie);
                _context.SaveChanges();
             
                return new JsonResult(MemoryManager.ScorePartie.Winner);
            }
            return new JsonResult("");
        }

    }
}