using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIGlass.Core.Services
{
    using Contract.Models;
    using Contract.Services;
    using DataAccess;

    public class ArticleService : ApplicationService<int, Article, IArticleDao>, IArticleService
    {
        public ArticleService(IArticleDao dao) : base(dao)
        {

        }

        public IList<Article> GetAll()
        {
            return Dao.GetAll();
        }
    }
}