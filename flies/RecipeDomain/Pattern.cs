namespace Flies.RecipeDomain;
public class Pattern
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Dictionary<string, Material[]> Anatomy { get; set; } // want to use Section for the key
    public Species[] Targets { get; set; }
    public PatternType PatternType { get; set; }
}
