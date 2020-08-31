﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Entities
{
    public class FlyRecipe : EntityBase
    {
        public string Name { get; set; }
        public Hook Hook { get; set; }
        public Thread Thread { get; set; }
        public string Description { get; set; }
        public IEnumerable<Equipment> EquipmentList { get; set; }
        public IDictionary<FlySection,Ingredient> SectionIngredients { get; set; }
        public string DifficultyLevel { get; set; } // enum
        public string TargetFishSpecies { get; set; } // possible enum
        public string PatternCategory { get; set; } // emerger, dry, nymph enum
        public IEnumerable<Image> StepByStepImages { get; set; } // youtube video link?
        // something to use a Hackle Guage to match up with gape
    }
    /*
     * List of positions:
     * Tail, Rib, Body, Thorat, Head, Eyes, Back, Thorax, Hackle
     * Collar, Cheeks, Weight/Wire, Bead, Legs, Wing, Underwing,
     * Abdomen, Sheath, Flash, Gills, Body Hackle, Throad Hackle
     */
}