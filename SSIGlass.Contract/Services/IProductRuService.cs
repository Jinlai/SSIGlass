using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSIGlass.Contract.Services
{
    using Models;

    public interface IProductRuService : IApplicationService<int, ProductRu>
    {
        IList<ProductRu> GetAll(int categoryId);

        IList<ProductRu> GetAll();
    }
}