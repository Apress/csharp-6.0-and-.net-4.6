using System;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoLotConsoleApp.EF;
using static System.Console;

namespace AutoLotConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** Fun with ADO.NET EF *****\n");
            int carId = AddNewRecord();
            //RemoveRecord(carId);
            //RemoveRecordUsingEntityState(carId);
            //WriteLine(carId);
            PrintAllInventory();
            //FunWithLinqQueries();
            //RemoveRecordsWithLinq();
            //UpdateRecord(carId);
            //WriteLine("*******************************\n");
            //PrintAllInventory();
            ReadLine();

        }
        private static int AddNewRecord()
        {
            // Add record to the Inventory table of the AutoLot
            // database. 
            using (var context = new AutoLotEntities())
            {
                try
                {
                    var car = new Car()
                    { Make = "Yugo", Color = "Brown", CarNickName = "Brownie" };
                    context.Cars.Add(car);
                    context.SaveChanges();
                    return car.CarId;
                }
                catch (Exception ex)
                {
                    WriteLine(ex.InnerException.Message);
                    return 0;
                }
            }
        }
        private static void PrintAllInventory()
        {
            // Select all items from the Inventory table of AutoLot,
            // and print out the data using our custom ToString()
            // of the Car entity class. 
            using (var context = new AutoLotEntities())
            {
                //foreach (Car c in context.Cars)
                //{
                //    WriteLine(c);
                //}
                //foreach (Car c in context.Cars.SqlQuery("Select CarId,Make,Color,PetName as CarNickName from Inventory where Make=@p0", "BMW"))
                //{
                //    WriteLine(c);
                //}
                //foreach (Car c in context.Cars.Where(c => c.Make == "BMW"))
                //{
                //    WriteLine(c);
                //}
                //foreach (Car c in context.Cars)
                //{
                //    foreach (Order o in c.Orders)
                //    {
                //        WriteLine(o.OrderId);
                //    }
                //}
                //foreach (Car c in context.Cars.Include(c=>c.Orders))
                //{
                //    foreach (Order o in c.Orders)
                //    {
                //        WriteLine(o.OrderId);
                //    }
                //}
                context.Configuration.LazyLoadingEnabled = false;
                foreach (Car c in context.Cars)
                {
                    context.Entry(c).Collection(x => x.Orders).Load();
                    foreach (Order o in c.Orders)
                    {
                        WriteLine(o.OrderId);
                    }
                }
            }
        }
        private static void FunWithLinqQueries()
        {
            using (var context = new AutoLotEntities())
            {
                // Get all data from the Inventory table.
                // could also write:
                // var allData = (from item in context.Inventories select item).ToArray();
                var allData = context.Cars.ToArray();

                // Get a projection of new data. 
                var colorsMakes = from item in allData select new { item.Color, item.Make };
                foreach (var item in colorsMakes)
                {
                    WriteLine(item);
                }

                // Get only items where Color == "Black"
                var blackCars = from item in allData where item.Color == "Black" select item;
                foreach (var item in blackCars)
                {
                    WriteLine(item);
                }
            }
        }
        private static void RemoveRecord(int carId)
        {
            // Find a car to delete by primary key.
            using (var context = new AutoLotEntities())
            {
                // See if we have it.
                Car carToDelete = context.Cars.Find(carId);
                if (carToDelete != null)
                {
                    context.Cars.Remove(carToDelete);
                    context.SaveChanges();
                }
            }
        }
        private static void RemoveRecordUsingEntityState(int carId)
        {
            using (var context = new AutoLotEntities())
            {

                Car carToDelete = new Car() { CarId = carId };
                context.Entry(carToDelete).State = EntityState.Deleted;
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    WriteLine(ex);
                }
            }
        }
        private static void UpdateRecord(int carId)
        {
            using (var context = new AutoLotEntities())
            {
                // Grab the car, change it, save! 
                Car carToUpdate = context.Cars.Find(carId);
                if (carToUpdate != null)
                {
                    WriteLine(context.Entry(carToUpdate).State);
                    carToUpdate.Color = "Blue";
                    WriteLine(context.Entry(carToUpdate).State);
                    context.SaveChanges();
                }
            }
        }


    }
}
