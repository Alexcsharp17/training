using CarStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.DAL.Interfaces
{
    public interface IStoredProceduresService
    {
        Order GetOrder(int id);

        Person GetPerson(int id);

        void AddOrder(Order order);

        void AddPerson(Person person);

         void DeletePerson(int id);

        void DeleteOrder(int id);

        void UpdateOrder(Order order);

        void UpdatePerson(Person person);
    }
}
