using System;
using System.Collections.Generic;
using www.goff.us.Models;
using System.Linq;

namespace www.goff.us.Data
{
  public class SqliteHumphreyRepo : IHumphreyRepo
  {
    private readonly GoffUSContext _context;

    public SqliteHumphreyRepo(GoffUSContext context)
    {
      _context = context;
    }

    public IEnumerable<Humphrey> GetAllHumphreyLaps()
    {
      return _context.Humphreys.ToList();
    }

    public void AddNewLapData(Humphrey humphrey)
    {
      _context.Humphreys.Add(humphrey);

    }
    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }
  }

}