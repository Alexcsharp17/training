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
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {DBColumns.FIRST_NAME, person.FirstName },
                {DBColumns.LAST_NAME, person.LastName},
                {DBColumns.PHONE, person.Phone}
            };

            using SqlCommand command = comandbuilder.Create(StoredProceduresNames.sp_InsertPerson.ToString(),parameters);
            
            command.ExecuteScalar();
         }

        public void DeletePerson(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>() { {DBColumns.ID, id } };

            using SqlCommand command = comandbuilder.Create(StoredProceduresNames.sp_DeletePerson.ToString(),parameters);
          
            command.ExecuteScalar();
        }

        public Person GetPerson(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { DBColumns.ID, id } };
            using SqlCommand command = comandbuilder.Create(StoredProceduresNames.sp_GetPerson.ToString(),parameters);             
            
            var reader = command.ExecuteReader();
            Person pers = new Person();
            while(reader.Read())
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
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {DBColumns.FIRST_NAME, person.FirstName },
                {DBColumns.LAST_NAME, person.LastName},
                {DBColumns.PHONE, person.Phone}
            };

            using SqlCommand command = comandbuilder.Create(StoredProceduresNames.sp_DeletePerson.ToString(),parameters);
            
            command.ExecuteScalar();
        }
    }
}
