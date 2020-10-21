using CarStore.DAL.Enums;
using CarStore.DAL.Interfaces;
using CarStore.DAL.Procedures;
using CarStore.DAL.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading;

namespace CarStore.DAL.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private IMapper<T> mapper;
        private ICommandBuilder comandbuilder;
        private IProceduresNames<T> procedures;
        public Repository(ICommandBuilder comandbuilder, IMapper<T> mapper, IProceduresNames<T> procedures)
        {
            this.comandbuilder = comandbuilder;
            this.mapper = mapper;
            this.procedures = procedures;
        }

        public void Add(T entity)
        {          
            var parameters= this.mapper.Map(entity);

            comandbuilder.DbDataScalarCommand(procedures.Insert, parameters);        
        }

        public void Update(T entity,int id)
        {
            var parameters = this.mapper.Map(entity);
            parameters.Add(DBColumns.ID, id);
            comandbuilder.DbDataScalarCommand(procedures.Update, parameters);
        }

        public void Delete(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { DBColumns.ID, id } };

            comandbuilder.DbDataScalarCommand(procedures.Delete, parameters);
        }

        public T Get(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { DBColumns.ID, id } };

            var dataTable = comandbuilder.DbDataReaderCommand(procedures.Get, parameters);
            
            var entity =(T)this.mapper.Map(dataTable.Rows[0]);
            return entity;
        }

        public List<T> GetByPaging(int page,int pageSize,string sort)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {DBColumns.PAGE,page },
                {DBColumns.PAGE_SIZE,pageSize},
                {DBColumns.SORT_COLUMN,sort}
            };
            var dataTable= comandbuilder.DbDataReaderCommand(procedures.GetEntities, parameters);
            List<T> entities = new List<T>();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                T ent =(T)this.mapper.Map(dataRow);
                entities.Add(ent);
            }
            return entities;

        }

        public int GetCount()
        {
            return comandbuilder.DbDataScalarCommand(procedures.Count);
        }

        public List<T> Find(string pattern)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {DBColumns.PATTERN,pattern },
            };

           var dataTable= comandbuilder.DbDataReaderCommand(procedures.Find, parameters);
            List<T> entities = new List<T>();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                T ent = (T)this.mapper.Map(dataRow);
                entities.Add(ent);
            }
            return entities;
        }

    }
}
