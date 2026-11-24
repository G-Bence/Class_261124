using System;
using System.Collections.Generic;
using System.Text;

namespace Class_261124
{
    internal class Address
    {
        private int id;
        private string name;
        private string street;
        private string houseNumber;

        public Address(int id, string name, string street, string houseNumber)
        {
            this.id = id;
            this.name = name;
            this.street = street;
            this.houseNumber = houseNumber;
        }

        public int Id { get => id; }
        public string Name { get => name; set => name = value; }
        public string Street { get => street; set => street = value; }
        public string HouseNumber { get => houseNumber; set => houseNumber = value; }

        public override string ToString()
        {
            return $"${this.id}, {this.name}, {this.street} {this.houseNumber}";
        }
    }
}
