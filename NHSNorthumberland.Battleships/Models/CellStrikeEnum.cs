using System.ComponentModel.DataAnnotations;

namespace NHSNorthumberland.Battleships.Models
{
    public enum CellStrikeEnum
    {
        [Display(Name = " ")]
        None,
        [Display(Name = "X")]
        ShipHit,
        [Display(Name = "~")]
        Water
    }
}
