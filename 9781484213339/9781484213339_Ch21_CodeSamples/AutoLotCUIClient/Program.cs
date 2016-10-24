using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using AutoLotDAL;
using AutoLotDAL.ConnectedLayer;
using AutoLotDAL.Models;
using static System.Console;

namespace AutoLotCUIClient
{
	class Program
	{
		static void Main(string[] args)
		{
			WriteLine("***** The AutoLot Console UI *****\n");

			// Get connection string from App.config.
			string connectionString =
			  ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;
			bool userDone = false;
			string userCommand = "";

			// Create our InventoryDAL object.
			InventoryDAL invDAL = new InventoryDAL();
			invDAL.OpenConnection(connectionString);

			// Keep asking for input until user presses the Q key.
			try
			{
				ShowInstructions();
				do
				{
					Write("\nPlease enter your command: ");
					userCommand = ReadLine();
					WriteLine();
					switch (userCommand?.ToUpper() ?? "")
					{
						case "I":
							InsertNewCar(invDAL);
							break;
						case "U":
							UpdateCarPetName(invDAL);
							break;
						case "D":
							DeleteCar(invDAL);
							break;
						case "L":
							// ListInventory(invDAL);
							ListInventoryViaList(invDAL);
							break;
						case "S":
							ShowInstructions();
							break;
						case "P":
							LookUpPetName(invDAL);
							break;
						case "Q":
							userDone = true;
							break;
						default:
							WriteLine("Bad data!  Try again");
							break;
					}
				} while (!userDone);
			}
			catch (Exception ex)
			{
				WriteLine(ex.Message);
			}
			finally
			{
				invDAL.CloseConnection();
			}
		}
		private static void ShowInstructions()
		{
			WriteLine("I: Inserts a new car.");
			WriteLine("U: Updates an existing car.");
			WriteLine("D: Deletes an existing car.");
			WriteLine("L: Lists current inventory.");
			WriteLine("S: Shows these instructions.");
			WriteLine("P: Looks up pet name.");
			WriteLine("Q: Quits program.");
		}

		private static void ListInventoryViaList(InventoryDAL invDAL)
		{
			// Get the list of inventory.
			List<NewCar> record = invDAL.GetAllInventoryAsList();

			WriteLine("CarId:\tMake:\tColor:\tPetName:");
			foreach (NewCar c in record)
			{
				WriteLine($"{c.CarId}\t{c.Make}\t{c.Color}\t{c.PetName}");
			}
		}

		private static void ListInventory(InventoryDAL invDAL)
		{
			// Get the list of inventory.
			DataTable dt = invDAL.GetAllInventoryAsDataTable();
			// Pass DataTable to helper function to display.
			DisplayTable(dt);
		}
		private static void DisplayTable(DataTable dt)
		{
			// Print out the column names.
			for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
			{
				Write($"{dt.Columns[curCol].ColumnName}\t");
			}
			WriteLine("\n----------------------------------");

			// Print the DataTable.
			for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
			{
				for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
				{
					Write($"{dt.Rows[curRow][curCol]}\t");
				}
				WriteLine();
			}
		}
		private static void DeleteCar(InventoryDAL invDAL)
		{
			// Get ID of car to delete.
			Write("Enter ID of Car to delete: ");
			int id = int.Parse(ReadLine() ?? "0");

			// Just in case we have a primary key violation!
			try
			{
				invDAL.DeleteCar(id);
			}
			catch (Exception ex)
			{
				WriteLine(ex.Message);
			}
		}
		private static void InsertNewCar(InventoryDAL invDAL)
		{
			Write("Enter Car ID: ");
			var newCarId = int.Parse(ReadLine() ?? "0");
			Write("Enter Car Color: ");
			var newCarColor = ReadLine();
			Write("Enter Car Make: ");
			var newCarMake = ReadLine();
			Write("Enter Pet Name: ");
			var newCarPetName = ReadLine();

			// Now pass to data access library.
			// invDAL.InsertAuto(newCarId, newCarColor, newCarMake, newCarPetName);
			var c = new NewCar
			{
				CarId = newCarId,
				Color = newCarColor,
				Make = newCarMake,
				PetName = newCarPetName
			};
			invDAL.InsertAuto(c);
		}
		private static void UpdateCarPetName(InventoryDAL invDAL)
		{
			// First get the user data.
			Write("Enter Car ID: ");
			var carId = int.Parse(ReadLine() ?? "0");
			Write("Enter New Pet Name: ");
			var newCarPetName = ReadLine();

			// Now pass to data access library.
			invDAL.UpdateCarPetName(carId, newCarPetName);
		}
		private static void LookUpPetName(InventoryDAL invDAL)
		{
			// Get ID of car to look up.
			Write("Enter ID of Car to look up: ");
			int id = int.Parse(ReadLine() ?? "0");
			WriteLine($"Petname of {id} is {invDAL.LookUpPetName(id).TrimEnd()}.");
		}

	}
}
