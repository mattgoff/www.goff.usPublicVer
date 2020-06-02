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
    public class PiModel : PageModel
    {
        private readonly GoffUSContext _db;

        public PiModel(GoffUSContext db)
        {
            _db = db;
        }
        public PiData PiDatas {get; set;}
        public void OnGet()
        {
            PiDatas = _db.PiDatas.OrderByDescending( s => s.Id).FirstOrDefault();
        }
    }
}
