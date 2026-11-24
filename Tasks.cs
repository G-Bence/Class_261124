using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

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

        public Pizza MostPopularPizza()
        {
            return orders.GroupBy(order => order.Pizza.Name)
                         .OrderByDescending(group => group.Count()).Select(group => group.First().Pizza).FirstOrDefault();
        }

        public Dictionary<Pizza, int> PizzaCount()
        {
            return orders.Where(order => order.DeliveryTime.Hours >= 18 && order.DeliveryTime.Hours <= 19).GroupBy(order => order.Pizza)
                         .ToDictionary(group => group.Key, group => group.Sum(order => order.Quantity));
        }


    }
}
