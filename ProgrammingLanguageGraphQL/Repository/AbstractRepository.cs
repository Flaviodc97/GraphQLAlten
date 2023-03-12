using Microsoft.EntityFrameworkCore;
using ProgrammingLanguageGraphQL.Data;
using ProgrammingLanguageGraphQL.Interfaces;
using System.Data;

namespace ProgrammingLanguageGraphQL.Repository
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : class
    {
        protected ProgrammingLanguageDbContext _context;

        public AbstractRepository(ProgrammingLanguageDbContext context)
        {
            _context = context;
         }

        public virtual T GetById(Guid id)
        {
            var entityToSend = _context.Set<T>().Find(id);
            return entityToSend;
           
            
        }

         public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
            
           
        }

        public virtual void Add(T entity)
        {
            // logica per aggiungere una nuova entità
            throw new NotImplementedException();
        }

        public virtual void Update(T entity)
        {
            // logica per aggiornare i dati di un'entità esistente
            throw new NotImplementedException();
        }

         public virtual void Delete(int id)
        {
            // logica per eliminare l'entità con l'id specificato
            throw new NotImplementedException();
        }

}
}
