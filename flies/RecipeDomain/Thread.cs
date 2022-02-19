namespace Flies.RecipeDomain;
public class Thread : Material
{
    public string Weight { get; set; } // aught scale 3/0 = 000
    public string Denier { get; set; } // more accurate weight measure, weight in grams of 9k meters of thread
    public string BreakingStrength { get; set; } // in oz. don't see that much
    public string Fiber { get; set; } // nylon, silk, polyester, kevlar, GSP? most people use nylon or heavier polyester
    public bool Waxed { get; set; } // everything except, silk kevlar and GSP come waxed
    public string Configuration { get; set; } // round or flat
    public string Color { get; set; } // or should be IngredientSpecifications?
}
