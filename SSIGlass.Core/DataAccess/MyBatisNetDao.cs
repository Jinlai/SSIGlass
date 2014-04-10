using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SSIGlass.Core.DataAccess
{
    using IBatisNet.DataMapper;

    public class MyBatisNetDao : IDao
    {
        protected readonly ISqlMapper SqlMap;

        protected MyBatisNetDao()
        {
            SqlMap = Mapper.Instance();
        }

        protected virtual IList<T> GetAll<T>(string statementName, IDictionary<string, object> parameters, out int total)
        {
            var items = SqlMap.QueryForList<T>(statementName, parameters);
            total = (int)parameters["total"];
            return items;
        }

        protected virtual IList<T> GetAll<T>(string statementName, IDictionary<string, object> parameters, RowDelegate<T> rowDelegate, out int total)
        {
            var items = SqlMap.QueryWithRowDelegate(statementName, parameters, rowDelegate);
            total = (int)parameters["total"];
            return items;
        }

        protected IDbCommand GetCommand(string statementName, object paramObject)
        {
            var statement = SqlMap.GetMappedStatement(statementName);
            var scope = statement.Statement.Sql.GetRequestScope(statement, paramObject, SqlMap.LocalSession);
            statement.PreparedCommand.Create(scope, SqlMap.LocalSession, statement.Statement, paramObject);

            var command = SqlMap.LocalSession.CreateCommand(scope.IDbCommand.CommandType);
            command.CommandText = scope.IDbCommand.CommandText;
            foreach (IDataParameter pa in scope.IDbCommand.Parameters)
            {
                var para = SqlMap.LocalSession.CreateDataParameter();
                para.ParameterName = pa.ParameterName;
                para.Value = pa.Value;
                para.DbType = pa.DbType;
                para.Direction = pa.Direction;
                command.Parameters.Add(para);
            }
            return command;
        }        

        protected DataSet QueryForDataSet(string statementName, object paramObject)
        {
            var ds = new DataSet();
            var command = GetCommand(statementName, paramObject);
            SqlMap.LocalSession.CreateDataAdapter(command).Fill(ds);
            return ds;
        }

        protected DataSet QueryForDataSet(string statementName, object paramObject, out IDictionary<string, object> outputs)
        {
            var ds = new DataSet();
            var command = GetCommand(statementName, paramObject);
            SqlMap.LocalSession.CreateDataAdapter(command).Fill(ds);
            outputs = new Dictionary<string, object>();
            foreach (var parameter in command.Parameters.Cast<IDataParameter>().Where(parameter => parameter.Direction == ParameterDirection.Output))
            {
                outputs[parameter.ParameterName] = parameter.Value;
            }
            return ds;
        }
    }

    public class MyBatisNetDao<TKey, T> : MyBatisNetDao
    {
        protected virtual T GetById(string statementName, TKey id)
        {
            return SqlMap.QueryForObject<T>(statementName, id);
        }

        protected virtual TKey Create(string statementName, T instance)
        {
            return (TKey)SqlMap.Insert(statementName, instance);
        }

        protected virtual int Update(string statementName, T instance)
        {
            return SqlMap.Update(statementName, instance);
        }

        protected virtual int Delete(string statementName, TKey id)
        {
            return SqlMap.Delete(statementName, id);
        }

        protected virtual IList<T> GetAll(string statementName, IDictionary<string, object> parameters, out int total)
        {
            return GetAll<T>(statementName, parameters, out total);
        }
    }

    static class CollectionExtensions
    {
        public static IDictionary<TKey, IList<TValue>> GroupDictionary<TKey, TValue>(this ICollection<TValue> collection, Func<TValue, TKey> keySelector)
        {
            return collection.GroupBy(keySelector, v => v).ToDictionary(g => g.Key, g => (IList<TValue>)g.ToList());
        }
    }
}
