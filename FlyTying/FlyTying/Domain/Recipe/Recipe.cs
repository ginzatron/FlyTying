using FlyTying.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Domain.Recipe
{
    public class Recipe : IDocument
    {
        public string Id { get; set; }
        public Hook Hook { get; set; }
        public Thread Thread { get; set; }
        public Tool[] Tools { get; set; }
        public Supply[] Supplies { get; set; }
        public Instruction[] Instructions { get; set; }
        public Pattern Pattern { get; set; }

        public DateTime CreatedAt { get; set; } 
        public DateTime ModifiedAt { get; set; }
    }
}

/*
 * Hook : {Classification : "", Size : "", Eye : "", Shank : {Length : "", Modifer : ""}, Bend : "", Gap : {Width : "", Modifer : ""} , Barb : "", Point : "", HookStrength : {Strength : "", Modifer : ""}, Metal : "", Forged : True},
 * Thread : {Weight : "", Denier: "", BreakingStrength : "", Fiber : "", Waxed : True, Configuration : "", Color : "" },
 * Tools : ["Vise", "Pliers", "Bobbin"],
 * Supplies : [{Name : "Cement", Note: "Apply to bead"},{Name : "UvResin", Note: "Apply to WingPost"}],
 * Instructions : [{Image : {Url : "", Description : "No Image"}, Materials : [{Name : "Material1", Description : "First Material"},{Name : "Material2", Description: "Second Material"}]}]
 */
