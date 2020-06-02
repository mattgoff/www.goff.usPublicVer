using System;
using System.Collections.Generic;
using www.goff.us.Models;
using System.Linq;

namespace www.goff.us.Data
{
  public class SqlitePiRepo : IPiRepo
  {
    private readonly GoffUSContext _context;

    public SqlitePiRepo(GoffUSContext context)
    {
      _context = context;
    }

    public PiData GetLatestPiData()
    {
      return _context.PiDatas.OrderByDescending( s => s.Id).FirstOrDefault();
    }

    public IEnumerable<PiData> GetPiDatas()
    {
      return _context.PiDatas.ToList();
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0 );
    }

    public void SetPiData(PiData piData)
    {
      piData.PiRecordStamp = $"{DateTime.Now}";
      var recordToUpdate = _context.PiDatas.Where(s => s.Id == 1).First();

      recordToUpdate.Blocks24Hours = piData.Blocks24Hours;
      recordToUpdate.DNSQ24Hours = piData.DNSQ24Hours;
      recordToUpdate.PiRecordStamp = piData.PiRecordStamp;

      // _context.PiDatas.Add(piData);
      _context.SaveChanges();

    }
  }
}
