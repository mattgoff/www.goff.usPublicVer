using www.goff.us.Models;
using Microsoft.EntityFrameworkCore;

namespace www.goff.us.Data{
  public class GoffUSContext : DbContext
  {
    public GoffUSContext(DbContextOptions<GoffUSContext> opt) : base(opt)
    {

    }
    public DbSet<OfficeTemperature> OfficeTemperatures {get; set;}
    public DbSet<FrontDoorTemperature> FrontDoorTemperatures {get; set;}
    public DbSet <PatioTemperature> PatioTemperatures { get; set;}
    public DbSet <AllergyData> AllergyDatas {get; set;}
    public DbSet <PiData> PiDatas {get; set;}
    public DbSet <WeatherData> WeatherDatas {get; set;}
    public DbSet <CoCPlayer> CoCPlayers {get; set;}
    public DbSet <Troop> Troops {get; set;}
    public DbSet <Spell> Spells {get; set;}
    public DbSet <Hero> Heroes {get; set;}
    public DbSet <Achievement> Achievements {get; set;}
    public DbSet <Humphrey> Humphreys {get; set;}
  }
}