namespace www.goff.us.Models
{
  public class Humphrey
  {
    public int Id {get; set;}
    public int OrgIndex {get; set;}
    public string Created_at { get; set;}
    public int Laps { get; set; }
    public decimal Kilometers{ get; set;}
    public decimal Miles {get; set;}
  }
}

// CREATE TABLE "Humphreys" (
//     "Id" INTEGER NOT NULL CONSTRAINT "PK_Humphreys" PRIMARY KEY AUTOINCREMENT,
//     "Created_at" TEXT NULL,
//     "Laps" INTEGER NOT NULL,
//     "Kilometers" TEXT NOT NULL,
//     "Miles" TEXT NOT NULL
// )