﻿using CarStore.DAL.Entities;
using CarStore.DAL.Enums;
using CarStore.DAL.Interfaces;
using CarStore.DAL.Util;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace CarStore.DAL.Services
{
    public class PersonService : IPersonService
    {
        private ICommandBuilder comandbuilder;
        public PersonService(ICommandBuilder comandbuilder)
        {
            this.comandbuilder = comandbuilder;
        }
        public void AddPerson(Person person)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {DBColumns.FIRST_NAME, person.FirstName },
                {DBColumns.LAST_NAME, person.LastName},
                {DBColumns.PHONE, person.Phone}
            };

            comandbuilder.DbDataPostCommand(StoredProceduresNames.sp_InsertPerson.ToString(),parameters);

         }

        public void DeletePerson(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>() { {DBColumns.ID, id } };

            comandbuilder.DbDataPostCommand(StoredProceduresNames.sp_DeletePerson.ToString(),parameters);
            
        }

        public Person GetPerson(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { DBColumns.ID, id } };
            
            using var reader = comandbuilder.DbDataRequestCommand(StoredProceduresNames.sp_GetPerson.ToString(), parameters);
            Person pers = new Person();
            if(reader.Read())
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

           comandbuilder.DbDataPostCommand(StoredProceduresNames.sp_DeletePerson.ToString(), parameters);

        }
        public List<Person> GetPersons()
        {
          
            List<Person> persons = new List<Person>();
            using var reader = comandbuilder.DbDataRequestCommand(StoredProceduresNames.sp_GetPersons.ToString(), null);

            while (reader.Read())
            {
                Person pers = new Person
                {
                    PersonID = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Phone = reader.GetString(3)
                };
                persons.Add(pers);
            }
            return persons;
        }
    }
}
