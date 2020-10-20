using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CarStore.DAL.Interfaces
{
    public interface IMapper<T>
    {
        public T Map(DataRow dataRow);

        public Dictionary<string, object> Map(T entity);
    }
}
