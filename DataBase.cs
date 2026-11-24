using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Class_261124
{
    internal class DataBase
    {
        private readonly string connectionString;
        public DataBase()
        {
            this.connectionString = "Data Source=localhost;database=Pizzeria;user=root;password= ";
        }
        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();

            Dictionary<int, Pizza> pizzas = new Dictionary<int, Pizza>();
            Dictionary<int, Address> addresses = new Dictionary<int, Address>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(this.connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connection opened.");
                    string query = "SELECT * FROM pizza";
                    using(MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("id");
                                string name = reader.GetString("nev");
                                int size = reader.GetInt32("meret");
                                int price = reader.GetInt32("ar");
                                Pizza pizza = new Pizza(id, name, size, price);
                                pizzas.Add(id, pizza);
                            }
                        }
                    } 

                    string query2 = "SELECT * FROM cim";
                    using (MySqlCommand command2 = new MySqlCommand(query2, connection))
                    {
                        using (MySqlDataReader reader2 = command2.ExecuteReader())
                        {
                            while (reader2.Read())
                            {
                                int id = reader2.GetInt32("id");
                                string name = reader2.GetString("nev");
                                string street = reader2.GetString("utca");
                                string houseNumber = reader2.GetString("hsz");
                                Address address = new Address(id, name, street, houseNumber);
                                addresses.Add(id, address);
                            }
                        }
                    }

                    string query3 = "SELECT * FROM rendeles";
                    using (MySqlCommand command3 = new MySqlCommand(query3, connection))
                    {
                        using (MySqlDataReader reader3 = command3.ExecuteReader())
                        {
                            while (reader3.Read())
                            {
                                int id = reader3.GetInt32("id");
                                Pizza pizza = pizzas[reader3.GetInt32("pizzaid")];
                                int quantity = reader3.GetInt32("darab");
                                Address address = addresses[reader3.GetInt32("cimid")];
                                TimeSpan deliveryTime = reader3.GetTimeSpan("szallitas");

                                Order order = new Order(id, pizza, quantity, address, deliveryTime);
                                orders.Add(order);
                            }
                        }
                    }
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }

            Console.WriteLine(pizzas[1]);
            Console.WriteLine(addresses[1]);
            Console.WriteLine(orders[1])    ;
            return orders;
        }
    }
}
