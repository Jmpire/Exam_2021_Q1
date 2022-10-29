using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Exam_2021
{
    class Program
    {
        class Car_Dealer
        {
            public string companyName;
            private List<Car> cars; // List to store all our cars

            public Car_Dealer(string companyName)
            {
                this.companyName = companyName;
                this.cars = new List<Car>(); // Initialise the list
            }
            // Adds a new car
            public void addCar(Car car)
            {
                cars.Add(car);
            }

            // 1) Get total income
            public double totalIncome()
            {
                double totalIncome = 0;
                foreach(Car car in cars)
                {
                    totalIncome += car.getPrice();
                }
                return totalIncome;
            }
            // 2) Get the total count of Toyotas
            public int Toyotas()
            {
                int count = 0;
                foreach( Car car in cars)
                {
                    if(car.make.ToLower().Equals("toyota"))
                    {
                        count++;
                    }
                }
                return count;
            }
            // 3) Get the cheapest car
            public string cheapestCar()
            {
                double maxPrice = double.MaxValue;
                string cheapestCar = "";
                foreach(Car car in cars)
                {
                    if(car.getPrice() < maxPrice)
                    {
                        cheapestCar = car.make;
                        maxPrice = car.getPrice();
                    }
                }
                return $"{cheapestCar} N${maxPrice}";
            }
        }
        abstract class Car
        {
            // Car attributes
            public int year_model;
            public string model;
            public string make;
            public string extras;
            protected double basePrice;

            public Car(int nYear, string nModel, string nMake, string nExtras, double basePrice)
            {
                this.year_model = nYear;
                this.model = nModel;
                this.make = nMake;
                this.extras = nExtras;
                this.basePrice = basePrice;
            }
            public abstract double getPrice(); // We will use this method to set different prices

        }
        class Sedan: Car
        {
            public Sedan(int nYear, string nModel, string nMake, string nExtras, double basePrice):base(nYear, nModel, nMake, nExtras, basePrice)
            {

            }
            public override double getPrice()
            {
                return this.basePrice + this.basePrice * 0.15;
            }
        }
        class Suv: Car
        {
            public Suv(int nYear, string nModel, string nMake, string nExtras, double basePrice):base(nYear, nModel, nMake, nExtras, basePrice)
            {

            }
            public override double getPrice()
            {
                return this.basePrice + this.basePrice * 0.25;
            }
        }
        class Bakkie: Car
        {
            public bool tractionIs_4x4;
            public Bakkie(int nYear, string nModel, string nMake, string nExtras, double basePrice, bool tractionIs_4x4)
                : base(nYear, nModel, nMake, nExtras, basePrice)
            {
                this.tractionIs_4x4 = tractionIs_4x4;
            }
            public override double getPrice()
            {
                if (!tractionIs_4x4) // No 4*4 traction
                {
                    return this.basePrice + this.basePrice * 0.15;
                }
                else // With 4*4 traction
                {
                    return this.basePrice + this.basePrice * 0.30;
                }
            }
        }
        static void Main(string[] args)
        {
            Car_Dealer cd = new Car_Dealer("J Motors");

            // Our different cars
            Sedan sedan1 = new Sedan(2018, "M3", "BMW", "Carbon fiber Diffuser", 470000);
            Suv suv1 = new Suv(2021, "Q7", "Audi", "Suitcase", 820000);
            Bakkie bakkie1 = new Bakkie(2020, "Hilux", "Toyota","Spare Wheel", 680000, true);
            Sedan sedan2 = new Sedan(2018, "911 Gt", "Porshe", "Sports exhaust", 3200000);
            Suv suv2 = new Suv(2022, "Bentayga", "Bently", "Relaxation pack", 8200000);
            Bakkie bakkie2 = new Bakkie(2019, "Amarok", "Volkswagen", "Toolbox", 1200000, true);

            // Add cars
            cd.addCar(sedan1);
            cd.addCar(sedan2);
            cd.addCar(suv1);
            cd.addCar(suv2);
            cd.addCar(bakkie1);
            cd.addCar(bakkie2);

            // Perform operations
            Console.WriteLine($"Total income: N${cd.totalIncome()}");
            Console.WriteLine($"Total Toyotas: {cd.Toyotas()}");
            Console.WriteLine($"Cheapest car: {cd.cheapestCar()}");


        }
    }
}