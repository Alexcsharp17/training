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

            using SqlCommand command = comandbuilder.Create(StoredProceduresNames.sp_InsertPerson.ToString());
            SqlParameter FirstName = new SqlParameter
            {
                ParameterName = "@"+DBColumns.FirstName,
                Value = person.FirstName
            };
            command.Parameters.Add(FirstName);

            SqlParameter LastName = new SqlParameter
            {
                ParameterName = "@"+DBColumns.LastName,
                Value = person.LastName
            };
            command.Parameters.Add(LastName);

            SqlParameter Phone = new SqlParameter
            {
                ParameterName = "@"+DBColumns.Phone,
                Value = person.Phone
            };
            command.Parameters.Add(Phone);
            command.ExecuteScalar();

         }

        public void DeletePerson(int id)
        {
            
            using SqlCommand command = comandbuilder.Create(StoredProceduresNames.sp_DeletePerson.ToString());

            SqlParameter idParam = new SqlParameter
            {
                ParameterName = "@"+DBColumns.id,
                Value = id
            };
            command.Parameters.Add(idParam);
            command.ExecuteScalar();
        }

        public Person GetPerson(int id)
        {
           using SqlCommand command = comandbuilder.Create(StoredProceduresNames.sp_GetPerson.ToString());
            SqlParameter idParam = new SqlParameter
            {
                ParameterName = "@"+DBColumns.id,
                Value = id
            };
            command.Parameters.Add(idParam);
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
            using SqlCommand command = comandbuilder.Create(StoredProceduresNames.sp_DeletePerson.ToString());
            SqlParameter idParam = new SqlParameter
            {
                ParameterName = "@"+DBColumns.id,
                Value = person.PersonID
            };
            command.Parameters.Add(idParam);

            SqlParameter FirstName = new SqlParameter
            {
                ParameterName = "@"+DBColumns.FirstName,
                Value = person.FirstName
            };
            command.Parameters.Add(FirstName);

            SqlParameter LastName = new SqlParameter
            {
                ParameterName = "@"+DBColumns.LastName,
                Value = person.LastName
            };
            command.Parameters.Add(LastName);

            SqlParameter Phone = new SqlParameter
            {
                ParameterName = "@"+DBColumns.Phone,
                Value = person.Phone
            };
            command.Parameters.Add(Phone);
            command.ExecuteScalar();
        }
    }
}
