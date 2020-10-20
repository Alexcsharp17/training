using CarStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CarStore.DAL.Util
{
    class OrderMapper<T>
    {
        public object Map(DataRow dataRow)
        {
            switch (typeof(T).Name)
            {
                case "Person":
                    Person pers = new Person();
                    if (dataRow != null)
                    {
                        pers.PersonID = Convert.ToInt32(dataRow[DBColumns.PERSON_ID.Replace("@", "")]);
                        pers.FirstName = Convert.ToString(dataRow[DBColumns.FIRST_NAME.Replace("@", "")]);
                        pers.LastName = Convert.ToString(dataRow[DBColumns.LAST_NAME.Replace("@", "")]);
                        pers.Phone = Convert.ToString(dataRow[DBColumns.PHONE.Replace("@", "")]);
                    }
                    return pers;
                default:
                    Order ord = new Order();

                    if (dataRow != null)
                    {
                        ord.OrderID = Convert.ToInt32(dataRow[DBColumns.ORDER_ID.Replace("@", "")]);
                        ord.OrderDate = Convert.ToDateTime(dataRow[DBColumns.ORDER_DATE.Replace("@", "")]);
                        ord.CarID = Convert.ToInt32(dataRow[DBColumns.CAR_ID.Replace("@", "")]);
                        ord.PersonId = Convert.ToInt32(dataRow[DBColumns.PERSON_ID.Replace("@", "")]);
                    }

                    return ord;
            }
        }
        public Dictionary<string, object> Map(T entity)
        {
            switch (typeof(T).Name)
            {
                case "Person":
                    Person person = entity as Person;
                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        {DBColumns.FIRST_NAME, person.FirstName },
                        {DBColumns.LAST_NAME, person.LastName},
                        {DBColumns.PHONE,person.Phone }
                    };
                    return parameters;
                default:
                    Order order = entity as Order;
                    Dictionary<string, object> parameter = new Dictionary<string, object>()
                     {
                         {DBColumns.PERSON_ID, order.PersonId },
                         {DBColumns.ORDER_DATE, order.OrderDate },
                         {DBColumns.CAR_ID, order.CarID }
                     };
                    return parameter;
            }
        }
    }
}
