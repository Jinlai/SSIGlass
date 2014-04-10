using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIGlass.Core.DataAccess
{
    using Contract.Models;

    public interface IArticleRuDao : IDao<int, ArticleRu>
    {
        IList<ArticleRu> GetAll();
    }
}