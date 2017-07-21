using MicroBotServices.DataLayer.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MicroBotServices.DataLayer
{
    /// <summary>
    /// Base repository class for all database operations.
    /// </summary>
    public class Repository : IDisposable
    {
        public static string GetStringResult(string query)
        {
            return ExecuteScalar<string>(query);
        }

        public static IEnumerable<TEntity> GetAll<TEntity>(string query, Action<MySqlDataReader, IList<TEntity>> action)
        {
            return ExecuteReader(query, action);
        }

        public static TEntity Get<TEntity>(string query, Action<MySqlDataReader, TEntity> action, TEntity instance)
        {
            return ExecuteReader(query, action, instance);
        }

        public static int Create(string query)
        {
            return ExecuteNonQuery<int>(query);
        }

        public static int GetCount(string query)
        {
            return ExecuteScalar<int>(query);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }


        #region Helper Methods

        private static T ExecuteNonQuery<T>(string query) where T : struct
        {
            object result;

            using (var transaction = new TransactionScope())
            {
                using (var connection = new MySqlConnection(Utilities.ConnectionString))
                {
                    using (var command = GetCommand(query))
                    {
                        command.Connection = connection;
                        connection.Open();
                        result = command.ExecuteNonQuery();
                    }
                }
                transaction.Complete();
            }

            return (T)Convert.ChangeType(result, typeof(T), CultureInfo.CurrentCulture);
        }

        private static IEnumerable<TEntity> ExecuteReader<TEntity>(string query, Action<MySqlDataReader, IList<TEntity>> action)
        {
            var entities = new List<TEntity>();
            using (var connection = new MySqlConnection(Utilities.ConnectionString))
            {
                var command = GetCommand(query);
                command.Connection = connection;
                connection.Open();
                using (var dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        action(dr, entities);
                    }
                }
            }
            return entities;
        }

        private static TEntity ExecuteReader<TEntity>(string query, Action<MySqlDataReader, TEntity> action, TEntity entity)
        {
            using (var connection = new MySqlConnection(Utilities.ConnectionString))
            {
                var command = GetCommand(query);
                command.Connection = connection;
                connection.Open();
                using (var dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        action(dr, entity);
                    }
                    else
                    {
                        entity = default(TEntity);
                    }
                }
            }
            return entity;
        }

        private static T ExecuteScalar<T>(string query)
        {
            object result;
            using (var transaction = new TransactionScope())
            {
                using (var connection = new MySqlConnection(Utilities.ConnectionString))
                {
                    using (var command = GetCommand(query))
                    {
                        command.Connection = connection;
                        connection.Open();
                        result = command.ExecuteScalar();
                    }
                }
                transaction.Complete();
            }
            return ChangeType<T>(result);
        }

        private static T ChangeType<T>(object value)
        {
            var t = typeof(T);
            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (value == null || value.Equals(DBNull.Value))
                {
                    return default(T);
                }

                t = Nullable.GetUnderlyingType(t);
            }

            return (T)Convert.ChangeType(value, t, CultureInfo.CurrentCulture);
        }

        protected static MySqlCommand GetCommand(string query)
        {
            var command = new MySqlCommand
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = query
            };
            return command;
        }

        #endregion
    }
}
