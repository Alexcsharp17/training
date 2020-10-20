using CarStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.DAL.Interfaces
{
    public interface IPersonService
    {
        Person GetPerson(int id);

        void AddPerson(Person person);

        void DeletePerson(int id);

        List<Person> GetPersons(int page, int pageSize, string sort);

        int GetPersonsCount();

        List<Person> FindPersons(string pattern);
    }
}
