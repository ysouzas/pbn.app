namespace PBN.Models;

public class Rank
{
    public Rank()
    {
        
    }

    public Rank(decimal score)
    {
        Score = score;
        Date = DateTime.Now;
        DayOfWeek = (DateTime.Now.DayOfWeek - 1);
    }

    public decimal Score { get; set; }

    public DayOfWeek DayOfWeek { get; set; }

    public DateTime Date { get; set; }
}
