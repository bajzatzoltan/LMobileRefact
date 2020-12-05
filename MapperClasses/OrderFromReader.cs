using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMobileRefact
{
    public class OrderFromReader
    {
		public Order GetOrderFromReader(IDataReader reader)
		{
			return new Order
			{
				OrderNo = reader.GetString(0),
				PlannedQuantity = reader.GetDecimal(1),
				CompletedQuantity = reader.GetDecimal(2),
				IsClosed = reader.GetBoolean(3)
			};
		}
	}
}
