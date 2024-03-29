﻿namespace Flies.RecipeDomain;
public class Hook : Material
{
    public HookClassification Classification { get; set; } // dry-fly, nymph
    public string Size { get; set; }
    public IEnumerable<string> SizeRange { get; set; }
    public Eye Eye { get; set; }
    // could do eye loop
    public Shank Shank { get; set; } // #12 hook that is 2X Long it will have the wire strength of a #12 but the length of a #8(two sizes bigger)
                                     // maybe an enum: 1x 2x 3x 4x
    public Bend Bend { get; set; } // perfect, reversed, Limerick, sproat, klinkhamer, curved
    public Gap Gap { get; set; } // comes in standard.  1x wide would have the gape of a standard hook 1 size bigger
    public bool Barb { get; set; }
    public string Point { get; set; } // point, rounded, semi-dropped, dropped, needle
    public Strength Strength { get; set; } // 1x Fine uses wire from one size smaller, 2x heavy, with wire two sizes bigger
                                           // denotes a wire strength of a larger hook but on the current hook, ex 1xStrong hook of size #6 will have the wire strength of a #4
                                           // sometimes referred to with XStrong or XStout

    public string Metal { get; set; } // black-nickel, bronze, stainless, cadmium
    public bool Forged { get; set; }

    // wire gauge table/object, AWG or SWG size then diamter measurements
    //https://en.wikipedia.org/wiki/American_wire_gauge
}
// best way to organize hooks is by Pattern, ie i'm building a nymph fly
// look at daiichi fly selector https://www.fishusa.com/Brands/Manufacturers-List-CD/Daiichi
// should "build" the hook as well

// Dry hooks are usually of standard length but 1x fine
// nymph hooks are usually 1x long and 1x or 2x heavy

// streamers being sizes 4-12 and then 3x/4x long and 1x/2x heavy

// bookmarked hook comparison charts 
