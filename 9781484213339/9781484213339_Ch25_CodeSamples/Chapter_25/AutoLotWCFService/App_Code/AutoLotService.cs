using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using AutoLotConnectedLayer;
using System.Data;

public class AutoLotService : IAutoLotService
{
  private const string ConnString =
    @"Data Source=(local)\SQLEXPRESS;Initial Catalog=AutoLot" +
     ";Integrated Security=True";

  public void InsertCar(int id, string make, string color, string petname)
  {
    InventoryDAL d = new InventoryDAL();
    d.OpenConnection(ConnString);
    d.InsertAuto(id, color, make, petname);
    d.CloseConnection();
  }

  public void InsertCar(InventoryRecord car)
  {
    InventoryDAL d = new InventoryDAL();
    d.OpenConnection(ConnString);
    d.InsertAuto(car.ID, car.Color, car.Make, car.PetName);
    d.CloseConnection();
  }

  public InventoryRecord[] GetInventory()
  {
    // First, get the DataTable from the database.
    InventoryDAL d = new InventoryDAL();
    d.OpenConnection(ConnString);
    DataTable dt = d.GetAllInventoryAsDataTable();
    d.CloseConnection();

    // Now make an List<T> to contain the records.
    List<InventoryRecord> records = new List<InventoryRecord>();

    // Copy data table into List<> of custom contracts. 
    DataTableReader reader = dt.CreateDataReader();
    while (reader.Read())
    {
      InventoryRecord r = new InventoryRecord();
      r.ID = (int)reader["CarID"];
      r.Color = ((string)reader["Color"]);
      r.Make = ((string)reader["Make"]);
      r.PetName = ((string)reader["PetName"]);
      records.Add(r);
    }
    // Transform List<T> to array of InventoryRecord types.
    return (InventoryRecord[])records.ToArray();
  }
}

