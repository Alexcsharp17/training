using CarStore.DAL.Entities;
using CarStore.DAL.Interfaces;
using CarStore.DAL.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CarStore.DAL
{
    public class PersonMapper : IMapper<Person>
    {
        public Person Map(DataRow dataRow)
        {        
            Person pers = new Person();
            if (dataRow != null)
            {
                pers.PersonID = Convert.ToInt32(dataRow[DBColumns.PERSON_ID.Replace("@", "")]);
                pers.FirstName = Convert.ToString(dataRow[DBColumns.FIRST_NAME.Replace("@", "")]);
                pers.LastName = Convert.ToString(dataRow[DBColumns.LAST_NAME.Replace("@", "")]);
                pers.Phone = Convert.ToString(dataRow[DBColumns.PHONE.Replace("@", "")]);
            }
            return pers;             
        }
        public Dictionary<string, object> Map(Person entity)
        {
            Person person = entity as Person;
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {DBColumns.FIRST_NAME, person.FirstName },
                {DBColumns.LAST_NAME, person.LastName},
                {DBColumns.PHONE,person.Phone }
            };
            return parameters;
        }
    }
}
