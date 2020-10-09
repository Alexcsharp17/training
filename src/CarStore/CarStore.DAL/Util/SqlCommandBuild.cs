using CarStore.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using CarStore.DAL.Interfaces;

namespace CarStore.DAL.Util
{
    public class SqlCommandBuild : ICommandBuilder
    {
        private DbConnection connection;
        //public DbConnection Connection
        //{
        //    get
        //    {
        //        if (connection.State != ConnectionState.Open)
        //        {
        //            connection.Open();
        //        }

        //        return connection;
        //    }
        //    set
        //    {
        //        connection = value;
        //    }
            
        //}

        public SqlCommandBuild(DbConnection connection)
        {
            this.connection = connection;
        }
        
        public DbDataReader DbDataRequestCommand(string procedure, Dictionary<string, object> parameters=null)
        {
            connection.Open();
            var reader = Create(procedure, parameters).ExecuteReader();
            connection.Close();
            return reader;
        }
        public int DbDataPostCommand(string procedure, Dictionary<string, object> parameters = null)
        {
            using (var comand = Create(procedure, parameters))
            {
                var res = comand.ExecuteScalar();
                return res == null ? 0 :(int)res;
            }
        }

        private DbCommand Create(string procedure, Dictionary<string, object> parameters = null)
        {
            DbCommand command = new SqlCommand();
            command.CommandText = procedure;
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> keyValue in parameters)
                {
                    DbParameter param = new SqlParameter
                    {
                        ParameterName = keyValue.Key,
                        Value = keyValue.Value
                    };
                    command.Parameters.Add(param);
                }
            }
            return command;
        }
    }
}
