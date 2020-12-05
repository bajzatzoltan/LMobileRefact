using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMobileRefact
{
	public sealed class PostingHandlerWithThreadSafeSingleton: DataAccess
	{
		private static readonly object lockObject = new object();
		private static PostingHandlerWithThreadSafeSingleton instance = null;
		CRUDFactory cRUDFactory;
		private PostingHandlerWithThreadSafeSingleton()
		{
			cRUDFactory = new CRUDFactory();
		}
		public static PostingHandlerWithThreadSafeSingleton GetInstance()
		{
			if (instance == null)
			{
				lock (lockObject)
				{
					if (instance == null)
					{
						instance = new PostingHandlerWithThreadSafeSingleton();
					}
				}
			}
			return instance;
		}
		public void RunProcess(string orderNoWithOpenPostedQuantity, decimal postedQuantityWithOpenPostedQuantity)
		{
			try
			{
				CheckReadQuantity(orderNoWithOpenPostedQuantity, postedQuantityWithOpenPostedQuantity);
				string command = "INSERT INTO Posting (ID, Status, OrderNo, PostedQuantity)"
						+ " VALUES (:id, :status, :orderNo, :postedQuantity)";
				var arguments = new Dictionary<string, object>()
					{
						{ "id", NewPostingIDThreadSafeSingleton.GetInstance().GetNewPostingID() },
						{ "status", 0 },
						{ "orderNo", orderNoWithOpenPostedQuantity },
						{ "postedQuantity", postedQuantityWithOpenPostedQuantity }
					};
				this.ExecuteDatabaseCommand(command, arguments);
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}
		private void CheckReadQuantity(string orderNoWithOpenPostedQuantity, decimal postedQuantityWithOpenPostedQuantity)
		{
			try
			{

				var orderWithOpenPostedQuantity = cRUDFactory.MakeCRUD<ReadTheOrder>().ReadOrder(orderNoWithOpenPostedQuantity);
				if ((orderWithOpenPostedQuantity == null) || orderWithOpenPostedQuantity.IsClosed)
				{
					throw new Exception("The order doesn't exist or it is already closed.");
				}
				else if (orderWithOpenPostedQuantity.OpenQuantity < postedQuantityWithOpenPostedQuantity)
				{
					throw new Exception(String.Concat("The posted quantity ", postedQuantityWithOpenPostedQuantity,
						" is greater than the open quantity ",
						orderWithOpenPostedQuantity.OpenQuantity));
				}

			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}
	}

}
