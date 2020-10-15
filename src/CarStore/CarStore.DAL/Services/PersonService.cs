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

        public void DeletePerson(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { DBColumns.ID, id } };

             comandbuilder.DbDataScalarCommand(StoredProceduresNames.sp_DeletePerson.ToString(), parameters);
        }

        public Person GetPerson(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { DBColumns.ID, id } };

             using var dataTable = comandbuilder.DbDataReaderCommand(StoredProceduresNames.sp_GetPerson.ToString(), parameters);
             Person pers = new Person();
             if (dataTable.Rows.Count==1)
             {
                 pers.PersonID = Convert.ToInt32(dataTable.Rows[0][DBColumns.PERSON_ID.Replace("@","")]);
                 pers.FirstName = Convert.ToString(dataTable.Rows[0][DBColumns.FIRST_NAME.Replace("@","")]);
                 pers.LastName = Convert.ToString(dataTable.Rows[0][DBColumns.LAST_NAME.Replace("@","")]);
                 pers.Phone = Convert.ToString(dataTable.Rows[0][DBColumns.PHONE.Replace("@","")]);
             }
             return pers;
            
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
            using var dataTable = comandbuilder.DbDataReaderCommand(StoredProceduresNames.sp_GetPersons.ToString(), parameters);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Person pers = new Person()
                {
                    PersonID = Convert.ToInt32(dataRow[DBColumns.PERSON_ID.Replace("@", "")]),
                    FirstName = Convert.ToString(dataRow[DBColumns.FIRST_NAME.Replace("@", "")]),
                    LastName = Convert.ToString(dataRow[DBColumns.LAST_NAME.Replace("@", "")]),
                    Phone = Convert.ToString(dataRow[DBColumns.PHONE.Replace("@", "")])
                };
                persons.Add(pers);
            }
            return persons;
        }
        public List<Person> GetAllPersons()
        {
            List<Person> persons = new List<Person>();
             using var dataTable = comandbuilder.DbDataReaderCommand(StoredProceduresNames.sp_GetAllPersons.ToString());


             foreach (DataRow dataRow in dataTable.Rows)
             {
                 Person pers = new Person()
                 {
                     PersonID = Convert.ToInt32(dataRow[DBColumns.PERSON_ID.Replace("@", "")]),
                     FirstName = Convert.ToString(dataRow[DBColumns.FIRST_NAME.Replace("@", "")]),
                     LastName = Convert.ToString(dataRow[DBColumns.LAST_NAME.Replace("@", "")]),
                     Phone = Convert.ToString(dataRow[DBColumns.PHONE.Replace("@", "")])
                 };
                 persons.Add(pers);
             }
             return persons;
        }
        public int GetPersonsCount()
        {
            return comandbuilder.DbDataScalarCommand(StoredProceduresNames.sp_GetPersonsCount.ToString());
        }

        public List<Person> FindPersons(string pattern)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {DBColumns.PATTERN,pattern },
            };
            List<Person> persons = new List<Person>();
            using var dataTable = comandbuilder.DbDataReaderCommand(StoredProceduresNames.sp_FindPersons.ToString(), parameters);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Person pers = new Person()
                {
                    PersonID = Convert.ToInt32(dataRow[DBColumns.PERSON_ID.Replace("@", "")]),
                    FirstName = Convert.ToString(dataRow[DBColumns.FIRST_NAME.Replace("@", "")]),
                    LastName = Convert.ToString(dataRow[DBColumns.LAST_NAME.Replace("@", "")]),
                    Phone = Convert.ToString(dataRow[DBColumns.PHONE.Replace("@", "")])
                };
                persons.Add(pers);
            }
            return persons;
        }
    }
}
