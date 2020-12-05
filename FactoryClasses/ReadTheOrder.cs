using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMobileRefact
{
    public class ReadTheOrder : DataAccess
    {
		public Order ReadOrder(string orderNo)
		{
			try
			{
				string query = "SELECT OrderNo, PlannedQuantity, CompletedQuantity, IsClosed"
					+ " FROM Order WHERE OrderNo = :orderNo";
				var arguments = new Dictionary<string, object>() { { "orderNo", orderNo } };
				using (var reader = ExecuteDatabaseReader(query, arguments))
				{
					if (reader.Read())
					{
						return new OrderFromReader().GetOrderFromReader(reader);
					}
				}
				return null;
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}
	}
}
