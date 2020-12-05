using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMobileRefact
{
    public class ReadOpenOrderWithOpenPostedQuantity : DataAccess
    {
		public List<Order> ReadOpenOrdersWithOpenPostedQuantity()
		{
			try
			{
				var orders = new List<Order>();
				var query = "SELECT [Order].OrderNo, [Order].PlannedQuantity," +
					"([Order].CompletedQuantity + (SELECT CASE WHEN(SUM(Posting.PostedQuantity)) " +
					"IS NOT NULL THEN SUM(Posting.PostedQuantity) ELSE 0 END FROM Posting WHERE Posting.OrderNo = [Order].OrderNo AND Posting.[Status] = 0)) " +
					"AS CompletedQuantity,[Order].IsClosed FROM[Order] WHERE[Order].IsClosed = 0";
				using (var reader = ExecuteDatabaseReader(query, null))
				{
					if (reader.Read())
					{
						orders.Add(new OrderFromReader().GetOrderFromReader(reader));
					}
				}
				return orders;
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}
	}
}
