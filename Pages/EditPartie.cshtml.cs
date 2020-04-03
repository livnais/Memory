using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Memory.Models;
using Memory.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Memory.Pages
{
   
    public class EditPartieModel : PageModel
    {
       
        [BindProperty(SupportsGet = true)]
        public string Player1 { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Player2 { get; set; }
        [BindProperty(SupportsGet = true)]
        [Display(Name = "NumberCards")]
        public int NumberCards { get; set; }
        public Partie Partie = new Partie();
        public ScorePartie ScorePartie = new ScorePartie();

        private readonly MemoryContext _context;

        public EditPartieModel(MemoryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(Player1) && !string.IsNullOrEmpty(Player2))
            {
           

                Partie.StateGame = StateGame.INPROGRESS.ToString();
                Partie.NumberCards = NumberCards;
                Partie.TournToPlay = Player1; // faire un random
                Partie.CreateAt = DateTime.Now;

               _context.Partie.Add(Partie);
                var dbSaveTask = _context.SaveChangesAsync();
                await dbSaveTask;
                //Attendre l'insertion des informations la partie 
                //pour recuperer la valeur de la clé primaire, les lignes (en commentaire) ne fonctionnent pas si on a 0 partie d'enregistrer
                // mais aussi si on supprime toute les parties (plus de partie dans la bdd) la clé primaire suivante n'est pas egal a 0 ou 1 mais à la derniere insertion
                //var PartieId = (from m in _context.Partie select m).Max(c => c.ID);
                //PartieId = PartieId + 1;
                while (dbSaveTask.Result == 0)
                {

                }
                var PartieId = Partie.ID;

                ScorePartie.Player1 = Player1;
                ScorePartie.Player2 = Player2;
                ScorePartie.ScorePlayer1 = 0;      
                ScorePartie.ScorePlayer2 = 0;
                ScorePartie.PartieId = PartieId;

                _context.ScorePartie.Add(ScorePartie);
             

               
                List<Carte> listShuffle =  shuffleCards(NumberCards, PartieId);
                foreach (Carte card in listShuffle)
                {
                    _context.Carte.Add(card);
                }
               await _context.SaveChangesAsync();
               return RedirectToPage("./mainGame","GameInfo",new { PartieId });
            }
            return Page();
        }

        public List<Carte> shuffleCards(int NumberC,int PartieId)
        {
           List<Carte> ListCard = new List<Carte>();
           for(int i = 0; i < NumberC/2; i++)
            {
                //je suis obliger de créer de variables carte car au moment de l'insertion en bdd le systeme va voir qu'il y a la meme reference (je suppose)
                //et donc le systeme va ajouter qu'une carte
                Carte Carte1 = new Carte();
                Carte Carte2 = new Carte();
                string ImageName = (i + 1).ToString()+".svg";

                Carte1.Image = ImageName;
                Carte1.PartieId = PartieId;

                Carte2.Image = ImageName;
                Carte2.PartieId = PartieId;

                ListCard.Add(Carte1);
                ListCard.Add(Carte2);
            }
           //On mélange les cartes
           return ListCard.OrderBy(a => Guid.NewGuid()).ToList();
        }


    }
}