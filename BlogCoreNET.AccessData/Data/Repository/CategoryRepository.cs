using BlogCoreNET.AccessData.Data.Repository.IRepository;
using BlogCoreNET.Data;
using BlogCoreNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCoreNET.AccessData.Data.Repository
{
    internal class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Category category)
        {
            var objDb = _db.category.FirstOrDefault(s => s.Id == category.Id);
            objDb.Name = category.Name;
            objDb.Order = category.Order;
            _db.SaveChanges();
        }
    }
}
