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
                    comandbuilder.DbDataScalarCommand(StoredProceduresNames.sp_InsertPerson.ToString(), parameters);
                }
                else
                {
                    parameters.Add(DBColumns.ID, person.PersonID);
                    comandbuilder.DbDataScalarCommand(StoredProceduresNames.sp_UpdatePerson.ToString(), parameters);
                }
            }

           
        }

        public void DeletePerson(int id)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var comandbuilder = scope.ServiceProvider.GetService<ICommandBuilder>();

                Dictionary<string, object> parameters = new Dictionary<string, object>() { { DBColumns.ID, id } };

                comandbuilder.DbDataScalarCommand(StoredProceduresNames.sp_DeletePerson.ToString(), parameters);
            }

        }

        public Person GetPerson(int id)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var comandbuilder = scope.ServiceProvider.GetService<ICommandBuilder>();
                Dictionary<string, object> parameters = new Dictionary<string, object>() { { DBColumns.ID, id } };

                using var dataTable = comandbuilder.DbDataReaderCommand(StoredProceduresNames.sp_GetPerson.ToString(), parameters);
                Person pers = new Person();
                if (dataTable.Rows.Count==1)
                {
                    pers.PersonID = Convert.ToInt32(dataTable.Rows[0]["PersonId"]);
                    pers.FirstName = Convert.ToString(dataTable.Rows[0]["FirstName"]);
                    pers.LastName = Convert.ToString(dataTable.Rows[0]["LastName"]);
                    pers.Phone = Convert.ToString(dataTable.Rows[0]["Phone"]);
                }
                return pers;
            }

        }

        public List<Person> GetPersons(int page,int pageSize,string sort)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var comandbuilder = scope.ServiceProvider.GetService<ICommandBuilder>();

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {DBColumns.PAGE,page },
                    {DBColumns.PAGE_SIZE,pageSize},
                    {DBColumns.SORT_COLUMN,sort}
                };
                List<Person> persons = new List<Person>();
                using var dataTable = comandbuilder.DbDataReaderCommand(StoredProceduresNames.sp_GetPersons.ToString(), parameters);

                foreach (var dataRow in dataTable.Rows)
                {
                    Person pers = new Person()
                    {
                        PersonID = Convert.ToInt32(dataTable.Rows[0]["PersonId"]),
                        FirstName = Convert.ToString(dataTable.Rows[0]["FirstName"]),
                        LastName = Convert.ToString(dataTable.Rows[0]["LastName"]),
                        Phone = Convert.ToString(dataTable.Rows[0]["Phone"]),
                    };
                    persons.Add(pers);
                }
                return persons;
            }

        }
        public List<Person> GetAllPersons()
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var comandbuilder = scope.ServiceProvider.GetService<ICommandBuilder>();
                List<Person> persons = new List<Person>();
                using var dataTable = comandbuilder.DbDataReaderCommand(StoredProceduresNames.sp_GetAllPersons.ToString());


                foreach (var dataRow in dataTable.Rows)
                {
                    Person pers = new Person()
                    {
                        PersonID = Convert.ToInt32(dataTable.Rows[0]["PersonId"]),
                        FirstName = Convert.ToString(dataTable.Rows[0]["FirstName"]),
                        LastName = Convert.ToString(dataTable.Rows[0]["LastName"]),
                        Phone = Convert.ToString(dataTable.Rows[0]["Phone"]),
                    };
                    persons.Add(pers);
                }

                return persons;
            }

           
        }
        public int GetPersonsCount()
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var comandbuilder = scope.ServiceProvider.GetService<ICommandBuilder>();
                return comandbuilder.DbDataScalarCommand(StoredProceduresNames.sp_GetPersonsCount.ToString());
            }

        }

        public List<Person> FindPersons(string pattern)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var comandbuilder = scope.ServiceProvider.GetService<ICommandBuilder>();

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {DBColumns.PATTERN,pattern },
                };
                List<Person> persons = new List<Person>();
                using var dataTable = comandbuilder.DbDataReaderCommand(StoredProceduresNames.sp_FindPersons.ToString(), parameters);

                foreach (var dataRow in dataTable.Rows)
                {
                    Person pers = new Person()
                    {
                        PersonID = Convert.ToInt32(dataTable.Rows[0]["PersonId"]),
                        FirstName = Convert.ToString(dataTable.Rows[0]["FirstName"]),
                        LastName = Convert.ToString(dataTable.Rows[0]["LastName"]),
                        Phone = Convert.ToString(dataTable.Rows[0]["Phone"]),
                    };
                    persons.Add(pers);
                }
                return persons;
            }

           
        }
    }
}
