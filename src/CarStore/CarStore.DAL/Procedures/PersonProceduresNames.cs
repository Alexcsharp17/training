using CarStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.DAL.Procedures
{
    public class PersonProceduresNames : IProcedures<Person>
    {
        private const string sp_InsertPerson = "sp_InsertPerson";
        private const string sp_UpdatePerson = "sp_UpdatePerson";
        private const string sp_DeletePerson = "sp_DeletePerson";
        private const string sp_GetPerson = "sp_GetPerson";
        private const string sp_GetPersons = "sp_GetPersons";
        private const string sp_FindPersons = "sp_FindPersons";
        private const string sp_GetPersonsCount = "sp_GetPersonsCount";
        public string Insert => sp_InsertPerson;
        public string Update => sp_UpdatePerson;
        public string Delete => sp_DeletePerson;
        public string Get => sp_GetPerson;
        public string GetEntities => sp_GetPersons;
        public string Find => sp_FindPersons;
        public string Count => sp_GetPersonsCount;

    }
}
