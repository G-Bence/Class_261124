using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Class_261124
{
    internal class Tasks
    {
        List<Order> orders;

        public Tasks()
        {
            DataBase db = new DataBase();
            orders = db.GetOrders();
            PrintOrders();

            

        }

        private void PrintOrders()
        {
            foreach (Order order in orders)
            {
                Console.WriteLine($"{order.Address.Name}, {order.Address.Street} {order.Address.HouseNumber}, {order.Pizza.Name}, {order.Quantity}db, {order.DeliveryTime.Hours} óra: {order.DeliveryTime.Minutes} perc");
            }
        }


        public int CountOrders()
        {
            return orders.Count;
        }

        public List<Order> CheaperThan1500()
        {
            return orders.Where(order => order.Pizza.Price * order.Quantity < 1500).ToList();
        }

    }
}
