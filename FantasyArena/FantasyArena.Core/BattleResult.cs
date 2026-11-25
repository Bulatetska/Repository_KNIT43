// Хас

namespace FantasyArena.Core;

public class BattleResult
{
    public string Winner { get; set; } = "";
    public int Rounds { get; set; }
    public int Hero1Health { get; set; }
    public int Hero2Health { get; set; }

    public List<string> Logs { get; } = new();
}