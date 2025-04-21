using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Backend.Repository
{
    public class LoginRepository<TEntity> where TEntity : class
    {
        LoginAndRegisterEntities db = new LoginAndRegisterEntities();
        private LoginAndRegisterEntities _db;
        private DbSet<TEntity> _dbSet;

        public LoginRepository(LoginAndRegisterEntities db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }
        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }
        public virtual TEntity GetById(object Id)
        {
            return _dbSet.Find(Id);
        }
    }
}
