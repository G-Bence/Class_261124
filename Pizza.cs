using System;
using System.Collections.Generic;
using System.Text;

namespace Class_261124
{
    internal class Pizza
    {
        private int id;
        private string name;
        private int size;
        private int price;  

        public Pizza(int id, string name, int size, int price)
        {
            this.id = id;
            this.name = name;
            this.size = size;
            this.price = price;
        }

        public int Id { get => id; }
        public string Name { get => name; set => name = value; }
        public int Size { get => size; set => size = value; }
        public int Price { get => price; set => price = value; }


        public override string ToString()
        {
            return $"${this.id}, {this.name}, {this.size}cm, {this.price}Ft";
        }


    }
}
