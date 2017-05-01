using System.ComponentModel;

namespace Commands.Models
{
    public partial class Inventory : EntityBase, IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                string[] errors = null;
                bool hasError = false;
                switch (columnName)
                {
                    case nameof(CarId):
                        errors = GetErrorsFromAnnotations(nameof(CarId), CarId);
                        break;
                    case nameof(Make):
                        //if (Make == "ModelT")
                        //{
                        //    return "Too Old";
                        //}
                        //return CheckMakeAndColor();
                        hasError = CheckMakeAndColor();
                        if (Make == "ModelT")
                        {
                            AddError(nameof(Make), "Too Old");
                            hasError = true;
                        }
                        errors = GetErrorsFromAnnotations(nameof(Make), Make);
                        break;
                    case nameof(Color):
                        //return CheckMakeAndColor();
                        hasError = CheckMakeAndColor();
                        errors = GetErrorsFromAnnotations(nameof(Color), Color);
                        break;
                    case nameof(PetName):
                        errors = GetErrorsFromAnnotations(nameof(PetName), PetName);
                        break;
                }
                if (errors != null && errors.Length != 0)
                {
                    AddErrors(columnName, errors);
                    hasError = true;
                }
                if (!hasError) ClearErrors(columnName);
                return string.Empty;
            }
        }

        internal bool CheckMakeAndColor()
        {
            if (Make == "Chevy" && Color == "Pink")
            {
                //return $"{Make}'s don't come in {Color}";
                AddError(nameof(Make), $"{Make}'s don't come in {Color}");
                AddError(nameof(Color), $"{Make}'s don't come in {Color}");
                return true;
            }
            return false;
        }

        //This is not used by WPF
        public string Error { get; }

    }
}