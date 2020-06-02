using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using www.goff.us.Data;
using www.goff.us.Models;

namespace www.goff.us.Pages
{
    public class CoCModel : PageModel
    {
        private readonly GoffUSContext _db;

        public CoCModel(GoffUSContext db)
        {
            _db = db;
        }

        public IEnumerable<CoCPlayer> coCPlayers {get; set;}

        public IEnumerable<CoCPlayer> CoCPlayerNames {get; set;}

        public IEnumerable<Hero> heroes {get; set;}

        public IEnumerable<Spell> spells {get; set;}

        public IEnumerable<Troop> troops {get; set;}

        public IEnumerable<Achievement> achievements {get; set;}
        public string activePlayer {get; set;}

        public void PopulateData()
        {
            coCPlayers = _db.CoCPlayers.Where (x => x.name == activePlayer).ToList();
            heroes = _db.Heroes.Where (x=> x.CoCPlayername == activePlayer).ToList().OrderByDescending(s => s.village).ThenBy(s => s.name);
            spells = _db.Spells.Where (x=> x.CoCPlayername == activePlayer).ToList().OrderBy(s => s.name);
            troops = _db.Troops.Where (x=> x.CoCPlayername == activePlayer).ToList().OrderByDescending(s => s.village).ThenBy(s => s.name);
            achievements = _db.Achievements.Where (x=> x.CoCPlayername == activePlayer).ToList().OrderByDescending(s => s.village).ThenBy(s => s.name);
        }
        public void OnGet()
        {
            CoCPlayerNames = _db.CoCPlayers.ToList();
            activePlayer = CoCPlayerNames.FirstOrDefault().name;
            PopulateData();
        }

        public void OnPost(string searchPlayer)
        {
            activePlayer = searchPlayer;
            CoCPlayerNames = _db.CoCPlayers.ToList();
            PopulateData();
        }
    }
}
