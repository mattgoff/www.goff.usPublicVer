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
    public class HumphreyModel : PageModel
    {
        private readonly GoffUSContext _db;

        public HumphreyModel(GoffUSContext db)
        {
            _db = db;
        }

        public int totalLaps { get; set; }
        public decimal totalMiles { get; set; }
        public decimal totalKilometers { get; set; }
        public void OnGet()
        {
            totalLaps = 0;
            totalMiles = 0;
            totalKilometers = 0;

            foreach (var item in _db.Humphreys)
            {
                totalLaps += item.Laps;
                totalKilometers += item.Kilometers;
                totalMiles += item.Miles;
            }
        }
    }
}
