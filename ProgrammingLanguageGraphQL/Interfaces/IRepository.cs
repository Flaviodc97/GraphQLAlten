﻿namespace ProgrammingLanguageGraphQL.Interfaces
{
    public interface IRepository <T>
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
