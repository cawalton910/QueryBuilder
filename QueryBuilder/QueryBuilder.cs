using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace QueryBuilder
{
    class QueryBuilder : IDisposable
    {
        private SqliteConnection connection;
        public QueryBuilder(string locationOfDatabase)
        {
            connection = new SqliteConnection("Data Source=" + locationOfDatabase);             
            connection.Open();       
        }



        public T Read<T>(int id) where T : new()
        {
            
            var command = new SqliteCommand($"select * from {typeof(T).Name} where Id = {id}", connection);
            var reader = command.ExecuteReader();
            var data = new T();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    typeof(T).GetProperty(reader.GetName(i)).SetValue(data, reader.GetValue(i));
                }
            }
            return data;
        }

        public List<T> ReadAll<T>() where T : new()
        {

            var command = new SqliteCommand($"select * from {typeof(T).Name}", connection);
            var reader = command.ExecuteReader();
            var data = new List<T>();
            while (reader.Read())
            {
                var item = new T();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    typeof(T).GetProperty(reader.GetName(i)).SetValue(item, reader.GetValue(i));
                }
                data.Add(item);
            }
            return data;
        }

        public void Create<T>(T obj)
        {
            List<string> properties = new List<string>();
            foreach (var item in typeof(T).GetProperties())
            {
                var value = item.GetValue(obj);
                if (value.GetType().ToString().Equals("System.String"))
                {
                    value = "'" + value + "'";
                }
                
                properties.Add(value.ToString());
            }
            string propertyValues = string.Join(", ", properties);
            var command = new SqliteCommand($"insert into {typeof(T).Name} values({propertyValues})", connection);
            Console.WriteLine(command.CommandText);
            command.ExecuteNonQuery();
        }

        public void Update<T>(T obj)
        {
            List<string> properties = new List<string>();
            string Id = typeof(T).GetProperty("Id").GetValue(obj).ToString();
            foreach (var item in typeof(T).GetProperties())
            {
                var value = item.GetValue(obj);
                if (value.GetType().ToString().Equals("System.String"))
                {
                    value = "'" + value + "'";
                }
                value = item.Name + " = " + value;
                properties.Add(value.ToString());
            }
            string propertyValues = string.Join(", ", properties);
            var command = new SqliteCommand($"update {typeof(T).Name} set {propertyValues} where Id = {Id}", connection);
            Console.WriteLine(command.CommandText);
            command.ExecuteNonQuery();
        }

        public void Delete<T>(T obj) 
        {
            string Id = typeof(T).GetProperty("Id").GetValue(obj).ToString();
            var command = new SqliteCommand($"delete from {typeof(T).Name} where Id = {Id}", connection);
            Console.WriteLine(command.CommandText);
            command.ExecuteNonQuery();

        }
        public void Dispose()
        {
            connection.Close();
        }

    }
}
