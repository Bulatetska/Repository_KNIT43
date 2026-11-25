// Хас, Мацюк

using FantasyArena.Core;
using System.ComponentModel.DataAnnotations;

namespace FantasyArena.Web.Models;

public class ArenaViewModel
{
    [Required]
    [StringLength(30)]
    public string Hero1Name { get; set; } = "Daemon";

    public string Hero1Type { get; set; } = "Warrior";

    [Required]
    [StringLength(30)]
    public string Hero2Name { get; set; } = "Aemond";

    public string Hero2Type { get; set; } = "Mage";

    public BattleResult? Result { get; set; }
}