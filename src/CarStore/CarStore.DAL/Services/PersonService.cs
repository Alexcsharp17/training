using CarStore.DAL.Entities;
using CarStore.DAL.Enums;
using CarStore.DAL.Interfaces;
using CarStore.DAL.Util;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CarStore.DAL.Services
{
    public class PersonService : IPersonService
    {
        private SqlCommandBuild comandbuilder;
        public PersonService(SqlCommandBuild commandBuild)
        {
            this.comandbuilder = commandBuild;
        }
        public void AddPerson(Person person)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            foreach (var prop in person.GetType().GetProperties())
            {
                d.Add(prop.Name.ToString(), prop.GetValue(person));
            }
            
            using SqlCommand command = comandbuilder.Create(StoredProceduresNames.sp_InsertPerson.ToString(),d);
            
            command.ExecuteScalar();
         }

        public void DeletePerson(int id)
        {
            Dictionary<string, object> d = new Dictionary<string, object>() { { "id", id } };

            using SqlCommand command = comandbuilder.Create(StoredProceduresNames.sp_DeletePerson.ToString(),d);

            SqlParameter idParam = new SqlParameter
            {
                ParameterName = DBColumns.id,
                Value = id
            };
            command.Parameters.Add(idParam);
            command.ExecuteScalar();
        }

        public Person GetPerson(int id)
        {
            Dictionary<string, object> d = new Dictionary<string, object>() { { "id", id } };
            using SqlCommand command = comandbuilder.Create(StoredProceduresNames.sp_GetPerson.ToString(),d);             
            
            var reader = command.ExecuteReader();
            Person pers = new Person();
            while (reader.Read())
            {
                pers.PersonID = reader.GetInt32(0);
                pers.FirstName = reader.GetString(1);
                pers.LastName = reader.GetString(2);
                pers.Phone = reader.GetString(3);
            }
            return pers;

        }

        public void UpdatePerson(Person person)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            foreach (var prop in person.GetType().GetProperties())
            {
                d.Add(prop.Name.ToString(), prop.GetValue(person));
            }

            using SqlCommand command = comandbuilder.Create(StoredProceduresNames.sp_DeletePerson.ToString(),d);
            
            command.ExecuteScalar();
        }
    }
}
