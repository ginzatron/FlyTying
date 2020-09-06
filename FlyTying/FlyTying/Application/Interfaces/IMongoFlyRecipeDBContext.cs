using FlyTying.Domain.Recipe;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyTying.Application.Interfaces
{
    public interface IMongoFlyRecipeDBContext
    {
        IMongoCollection<Recipe> GetCollection<Recipe>(string collectionName);
    }
}
