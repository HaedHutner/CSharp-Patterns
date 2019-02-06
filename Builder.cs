using System;
using System.Collections.Generic;
namespace GangOfFour.Builder.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World 
    /// Builder Design Pattern.
    /// </summary>
    public class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main ()
        {
            VehicleBuilder builder;
            // Create shop with vehicle builders
            Shop shop = new Shop ();
            // Construct and display vehicles
            builder = new ScooterBuilder ();
            shop.Construct (builder);
            builder.Vehicle.Show ();
            builder = new CarBuilder ();
            shop.Construct (builder);
            builder.Vehicle.Show ();
            builder = new MotorCycleBuilder ();
            shop.Construct (builder);
            builder.Vehicle.Show ();
            // Wait for user
            Console.ReadKey ();
        }
    }
    /// <summary>
    /// The 'Director' class
    /// </summary>
    class Shop
    {
        // Builder uses a complex series of steps
        public void Construct (VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame ();
            vehicleBuilder.BuildEngine ();
            vehicleBuilder.BuildWheels ();
            vehicleBuilder.BuildDoors ();
        }
    }
    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    abstract class VehicleBuilder
    {
        protected Vehicle vehicle;
        // Gets vehicle instance
        public Vehicle Vehicle
        {
            get { return vehicle; }
        }
        // Abstract build methods
        public abstract void BuildFrame ();
        public abstract void BuildEngine ();
        public abstract void BuildWheels ();
        public abstract void BuildDoors ();
    }
    /// <summary>
    /// The 'ConcreteBuilder1' class
    /// </summary>
    class MotorCycleBuilder : VehicleBuilder
    {
        public MotorCycleBuilder ()
        {
            vehicle = new Vehicle ("Мотор");
        }
        public override void BuildFrame ()
        {
            vehicle["frame"] = "Рамка на Мотор";
        }
        public override void BuildEngine ()
        {
            vehicle["engine"] = "500 кубични сантиметра";
        }
        public override void BuildWheels ()
        {
            vehicle["wheels"] = "2";
        }
        public override void BuildDoors ()
        {
            vehicle["doors"] = "0";
        }
    }
    /// <summary>
    /// The 'ConcreteBuilder2' class
    /// </summary>
    class CarBuilder : VehicleBuilder
    {
        public CarBuilder ()
        {
            vehicle = new Vehicle ("Кола");
        }
        public override void BuildFrame ()
        {
            vehicle["frame"] = "Рамка на Кола";
        }
        public override void BuildEngine ()
        {
            vehicle["engine"] = "2500 кубични сантиметра";
        }
        public override void BuildWheels ()
        {
            vehicle["wheels"] = "4";
        }
        public override void BuildDoors ()
        {
            vehicle["doors"] = "4";
        }
    }
    /// <summary>
    /// The 'ConcreteBuilder3' class
    /// </summary>
    class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder ()
        {
            vehicle = new Vehicle ("Скутер");
        }
        public override void BuildFrame ()
        {
            vehicle["frame"] = "Рамка на скутер";
        }
        public override void BuildEngine ()
        {
            vehicle["engine"] = "50 cc";
        }
        public override void BuildWheels ()
        {
            vehicle["wheels"] = "2";
        }
        public override void BuildDoors ()
        {
            vehicle["doors"] = "0";
        }
    }
    /// <summary>
    /// The 'Product' class
    /// </summary>
    class Vehicle
    {
        private string _vehicleType;
        private Dictionary<string, string> _parts =
            new Dictionary<string, string> ();
        // Constructor
        public Vehicle (string vehicleType)
        {
            this._vehicleType = vehicleType;
        }
        // Indexer
        public string this [string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }
        public void Show ()
        {
            Console.WriteLine ("\n---------------------------");
            Console.WriteLine ("Тип на двигателя: {0}", _vehicleType);
            Console.WriteLine (" Рамка : {0}", _parts["frame"]);
            Console.WriteLine (" Двигател : {0}", _parts["engine"]);
            Console.WriteLine (" #Гуми: {0}", _parts["wheels"]);
            Console.WriteLine (" #Врати : {0}", _parts["doors"]);
        }
    }
}

/*
Output:

---------------------------
Тип на двигателя: Скутер
 Рамка : Рамка на скутер
 Двигател : 50 cc
 #Гуми: 2
 #Врати : 0

---------------------------
Тип на двигателя: Кола
 Рамка : Рамка на Кола
 Двигател : 2500 кубични сантиметра
 #Гуми: 4
 #Врати : 4

---------------------------
Тип на двигателя: Мотор
 Рамка : Рамка на Мотор
 Двигател : 500 кубични сантиметра
 #Гуми: 2
 #Врати : 0

 */