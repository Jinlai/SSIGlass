using System;

namespace SSIGlass.Core
{
    using Castle.Services.Transaction;
    using Microsoft.Practices.ServiceLocation;

    public static class Trans
    {
        #region Transaction helpers
        public static void DoTrans(Action action)
        {
            DoTrans(false, action);
        }

        public static void DoTrans(bool isAmbient, Action action)
        {
            DoTrans(TransactionMode.RequiresNew, IsolationMode.Serializable, isAmbient, action);
        }

        public static void DoTrans(TransactionMode transactionMode, IsolationMode isolationMode, bool isAmbient, Action action)
        {
            var tm = ServiceLocator.Current.GetInstance<ITransactionManager>();
            var tx = tm.CreateTransaction(transactionMode, isolationMode, isAmbient);
            try
            {
                tx.Begin();
                action();
                tx.Commit();
            }
            catch (Exception)
            {
                tx.Rollback();
                throw;
            }
            finally
            {
                tm.Dispose(tx);
            }
        }

        public static TResult DoTrans<TResult>(Func<TResult> func)
        {
            return DoTrans(false, func);
        }

        public static TResult DoTrans<TResult>(bool isAmbient, Func<TResult> func)
        {
            return DoTrans(TransactionMode.RequiresNew, IsolationMode.Serializable, isAmbient, func);
        }

        public static TResult DoTrans<TResult>(TransactionMode transactionMode, IsolationMode isolationMode, bool isAmbient, Func<TResult> func)
        {
            TResult result;
            var tm = ServiceLocator.Current.GetInstance<ITransactionManager>();
            var tx = tm.CreateTransaction(transactionMode, isolationMode, isAmbient);
            try
            {
                tx.Begin();
                result = func();
                tx.Commit();
            }
            catch (Exception)
            {
                tx.Rollback();
                throw;
            }
            finally
            {
                tm.Dispose(tx);
            }
            return result;
        }
        #endregion
    }
}
