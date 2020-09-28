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
        public DbConnection connection { get; set; }

        public SqlCommandBuild(DbConnection connection)
        {
            this.connection = connection;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        
        public DbCommand Create(string procedure, Dictionary<string, object> parameters=null)
        {

            DbCommand command = new SqlCommand();
            command.CommandText = procedure;
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            if (parameters!=null)
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
