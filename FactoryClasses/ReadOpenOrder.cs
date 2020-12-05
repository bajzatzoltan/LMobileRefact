using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMobileRefact
{
    public class ReadOpenOrder : DataAccess
    {
        public List<Order> ReadOpenResult()
        {
			List<Order> listOfOrder = new List<Order>();
			string query = "SELECT OrderNo, PlannedQuantity, CompletedQuantity, IsClosed"
				+ " FROM Order WHERE IsClosed = 0";
			using (var reader = this.ExecuteDatabaseReader(query, null))
			{
				if (reader.Read())
				{
					listOfOrder.Add(new OrderFromReader().GetOrderFromReader(reader));
				}
			}
			return listOfOrder;
		}

    }
}
