using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public string NumberCards { get; set; }

        public void OnGet()
        {

        }
    }
}