using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using AutoLotDAL.EF;
using AutoLotDAL.Models;
using AutoLotDAL.Repos;
using static System.Console;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
            //Database.SetInitializer(new MyDataInitializer());
            //new AutoLotEntities().Database.Initialize(true);
			WriteLine("***** Fun with ADO.NET EF Code First *****\n");
            //var car1 = new Inventory() { Make = "Yugo", Color = "Brown", PetName = "Brownie" };
            //var car2 = new Inventory() { Make = "SmartCar", Color = "Brown", PetName = "Shorty" };
            //AddNewRecord(car1);
            //AddNewRecord(car2);
            //AddNewRecords(new List<Inventory> { car1, car2 });
            //UpdateRecord(car1.CarId);

            //ShowAllOrders();
            //ShowAllOrdersEagerlyFetched();

            PrintAllInventory();

            //PrintAllCustomersAndCreditRisks();
            //var customerRepo = new CustomerRepo();
            //var customer = customerRepo.GetOne(4);
            //      customerRepo.Context.Entry(customer).State = EntityState.Detached;
            //var risk = MakeCustomerARisk(customer);
            //      PrintAllCustomersAndCreditRisks();


            //RemoveRecordByCar(car1);
            //RemoveRecordByCar(car2);
            var car1 = new Inventory() { Make = "Yugo", Color = "Brown", PetName = "Brownie" };
            AddNewRecord(car1);
            RemoveRecordById(car1.CarId, car1.Timestamp);
            //RemoveRecordById(car2.CarId);
            //DeleteCreditRisk(risk);
            //UpdateRecordRedux();
            ReadLine();

		}
        private static void PrintAllInventory()
        {
            using (var repo = new InventoryRepo())
            {
                foreach (var c in repo.GetAll())
                {
                    WriteLine(c);
                }
            }
        }

        private static void AddNewRecord(Inventory car)
        {
            using (var repo = new InventoryRepo())
            {
                repo.Add(car);
            }
        }
        private static void AddNewRecords(IList<Inventory> cars)
        {
            using (var repo = new InventoryRepo())
            {
                repo.AddRange(cars);
            }
        }

        private static void UpdateRecord(int carId)
        {
            using (var repo = new InventoryRepo())
            {
                // Grab the car, change it, save! 
                var carToUpdate = repo.GetOne(carId);
                if (carToUpdate != null)
                {
                    WriteLine("Before change: " + repo.Context.Entry(carToUpdate).State);
                    carToUpdate.Color = "Blue";
                    WriteLine("After change: " + repo.Context.Entry(carToUpdate).State);
                    repo.Save(carToUpdate);
                    WriteLine("After save: " + repo.Context.Entry(carToUpdate).State);
                }
            }
        }

        private static void ShowAllOrders()
		{
			using (var repo = new OrderRepo())
			{
				WriteLine("*********** Pending Orders ***********");
				foreach (var itm in repo.GetAll())
				{
					WriteLine($"->{itm.Customer.FullName} is waiting on {itm.Car.PetName}");
				}
			}
		}

		private static void ShowAllOrdersEagerlyFetched()
		{
			using (var context = new AutoLotEntities())
			{
				WriteLine("*********** Pending Orders ***********");
				var orders = context.Orders
					.Include(x => x.Customer)
					.Include(y => y.Car)
					.ToList();
				foreach (var itm in orders)
				{
					WriteLine($"-> {itm.Customer.FullName} is waiting on {itm.Car.PetName}");
				}
			}
		}

		private static void PrintAllCustomersAndCreditRisks()
		{
			WriteLine("*********** Customers ***********");
			using (var repo = new CustomerRepo())
			{
				foreach (var cust in repo.GetAll())
				{
					WriteLine($"-> {cust.FirstName} {cust.LastName} is a Customer.");
				}
			}
			WriteLine("*********** Credit Risks ***********");
			using (var repo = new CreditRiskRepo())
			{
				foreach (var risk in repo.GetAll())
				{
					WriteLine($"-> {risk.FirstName} {risk.LastName} is a Credit Risk!");
				}
			}
		}
		private static void AddCustomer(Customer customer)
		{
			using (var repo = new CustomerRepo())
			{
				repo.Add(customer);
			}
		}

		private static CreditRisk MakeCustomerARisk(Customer customer)
		{
			using (var context = new AutoLotEntities())
			{
			    context.Customers.Attach(customer);
				context.Customers.Remove(customer);
				var creditRisk = new CreditRisk()
				{
					FirstName = customer.FirstName,
					LastName = customer.LastName
				};
				context.CreditRisks.Add(creditRisk);
			    try
			    {
			        context.SaveChanges();
			    }
			    catch (DbUpdateException ex)
			    {
			        WriteLine(ex);
			    }
			    catch (Exception ex)
			    {
			        WriteLine(ex);
			    }

				return creditRisk;
			}
		}
		private static void DeleteCreditRisk(CreditRisk risk)
		{
			using (var repo = new CreditRiskRepo())
			{
				try
				{
					repo.Delete(risk);
				}
				catch (Exception ex)
				{
					WriteLine(ex);
				}
			}
		}

		private static void RemoveRecordByCar(Inventory carToDelete)
		{
			using (var repo = new InventoryRepo())
			{
				repo.Delete(carToDelete);
			}
		}
		private static void RemoveRecordById(int carId, byte[] timeStamp)
		{
			using (var repo = new InventoryRepo())
			{
				repo.Delete(carId, timeStamp);
			}
		}
		private static void UpdateRecordWIthConcurrency()
		{
			var car = new Inventory()
			{ Make = "Yugo", Color = "Brown", PetName = "Brownie" };
			AddNewRecord(car);
			PrintAllInventory();
			var repo1 = new InventoryRepo();
			var car1 = repo1.GetOne(car.CarId);
			car1.PetName = "Updated";

			var repo2 = new InventoryRepo();
			var car2 = repo2.GetOne(car.CarId);
			car2.Make = "Nissan";

			repo1.Save(car1);
			try
			{
				repo2.Save(car2);
			}
			catch (DbUpdateConcurrencyException ex)
			{
				WriteLine(ex);
			}
			//RemoveRecordById(car1.CarId, car1.Timestamp);
			PrintAllInventory();
		}

	}
}
