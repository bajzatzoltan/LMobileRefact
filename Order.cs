using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMobileRefact
{
	public class Order
	{
		public string OrderNo; // Primary key
		public decimal PlannedQuantity;
		public decimal CompletedQuantity;
		public decimal OpenQuantity { get { return this.PlannedQuantity - this.CompletedQuantity; } }
		public bool IsClosed;
	}
}
