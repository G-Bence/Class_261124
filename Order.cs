using System;
using System.Collections.Generic;
using System.Text;

namespace Class_261124
{
    internal class Order
    {
        private int id;
        private Pizza pizza;
        private int quantity;
        private Address address;
        private TimeSpan deliveryTime;

        public Order(int id, Pizza pizza, int quantity, Address address, TimeSpan deliveryTime)
        {
            this.id = id;
            this.pizza = pizza;
            this.quantity = quantity;
            this.address = address;
            this.deliveryTime = deliveryTime;
        }

        public int Id { get => id; }
        public Pizza Pizza { get => pizza; }
        public int Quantity { get => quantity; }
        public Address Address { get => address; }
        public TimeSpan DeliveryTime { get => deliveryTime; }


        public override string ToString()
        {
            return $"${this.id}, {this.pizza.Name}, {this.quantity}db, {this.address.Name}, {this.deliveryTime.Hours} óra {this.deliveryTime.Minutes} perc";
        }
    }
}
