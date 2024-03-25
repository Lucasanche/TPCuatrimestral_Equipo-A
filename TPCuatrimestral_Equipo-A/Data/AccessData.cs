using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Data
{
    public class AccessData
    {
        private readonly MySqlConnection connection;
        private readonly MySqlCommand command;
        private MySqlDataReader reader;
        private string connectionString = "server=190.61.250.150;user=effort_admin;database=effort_callCenter;port=3306;password=EffortDB123;";

        public MySqlDataReader Reader
        {
            get { return reader; }
        }

        public AccessData()
        {
            this.connection = new MySqlConnection(connectionString);
            this.command = new MySqlCommand();
        }

        public void SetQuery(string query, List<MySqlParameter> parameters = null)
        {
            this.command.CommandType = CommandType.Text;
            this.command.CommandText = query;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
        }

        public bool ExecuteQuery()
        {
            try
            {
                this.command.Connection = this.connection;
                this.connection.Open();
                this.reader = this.command.ExecuteReader();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddParameter(string parameterName, object value)
        {
            command.Parameters.AddWithValue(parameterName, value);
        }

        public int ExecuteNonQuery()
        {
            try
            {
                this.command.Connection = this.connection;
                this.connection.Open();
                return this.command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int GetLastId(string table)
        {
            SetQuery($"SELECT MAX(Id) FROM {table}");
            reader = command.ExecuteReader();
            reader.Read();
            return Reader.GetInt32(0);
        }

        public void Close()
        {
            if (this.reader != null)
            {
                this.reader.Close();
            }
            if (this.connection.State == ConnectionState.Open)
            {
                this.connection.Close();
            }
        }
    }
}
