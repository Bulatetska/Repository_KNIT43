using FantasyArena.Core;
using System.ComponentModel.DataAnnotations;

namespace FantasyArena.Web.Models;

public class ArenaViewModel
{
    [Required]
    [StringLength(30)]
    public string Hero1Name { get; set; } = "Daemon";

    public string Hero1Type { get; set; } = "Warrior";

    public string Hero1Weapon { get; set; } = "Sword";

    [Required]
    [StringLength(30)]
    public string Hero2Name { get; set; } = "Aemond";

    public string Hero2Type { get; set; } = "Mage";

    public string Hero2Weapon { get; set; } = "Staff";

    public BattleResult? Result { get; set; }
}