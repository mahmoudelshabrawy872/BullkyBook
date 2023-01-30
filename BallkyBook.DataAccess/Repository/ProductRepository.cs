using BallkyBook.DataAccess.Repository.IRepository;
using BallkyBook.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public  ProductRepository(ApplicationDbContext db):base(db) 
        {
            _db=db;
        }
        public void Update(Product product)
        {
            var objFromDb = _db.Products.FirstOrDefault(a=>a.Id==product.Id);
            if (objFromDb != null)
            {
                objFromDb.Title= product.Title;
                objFromDb.Description= product.Description;
                objFromDb.CategoryId= product.CategoryId;
                objFromDb.Auther= product.Auther;
                objFromDb.CoverTypeId= product.CoverTypeId;
                objFromDb.Price= product.Price;
                objFromDb.Price100= product.Price100;
                objFromDb.Price50= product.Price50;
                objFromDb.ISBN= product.ISBN;
                objFromDb.ListPrice= product.ListPrice;
                if (objFromDb.ImageUrl!=null)
                {
                    objFromDb.ImageUrl= product.ImageUrl;
                }
            }
        }
    }
}
