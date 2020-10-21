using CarStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.DAL.Procedures
{
    public class PersonProceduresNames : IProceduresNames<Person>
    {
        private const string SP_INSERT_PERSON = "sp_InsertPerson";
        private const string SP_UPDATE_PERSON = "sp_UpdatePerson";
        private const string SP_DELETE_PERSON = "sp_DeletePerson";
        private const string SP_GET_PERSON = "sp_GetPerson";
        private const string SP_GET_PERSONS = "sp_GetPersons";
        private const string SP_FIND_PERSONS = "sp_FindPersons";
        private const string SP_GET_PERSONS_COUNT = "sp_GetPersonsCount";

        public string Insert => SP_INSERT_PERSON;
        public string Update => SP_UPDATE_PERSON;
        public string Delete => SP_DELETE_PERSON;
        public string Get => SP_GET_PERSON;
        public string GetEntities => SP_GET_PERSONS;
        public string Find => SP_FIND_PERSONS;
        public string Count => SP_GET_PERSONS_COUNT;

    }
}
