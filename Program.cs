using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMobileRefact
{
    class Program
    {
        static void Main(string[] args)
        {
            CRUDFactory cRUDFactory = new CRUDFactory();
            try
            {
                List<Order> readOpenOrdersWithOpenPostedQuantity = cRUDFactory.MakeCRUD<ReadOpenOrderWithOpenPostedQuantity>().ReadOpenOrdersWithOpenPostedQuantity();
                foreach (Order x in readOpenOrdersWithOpenPostedQuantity)
                {
                    Console.WriteLine(String.Concat(x.OrderNo, ": ",
                            x.OpenQuantity, "/", x.PlannedQuantity));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Write("Order No: ");
            string orderNo = Console.ReadLine();
            Console.Write("Posted Quantity: ");
            try
            {
                decimal postedQuantity = Decimal.Parse(Console.ReadLine());
                PostingHandlerWithThreadSafeSingleton.GetInstance().RunProcess(orderNo, postedQuantity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
