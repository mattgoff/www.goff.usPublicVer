using System;
using System.Collections.Generic;
using www.goff.us.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace www.goff.us.Data
{
  public class SqliteCoCRepo : ICoCRepo
  {
    private readonly GoffUSContext _context;

    public SqliteCoCRepo(GoffUSContext context)
    {
      _context = context;
    }

    public CoCPlayer GetCoCPlayerById(string coCPlayer)
    {
      return _context.CoCPlayers.OrderByDescending( s => s.name == coCPlayer).FirstOrDefault();
    }

    public IEnumerable<CoCPlayer> GetCoCPlayers()
    {
      return _context.CoCPlayers.ToList();
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }

    public void SetCoCData(CoCPlayer coCPlayer)
    {
      coCPlayer.COCRecordStamp = $"{DateTime.Now}";
      if (_context.CoCPlayers.Any(b => b.name == coCPlayer.name))
      {
        var username = coCPlayer.name;
        // var clanTag = "#29VG0828V";

        _context.Database.ExecuteSqlRaw($"DELETE FROM Heroes WHERE COCPlayername = '{username}'");
        _context.Database.ExecuteSqlRaw($"DELETE FROM Achievements WHERE COCPlayername = '{username}'");
        // _context.Database.ExecuteSqlRaw($"DELETE FROM Clans WHERE tag = '{clanTag}'");
        _context.Database.ExecuteSqlRaw($"DELETE FROM Spells WHERE COCPlayername = '{username}'");
        _context.Database.ExecuteSqlRaw($"DELETE FROM Troops WHERE COCPlayername = '{username}'");
        _context.Update(coCPlayer);
      }
      else
      {
        _context.CoCPlayers.Add(coCPlayer);
      }
    }
  }
}
