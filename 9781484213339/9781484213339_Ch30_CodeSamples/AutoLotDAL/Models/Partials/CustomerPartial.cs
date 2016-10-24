using System;
using AutoLotDAL.Models.BaseClasses;

namespace AutoLotDAL.Models
{
    public partial class Customer:ModelBase
    {
        public override string this[string columnName] => string.Empty;
    }
}
