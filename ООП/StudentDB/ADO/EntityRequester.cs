using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ADO
{
    internal abstract class EntityRequester<TEntity>
        where TEntity : AEntity<TEntity>
    {
        public EntityRequester(long id)
        {
            Id = id;
        }

        public EntityRequester(TEntity entity)
        {
            Entity = entity;
        }

        protected long Id { get; }

        protected TEntity Entity { get; }

        protected abstract string Table { get; }

        protected abstract string IdFieldName { get; }

        protected string SelectAllQuery(long id) => $"SELECT * FROM {Table}";

        protected string SelectOneQuery(long id) => SelectAllQuery(id) + $" WHERE {IdFieldName}={id}";

        protected abstract string InsertQuery { get; }

        protected abstract string UpdateQuery { get; }

        protected abstract string DeleteQuery { get; }

        protected abstract TEntity ReadOne(MySqlDataReader reader);

        protected IEnumerable<TEntity> ReadAll(MySqlDataReader reader)
        {
            while (reader.Read())
                yield return ReadOne(reader);
        }

        protected abstract void SetId(MySqlCommand command);

        protected abstract void SetData(MySqlCommand command);

        protected void Execute(string query, params SetQueryData<TEntity>[] requesters)
        {
            using (MySqlConnection connection = new MySqlConnection(Const.ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                foreach (var requester in requesters)
                    requester(command);
                command.ExecuteNonQuery();
            }
        }

        protected T Execute<T>(Func<long, string> query, Func<MySqlDataReader, T> entityReader, long id = -1)
        {
            T result = default(T);
            using (MySqlConnection connection = new MySqlConnection(Const.ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query(id), connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                result = entityReader(reader);
            }
            return result;
        }

        public IEnumerable<TEntity> SelectAll()
        {
            return Execute(SelectAllQuery, ReadAll);
        }

        public TEntity SelectOne(long id)
        {
            return Execute(SelectOneQuery, ReadOne, id);
        }

        public void Insert()
        {
            Execute(InsertQuery, SetId, SetData);
        }

        public void Update()
        {
            Execute(UpdateQuery, SetData);
        }

        public void Delete()
        {
            Execute(DeleteQuery, SetId);
        }
    }
}
