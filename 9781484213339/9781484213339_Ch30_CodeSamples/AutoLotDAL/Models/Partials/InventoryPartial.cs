using System.ComponentModel.DataAnnotations;
using AutoLotDAL.Models.BaseClasses;

namespace AutoLotDAL.Models
{
    public partial class Inventory:ModelBase
    {
        public override string ToString() => 
            $"{PetName ?? "**No Name**"} is a {Color} {Make} with ID {CarId}.";

        public override string this[string columnName]
        {
            get
            {
                string[] errors;
                bool hasError = false;
                switch (columnName)
                {
                    case nameof(CarId):
                        errors = GetErrorsFromAnnotations(nameof(CarId), CarId);
                        if (errors != null && errors.Length != 0)
                        {
                            AddErrors(nameof(CarId), errors);
                            hasError = true;
                        }
                        if (!hasError) ClearErrors(nameof(CarId));
                        break;
                    case nameof(Make):
                        if (Make == "ModelT")
                        {
                            AddError(nameof(Make), "Too Old");
                            hasError = true;
                        }
                        if (Make == "Chevy" && Color == "Pink")
                        {
                            AddError(nameof(Make), $"{Make}'s don't come in {Color}");
                            AddError(nameof(Color), $"{Make}'s don't come in {Color}");
                            hasError = true;
                        }

                        errors = GetErrorsFromAnnotations(nameof(Make), Make);
                        if (errors != null && errors.Length != 0)
                        {
                            AddErrors(nameof(Make), errors);
                            hasError = true;
                        }
                        if (!hasError) ClearErrors(nameof(Make));
                        break;
                    case nameof(Color):
                        //if (Make == "Chevy" && Color == "Pink")
                        //{
                        //    return $"{Make}'s don't come in {Color}";
                        //}
                        if (Make == "Chevy" && Color == "Pink")
                        {
                            AddError(nameof(Make), $"{Make}'s don't come in {Color}");
                            AddError(nameof(Color), $"{Make}'s don't come in {Color}");
                            hasError = true;
                        }
                        errors = GetErrorsFromAnnotations(nameof(Color), Color);
                        if (errors != null && errors.Length != 0)
                        {
                            AddErrors(nameof(Color), errors);
                            hasError = true;
                        }
                        if (!hasError) ClearErrors(nameof(Color));
                        break;
                    case nameof(PetName):
                        errors = GetErrorsFromAnnotations(nameof(PetName), PetName);
                        if (errors != null && errors.Length != 0)
                        {
                            AddErrors(nameof(PetName), errors);
                            hasError = true;
                        }
                        if (!hasError) ClearErrors(nameof(PetName));
                        break;
                }
                return string.Empty;
            }
        }
    }
}