using System.ComponentModel.DataAnnotations;
using AutoLotDAL.Models.MetaData;

namespace AutoLotDAL.Models
{
    [MetadataType(typeof(InventoryMetaData))]
    public partial class Inventory
    {
        public override string ToString() => 
            $"{this.PetName ?? "**No Name**"} is a {this.Color} {this.Make} with ID {this.CarId}.";
    }
}