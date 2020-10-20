using CarStore.DAL.Entities;
using CarStore.DAL.Interfaces;
using CarStore.DAL.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CarStore.DAL
{
    public class OrderMapper : IMapper<Order>
    {
        public Order Map(DataRow dataRow)
        {
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
        public Dictionary<string, object> Map(Order order)
        {           
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
