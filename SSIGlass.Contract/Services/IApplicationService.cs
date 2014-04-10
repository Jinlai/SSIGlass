using System.Collections.Generic;

namespace SSIGlass.Contract.Services
{
    public interface IApplicationService
    {

    }

    public interface IApplicationService<TKey, T> : IApplicationService
    {
        T GetById(TKey id);

        TKey Create(T instance);

        bool Update(T instance);

        bool Delete(TKey id);

        PagingResult<T> GetAll(int pageIndex, int pageSize);

        IList<T> GetAll(ExtPaging paging);
    }
}