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
    internal class ArticleRepository : Repository<Article>, IArticleRepository
    {
        private readonly ApplicationDbContext _db;
        public ArticleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Article article)
        {
            var objDb = _db.articles.FirstOrDefault(s => s.Id == article.Id);
            objDb.ArticleName = article.ArticleName;
            objDb.ArticleDescription = article.ArticleDescription;
			objDb.ArticleURL = article.ArticleURL;
			objDb.CategoryId = article.CategoryId;
			_db.SaveChanges();
        }
    }
}
