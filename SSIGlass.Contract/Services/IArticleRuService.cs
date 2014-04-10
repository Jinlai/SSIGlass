using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIGlass.Contract.Services
{
    using Models;

    public interface IArticleRuService : IApplicationService<int, ArticleRu>
    {
        IList<ArticleRu> GetAll();
    }
}