using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class Hook : EntityBase
    {
        public string BrandName { get; set; }
        public string Size { get; set; }
        public IEnumerable<string> SizeRange { get; set; }
        public string Eye { get; set; } // down, up, straight, slightly bent

        // maybe structure an enum if 1x,2x,3x,4x then add a "modifier" so you know what it's for
        // ie. long/short, heay/fine, strong/weak, wide

        // hook length will be it's own class where you denote length, standard, XLong or Xshort
        public string Length { get; set; } // #12 hook that is 2X Long it will have the wire strength of a #12 but the length of a #8(two sizes bigger)
        // maybe an enum: 1x 2x 3x 4x

        // weight is its own class
        public string Wire { get; set; } // 1x Fine uses wire from one size smaller, 2x heavy, with wire two sizes bigger
        // denotes a wire strength of a larger hook but on the current hook, ex 1xStrong hook of size #6 will have the wire strength of a #4
        // sometimes referred to with XStrong or XStout

        public string Gape { get; set; } // comes in standard.  1x wide would have the gape of a standard hook 1 size bigger
        public string Metal { get; set; } // black-nickel, bronze
        public string Point { get; set; } // point, rounded, semi-dropped, dropped
        public string Shank { get; set; } // long, short, curved, straight
        public bool Barb { get; set; }
        public string Bend { get; set; } // perfect, reversed, Limerick, sproat, klinkhamer

        public Note Note { get; set; }

        // wire gauge table/object, AWG or SWG size then diamter measurements
        //https://en.wikipedia.org/wiki/American_wire_gauge
    }

    // Dry hooks are usually of standard length but 1x fine
    // nymph hooks are usually 1x long and 1x or 2x heavy

    // all starts with the size then the modification to length, weight
    // streamers being sizes 4-12 and then 3x/4x long and 1x/2x heavy

    // nymph hooks as standard i assume will have a longer length to begin with?

    // the larger hooks get, the sparser the hook details
}
