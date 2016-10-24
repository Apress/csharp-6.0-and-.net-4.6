using AutoLotDAL.Models;

namespace AutoLotDAL.EF
{
	using System;
	using System.Data.Entity;
	using System.Linq;

	public class AutoLotEntities : DbContext
	{
		public AutoLotEntities()
			: base("name=AutoLotConnection")
		{
		}

		public virtual DbSet<CreditRisk> CreditRisks { get; set; }
		public virtual DbSet<Customer> Customers { get; set; }
		public virtual DbSet<Inventory> Inventory { get; set; }
		public virtual DbSet<Order> Orders { get; set; }
	}

}