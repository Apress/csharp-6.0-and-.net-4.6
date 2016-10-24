namespace AutoLotConsoleApp.EF
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	[Table("Inventory")]
	public partial class Car
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Car()
		{
			Orders = new HashSet<Order>();
		}

		[Key]
		public int CarId { get; set; }

		[StringLength(50)]
		public string Make { get; set; }

		[StringLength(50)][Index()]
		public string Color { get; set; }

		[StringLength(50), Column("PetName")]
		public string CarNickName { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Order> Orders { get; set; }
	}
}
