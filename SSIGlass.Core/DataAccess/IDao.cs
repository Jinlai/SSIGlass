using System.Collections.Generic;

namespace SSIGlass.Core.DataAccess
{
    using Contract;

    public interface IDao
    {

    }

    public interface IDao<TKey, TInstance> : IDao
    {
        TInstance GetById(TKey id);

        TKey Create(TInstance instance);

        bool Update(TInstance instance);

        bool Delete(TKey id);

        IList<TInstance> GetAll(ExtPaging paging, out int total);

        IList<TInstance> GetAll(ExtPaging paging);
    }
}