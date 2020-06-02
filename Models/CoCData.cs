using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace www.goff.us.Models
{

  public class CoCPlayer
  {
    // public int Id { get; set; }
    public IList<Achievement> achievements { get; set; }
    public int attackWins { get; set; }
    public int bestTrophies { get; set; }
    public int bestVersusTrophies { get; set; }
    public int builderHallLevel { get; set; }
    public int defenseWins { get; set; }
    public int donations { get; set; }
    public int donationsReceived { get; set; }
    public int expLevel { get; set; }
    public IList<Hero> heroes { get; set; }
    [Key]
    public string name { get; set; }
    public string role { get; set; }
    public IList<Spell> spells { get; set; }
    public string tag { get; set; }
    public int townHallLevel { get; set; }
    public IList<Troop> troops { get; set; }
    public int trophies { get; set; }
    public int versusBattleWinCount { get; set; }
    public int versusBattleWins { get; set; }
    public int versusTrophies { get; set; }
    public int warStars { get; set; }
    public string COCRecordStamp { get; set; }
  }
  public class Achievement
  {
    public int Id { get; set; }
    public string completionInfo { get; set; }
    public string info { get; set; }
    public string name { get; set; }
    public int stars { get; set; }
    public int target { get; set; }
    public int value { get; set; }
    public string village { get; set; }
    public string CoCPlayername {get; set;}
  }

  public class Hero
  {
    public int Id { get; set; }
    public int level { get; set; }
    public int maxLevel { get; set; }
    public string name { get; set; }
    public string village { get; set; }
    public string CoCPlayername {get; set;}
  }

  public class Spell
  {
    public int Id { get; set; }
    public int level { get; set; }
    public int maxLevel { get; set; }
    public string name { get; set; }
    public string village { get; set; }
    public string CoCPlayername {get; set;}
  }

  public class Troop
  {
    public int Id { get; set; }
    public int level { get; set; }
    public int maxLevel { get; set; }
    public string name { get; set; }
    public string village { get; set; }
    public string CoCPlayername {get; set;}
  }
}