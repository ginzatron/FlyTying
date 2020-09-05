using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Application
{
    public interface IFlyRecipeDatabaseSettings
    {
        string RecipeCollectionName { get; set; }
        string ConnectionString { get; set;}
        string DatabaseName { get; set; }
    }
}
