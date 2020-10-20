using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CarStore.DAL.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(int id);
        T Get(int id);
        void Update(T entity, int id);
        List<T> GetByPaging(int page, int pageSize, string sort);
        List<T> Find(string pattern);
        int GetCount();
    }
}
