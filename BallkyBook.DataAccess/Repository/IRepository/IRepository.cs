using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BallkyBook.DataAccess.Repository.IRepository
{
    public interface IRepository <T> where T : class
    {
        IEnumerable<T> GetAll (string? includeProperties = null);
        void Add (T entity);
        void Delete (T entity);
        void DeleteRange (IEnumerable<T> entity);
        T GetFristOrDefault(Expression<Func<T,bool>> filter,string ? includeProperties=null);
        
    } 
}
