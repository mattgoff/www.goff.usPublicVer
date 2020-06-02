using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using www.goff.us.Data;
using www.goff.us.Models;

namespace www.goff.us.Pages
{
    public class AllergyModel : PageModel
    {

        private readonly GoffUSContext _db;

        public AllergyModel(GoffUSContext db)
        {
            _db = db;

        }

        public AllergyData AllergyDatas {get; set;}

        public void OnGet()
        {
            AllergyDatas = _db.AllergyDatas.OrderByDescending( s => s.Id).FirstOrDefault();
        }
    }
}
