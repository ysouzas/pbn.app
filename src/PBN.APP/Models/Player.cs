namespace PBN.APP.Models;

public class Player
{
    public string Name { get; set; } = string.Empty;

    public Guid Id { get; set; }

    public decimal Score { get; set; }

    public string Image { get; set; } = string.Empty;

    public Rank[]? Ranks { get; set; } = Array.Empty<Rank>();

}