using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Memory.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public void OnPostWay2(string button)
        {
            ViewData["result"] = button;
            System.Diagnostics.Debug.WriteLine(button);
   
        }
    
    }
}
