﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Application
{
    public class FlyRecipeDatabaseSettings : IFlyRecipeDatabaseSettings
    {
        public string RecipeCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}