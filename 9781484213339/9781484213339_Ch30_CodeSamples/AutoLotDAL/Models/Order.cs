using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoLotDAL.Models.BaseClasses;

namespace AutoLotDAL.Models
{
	public partial class Order :ModelBase
	{
		[Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderId { get; set; }

		[Required]
		public int CustId { get; set; }

		[Required]
		public int CarId { get; set; }


		[ForeignKey("CustId")]
		public virtual Customer Customer { get; set; }

		[ForeignKey("CarId")]
		public virtual Inventory Car { get; set; }
	}
}
