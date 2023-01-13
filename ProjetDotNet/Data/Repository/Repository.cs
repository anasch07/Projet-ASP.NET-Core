using System.Linq.Expressions;
using ProjetDotNet.Data.Context;
using ProjetDotNet.Models;

namespace ProjetDotNet.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _applicationDbContext;
        public Repository(AppDbContext _applicationDbContext)
        {
            this._applicationDbContext = _applicationDbContext;
        }

        public TEntity? Get(int id)
        {
            return _applicationDbContext.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _applicationDbContext.Set<TEntity>().ToList();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _applicationDbContext.Set<TEntity>().Where(predicate);
        }

        public bool Add(TEntity entity)
        {
            try
            {
                
                _applicationDbContext.Set<TEntity>().Add(entity);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       

        public bool Remove(TEntity entity)
        {
            try
            {
                _applicationDbContext.Set<TEntity>().Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
    }
}