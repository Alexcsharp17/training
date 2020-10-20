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
        private IRepository<Person> personRepo;
        public PersonService(IRepository<Person> personRepo)
        {
            this.personRepo = personRepo;
        }
        public void AddPerson(Person person)
        {
            if (person.PersonID == 0)
            {
                personRepo.Add(person);
            }
            else
            {
                personRepo.Update(person, person.PersonID);
            }
            
        }

        public void DeletePerson(int id)
        {
            personRepo.Delete(id);
        }

        public Person GetPerson(int id)
        {
            return personRepo.Get(id);
        }

        public List<Person> GetPersons(int page, int pageSize, string sort)
        {
           return personRepo.GetByPaging(page,pageSize,sort);        
        }
       
        public int GetPersonsCount()
        {
            return personRepo.GetCount();
        }

        public List<Person> FindPersons(string pattern)
        {          
            return personRepo.Find(pattern);
        }
    }
}
