using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIGlass.Core.DataAccess
{
    using Contract.Models;

    public interface IArticleDao : IDao<int, Article>
    {
        IList<Article> GetAll();
    }
}