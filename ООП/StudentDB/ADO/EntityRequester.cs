using Model;
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ADO
{
    internal abstract class EntityRequester<TEntity>
        where TEntity : AEntity<TEntity>
    {
        public EntityRequester() { }

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

        protected string SelectAllQuery => $"SELECT * FROM {Table}";

        protected string SelectOneQuery => SelectAllQuery + $" WHERE {IdFieldName}={Id}";

        protected abstract string InsertQuery { get; }

        protected abstract string UpdateQuery { get; }

        protected string DeleteQuery => $"DELETE FROM {Table} WHERE {IdFieldName}={Id}";

        protected abstract TEntity ReadOne(MySqlDataReader reader);

        protected ICollection<TEntity> ReadAll(MySqlDataReader reader)
        {
            ICollection<TEntity> collection = new HashSet<TEntity>();
            while (reader.Read())
                collection.Add(ReadOne(reader));
            return collection;
        }

        protected abstract void SetId(MySqlCommand command);

        protected abstract void SetData(MySqlCommand command);

        protected void Execute(string query, params Action<MySqlCommand>[] requesters)
        {
            using (MySqlConnection connection = new MySqlConnection(Const.ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                foreach (var requester in requesters)
                    requester(command);
                command.ExecuteNonQuery();
            }
        }

        protected T Execute<T>(string query, Func<MySqlDataReader, T> entityReader)
        {
            T result = default(T);
            using (MySqlConnection connection = new MySqlConnection(Const.ConnectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
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

        public TEntity SelectOne()
        {
            return Execute(SelectOneQuery, ReadOne);
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
