﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FlyTying.Application.Interfaces
{
    public interface IMongoRepo<T> where T: IDocument
    {
        //IEnumerable<T> GetAll<T>();
        //T GetById<T>(string id);
        //T Create<T>(T value);
        //void Update<T>(string id, T value);
        //void Remove<T>(string id);
        //void Remove<T>(T value);

        //IQueryable<T> AsQueryable();

        //IEnumerable<T> FilterBy(
        //    Expression<Func<T, bool>> filterExpression);

        //IEnumerable<TProjected> FilterBy<TProjected>(
        //    Expression<Func<T, bool>> filterExpression,
        //    Expression<Func<T, TProjected>> projectionExpression);

        //T FindOne(Expression<Func<T, bool>> filter);

        Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression);

        //T FindById(string id);

        Task<T> FindByIdAsync(string id);

        //void InsertOne(T document);

        Task CreateAsync(T document);

        //void InsertMany(ICollection<T> documents);

        // Task InsertManyAsync(ICollection<T> documents);

        //void ReplaceOne(T document);

        Task UpdateAsync(string id, T document);

        //void DeleteOne(Expression<Func<T, bool>> filterExpression);

        Task DeleteByFilterAsync(Expression<Func<T, bool>> filterExpression);

        //void DeleteById(string id);

        Task DeleteByIdAsync(string id);

        //void DeleteMany(Expression<Func<T, bool>> filterExpression);

        //Task DeleteManyAsync(Expression<Func<T, bool>> filterExpression);
    }
}
