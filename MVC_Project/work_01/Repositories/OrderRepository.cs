using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using work_01.Models;
using work_01.ViewModels;

namespace work_01.Repositories
{
    public class OrderRepository
    {
        private RestuarentDbContext objRestuarentDbContext;
        public OrderRepository()
        {
            objRestuarentDbContext = new RestuarentDbContext();
        }
        public bool AddOrder(OrderViewModel objOrderViewModel)
        {
            using (var transaction = objRestuarentDbContext.Database.BeginTransaction())
            {
                try
                {
                    // add data to order table
                    Order objOrder = new Order();
                    objOrder.CustomerId = objOrderViewModel.CustomerId;
                    objOrder.FinalTotal = objOrderViewModel.FinalTotal;
                    objOrder.OrderDate = DateTime.Now;
                    objOrder.OrderNumber = string.Format("{0: ddmmmyyyyhhmmss}", DateTime.Now);
                    objOrder.PaymentTypeId = objOrderViewModel.PaymentTypeId;
                    objRestuarentDbContext.Orders.Add(objOrder);
                    objRestuarentDbContext.SaveChanges();
                    int orderId = objOrder.OrderId;

                    foreach (var item in objOrderViewModel.ListOfOrderDetailsViewModel)
                    {
                        //add data to order details table
                        OrderDetail objOrderDetail = new OrderDetail();
                        objOrderDetail.OrderId = orderId;
                        objOrderDetail.Discount = item.Discount;
                        objOrderDetail.ItemId = item.ItemId;
                        objOrderDetail.Total = item.Total;
                        objOrderDetail.UnitPrice = item.UnitPrice;
                        objOrderDetail.Quantity = item.Quantity;

                        objRestuarentDbContext.OrderDetails.Add(objOrderDetail);
                        objRestuarentDbContext.SaveChanges();

                        // add data to transaction table
                        Transaction objTransaction = new Transaction();
                        objTransaction.ItemId = item.ItemId;
                        objTransaction.Quantity = (-1) * item.Quantity;
                        objTransaction.TransactionDate = DateTime.Now;

                        objTransaction.TypeId = 2;
                        objRestuarentDbContext.Transactions.Add(objTransaction);

                    }

                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("error occurd" + ex);                   
                    transaction.Rollback();
                }


            }
               
            return true;
        } 
    }
}