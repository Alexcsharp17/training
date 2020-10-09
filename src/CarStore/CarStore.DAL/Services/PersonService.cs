using CarStore.DAL.Entities;
using CarStore.DAL.Enums;
using CarStore.DAL.Interfaces;
using CarStore.DAL.Util;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace CarStore.DAL.Services
{
    public class PersonService : IPersonService
    {
        private ICommandBuilder comandbuilder;
        private IServiceScopeFactory scopeFactory;
        public PersonService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
            using (var scope = scopeFactory.CreateScope())
            {
                var comandbuilder = scope.ServiceProvider.GetService<ICommandBuilder>();

            }
        }
        public void AddPerson(Person person)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var comandbuilder = scope.ServiceProvider.GetService<ICommandBuilder>();

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {DBColumns.FIRST_NAME, person.FirstName },
                    {DBColumns.LAST_NAME, person.LastName},
                    {DBColumns.PHONE, person.Phone}
                };

                if (person.PersonID == 0)
                {
                    comandbuilder.DbDataPostCommand(StoredProceduresNames.sp_InsertPerson.ToString(), parameters);
                }
                else
                {
                    parameters.Add(DBColumns.ID, person.PersonID);
                    comandbuilder.DbDataPostCommand(StoredProceduresNames.sp_UpdatePerson.ToString(), parameters);
                }
            }
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
            if (person.PersonID == 0)
            {
                comandbuilder.DbDataPostCommand(StoredProceduresNames.sp_InsertPerson.ToString(), parameters);
            }
            else
            {
                parameters.Add(DBColumns.ID,person.PersonID);
                comandbuilder.DbDataPostCommand(StoredProceduresNames.sp_UpdatePerson.ToString(), parameters);
            }

        }
        public List<Person> GetPersons(int page,int pageSize,string sort)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {DBColumns.PAGE,page },
                {DBColumns.PAGE_SIZE,pageSize},
                {DBColumns.SORT_COLUMN,sort}
            };
            List<Person> persons = new List<Person>();
            using var reader = comandbuilder.DbDataRequestCommand(StoredProceduresNames.sp_GetPersons.ToString(), parameters);


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
            reader.Close();
            return persons;
        }
        public List<Person> GetAllPersons()
        {
            List<Person> persons = new List<Person>();
            using var reader = comandbuilder.DbDataRequestCommand(StoredProceduresNames.sp_GetAllPersons.ToString());

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
        public int GetPersonsCount()
        {
            return comandbuilder.DbDataPostCommand(StoredProceduresNames.sp_GetPersonsCount.ToString());
        }

        public List<Person> FindPersons(string pattern)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {DBColumns.PATTERN,pattern },
            };
            List<Person> persons = new List<Person>();
            using var reader = comandbuilder.DbDataRequestCommand(StoredProceduresNames.sp_FindPersons.ToString(),parameters);
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
