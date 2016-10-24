using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoLotDAL.Models.BaseClasses;

namespace AutoLotDAL.Models
{
	public partial class Customer:ModelBase
	{
		[Key]
		public int CustId { get; set; }

		[StringLength(50)]
		public string FirstName { get; set; }

		[StringLength(50)]
		public string LastName { get; set; }

		[NotMapped]
		public string FullName => FirstName + " " + LastName;

		public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
	}
}
