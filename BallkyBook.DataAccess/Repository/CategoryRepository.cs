using BallkyBook.DataAccess.Repository.IRepository;
using BallkyBook.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallkyBook.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db):base(db) 
        {
            _db=db;
        }
        public void Update(Category category)
        {
           _db.Categories.Update(category);
        }
    }
}
