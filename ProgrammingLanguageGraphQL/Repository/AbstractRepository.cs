using Microsoft.EntityFrameworkCore;
using ProgrammingLanguageGraphQL.Data;

namespace ProgrammingLanguageGraphQL.Repository
{
    public abstract class AbstractRepository<T> where T : class
    {
        protected readonly ProgrammingLanguageDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public AbstractRepository(ProgrammingLanguageDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<T>> Create(T obj)
        {
            var resp = await  _dbSet.AddAsync(obj);
            await this.Save();
            return resp;
            
        }
        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public virtual async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public virtual async Task DeleteAsync(object id)
        {
            T entityToDelete = await _dbSet.FindAsync(id);
            Delete(entityToDelete);
        }
        public virtual void Delete(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }
        private async Task<bool> Save()
        {
            var resp = await _context.SaveChangesAsync();
            return resp >= 0;
        }

    }
}
