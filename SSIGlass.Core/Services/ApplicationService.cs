using System;
using System.Collections.Generic;

namespace SSIGlass.Core.Services
{
    using Castle.Facilities.IBatisNetIntegration;
    using Castle.Services.Transaction;
    using DataAccess;
    using Contract.Services;
    using Contract;

    [Transactional]
    [UsesAutomaticSessionCreation]
    public class ApplicationService : IApplicationService
    {
        #region Transaction helpers

        public static void DoTrans(Action action)
        {
            DoTrans(TransactionMode.RequiresNew, IsolationMode.Serializable, false, action);
        }

        public static void DoTrans(TransactionMode transactionMode, IsolationMode isolationMode, bool isAmbient, Action action)
        {
            Trans.DoTrans(transactionMode, isolationMode, isAmbient, action);
        }

        public static TResult DoTrans<TResult>(Func<TResult> func)
        {
            return DoTrans(TransactionMode.RequiresNew, IsolationMode.Serializable, false, func);
        }

        public static TResult DoTrans<TResult>(TransactionMode transactionMode, IsolationMode isolationMode, bool isAmbient, Func<TResult> func)
        {
            return Trans.DoTrans(transactionMode, isolationMode, isAmbient, func);
        }

        #endregion
    }

    public class ApplicationService<TKey, T, TDao> : ApplicationService, IApplicationService<TKey, T>
        where T : class
        where TDao : IDao<TKey, T>
    {
        protected TDao Dao { get; set; }

        public ApplicationService(TDao dao)
        {
            Dao = dao;
        }

        public virtual T GetById(TKey id)
        {
            return Dao.GetById(id);
        }

        [Transaction]
        public virtual TKey Create(T instance)
        {
            return Dao.Create(instance);
        }

        [Transaction]
        public virtual bool Update(T instance)
        {
            return Dao.Update(instance);
        }

        [Transaction]
        public virtual bool Delete(TKey id)
        {
            return Dao.Delete(id);
        }

        public PagingResult<T> GetAll(int pageIndex, int pageSize)
        {
            int total;
            var paging = new ExtPaging { Start = (pageIndex - 1) * pageSize, Limit = pageSize };

            var list = Dao.GetAll(paging, out total);
            return new PagingResult<T>(list) { CurrentPage = pageIndex, PageSize = pageSize, TotalItems = total };
        }

        public IList<T> GetAll(ExtPaging paging)
        {
            return Dao.GetAll(paging);
        }
    }

    public class ApplicationService<TKey, T> : ApplicationService<TKey, T, IDao<TKey, T>> where T : class
    {
        public ApplicationService(IDao<TKey, T> dao) : base(dao) { }
    }
}
