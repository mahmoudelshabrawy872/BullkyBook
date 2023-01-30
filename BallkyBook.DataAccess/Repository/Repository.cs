using BallkyBook.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BallkyBook.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> Set;
        public Repository(ApplicationDbContext db)
        {
            _db=db;
          //  _db.Products.Include(a => a.Category);
            Set=_db.Set<T>();
        } 
        public void Add(T entity)
        {
            Set.Add(entity);
        }

        public void Delete(T entity)
        {
            Set.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            Set.RemoveRange (entity);
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> quary = Set;
            if (includeProperties!=null)
            {
                foreach (var includepror in includeProperties.Split(new char[] { ','},StringSplitOptions.RemoveEmptyEntries))
                {
                    quary = quary.Include(includepror);
                }
            }
            return quary.ToList();
        }

        public T GetFristOrDefault(Expression<Func<T, bool>> filter,string? includeProperties = null)
        {
            IQueryable<T> quary = Set;
            quary=quary.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includepror in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    quary = quary.Include(includepror);
                }
            }
            return quary.FirstOrDefault();
        }
    }
}
