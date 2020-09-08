using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Application.Interfaces
{
    public interface IFlyRecipeDatabaseSettings
    {
        string ConnectionString { get; set;}
        string DatabaseName { get; set; }
    }
}
