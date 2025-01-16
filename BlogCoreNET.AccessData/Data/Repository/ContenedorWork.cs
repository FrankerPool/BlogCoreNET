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
    public class ContenedorWork : IContenedorWork
    {
        private readonly ApplicationDbContext _db;
        public ContenedorWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Article = new ArticleRepository(_db);
        }

        public ICategoryRepository Category {  get; private set; }
        public IArticleRepository Article { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
