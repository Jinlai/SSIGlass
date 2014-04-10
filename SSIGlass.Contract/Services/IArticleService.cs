using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIGlass.Contract.Services
{
    using Models;

    public interface IArticleService : IApplicationService<int, Article>
    {
        IList<Article> GetAll();
    }
}