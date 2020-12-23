using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1_20181CSE0099_
{
    public abstract class Vehicle
    {
        private string make;
        private string model;
        private int year;
        private double price;
        public string Make
        {
            get 
            { 
                return make;
            }
            set 
            { 
                make = value;
            }
        }
        public string Model
       
        {
            get 
            { 
                return model; 
            }
            set 
            {
                model = value; 
            }
        }
        public int Year
        {
            get 
            { 
                return year; 
            }
            set 
            { 
                year = value; 
            }
        }
        public double Price
        {
            get 
            { 
                return price;
            }
            set 
            { 
                price = value;
            }
        }

        public abstract void checkPrice();
        public abstract void printInfo();
        public abstract void testDrive();
    }
    class Minivan : Vehicle
    {
        public Minivan(string make, string model, int year, double price)
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;
        }
        public override void checkPrice()
        {
            Console.WriteLine(Price);
        }
        public override void printInfo()
        {
            Console.WriteLine(Make + Model + Year + Price);
        }
        public override void testDrive()
        {
            Console.WriteLine("testDrive");
        }
    }
    class SchoolBus : Vehicle
    {
        public SchoolBus(string make, string model, int year, double price)
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;
        }
        public override void checkPrice()
        {
            Console.WriteLine(Price);
        }
        public override void printInfo()
        {
            Console.WriteLine(Make + Model + Year + Price);
        }
        public override void testDrive()
        {
            Console.WriteLine("testDrive");
        }
    }
}
