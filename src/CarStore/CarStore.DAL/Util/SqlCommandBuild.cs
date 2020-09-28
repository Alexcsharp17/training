using CarStore.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CarStore.DAL.Util
{
    public class SqlCommandBuild
    {
        public string DefaultConnection { get; set; }

        public SqlCommandBuild(string connection)
        {
            this.DefaultConnection = connection;
        }
        public SqlCommand Create(string procedure, Dictionary<string, object> parameters=null)
        {
            SqlConnection connection = new SqlConnection(DefaultConnection);           
            connection.Open();
            SqlCommand command = new SqlCommand(procedure, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            if (parameters!=null)
            {
                foreach (KeyValuePair<string, object> keyValue in parameters)
                {
                    SqlParameter param = new SqlParameter
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
