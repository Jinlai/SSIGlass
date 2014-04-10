using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIGlass.Core.Services
{
    using Contract.Models;
    using Contract.Services;
    using DataAccess;

    public class ArticleRuService : ApplicationService<int, ArticleRu, IArticleRuDao>, IArticleRuService
    {
        public ArticleRuService(IArticleRuDao dao)
            : base(dao)
        {

        }

        public IList<ArticleRu> GetAll()
        {
            return Dao.GetAll();
        }
    }
}