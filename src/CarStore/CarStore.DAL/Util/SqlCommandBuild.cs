using CarStore.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public SqlCommandBuild(DbConnection connection)
        {
            this.connection = connection;
        }

        public DataTable DbDataReaderCommand(string procedure, Dictionary<string, object> parameters = null)
        {
            try
            {
                connection.Open();
                using (var reader = Create(procedure, parameters).ExecuteReader())
                {
                    DataTable dtData = new DataTable("Data");
                    DataTable dtSchema = new DataTable("Schema");

                    if (reader != null)
                    {
                        dtSchema = reader.GetSchemaTable();
                        foreach (DataRow schemarow in dtSchema.Rows)
                        {
                            dtData.Columns.Add(schemarow.ItemArray[0].ToString()
                                    , Type.GetType(schemarow.ItemArray[12].ToString()));

                        }

                        while (reader.Read())
                        {
                            object[] ColArray = new object[reader.FieldCount];
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                if (reader[i] != null) ColArray[i] = reader[i];
                            }

                            dtData.LoadDataRow(ColArray, true);
                        }

                        reader.Close();
                    }

                    return dtData;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public int DbDataScalarCommand(string procedure, Dictionary<string, object> parameters = null)
        {
            try
            {
                connection.Open();
                using (var comand = Create(procedure, parameters))
                {
                    var res = comand.ExecuteScalar();
                    return res == null ? 0 : (int)res;
                }
            }
            finally
            {
                connection.Close();
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
