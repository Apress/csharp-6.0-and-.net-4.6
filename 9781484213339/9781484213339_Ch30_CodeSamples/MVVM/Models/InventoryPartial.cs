using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MVVM.Models
{
    public partial class Inventory : IDataErrorInfo, INotifyDataErrorInfo
    {
        private string[] GetErrorsFromAnnotations<T>(string propertyName, T value)
        {
            var results = new List<ValidationResult>();
            var vc = new ValidationContext(this, null, null)
            { MemberName = propertyName };
            var isValid = Validator.TryValidateProperty(value, vc, results);

            return (isValid)?null:Array.ConvertAll(
                results.ToArray(), o => o.ErrorMessage);
        }
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
                        if (errors != null && errors.Length != 0)
                        {
                            AddErrors(nameof(CarId), errors);
                            hasError = true;
                        }
                        if (!hasError) ClearErrors(nameof(CarId));
                        break;
                    case nameof(Make):
                        //if (Make == "ModelT")
                        //{
                        //    return "Too Old";
                        //}
                        //if (Make == "Chevy" && Color == "Pink")
                        //{
                        //    return $"{Make}'s don't come in {Color}";
                        //}
                        if (Make == "ModelT")
                        {
                            AddError(nameof(Make),"Too Old");
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
                            AddErrors(nameof(Make),errors);
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
                            ClearErrors(nameof(PetName));
                            AddErrors(nameof(PetName), errors);
                            hasError = true;
                        }
                        if (!hasError) ClearErrors(nameof(PetName));
                        break;
                }
                return string.Empty;
            }
        }
        //This is not used by WPF
        public string Error { get; }

        //INotifyDataErrorInfo
        private readonly Dictionary<string, List<string>> _errors =
            new Dictionary<string, List<string>>();

        protected void ClearErrors(string propertyName = "")
        {
            _errors.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }

        private void AddError(string propertyName, string error)
        {
            AddErrors(propertyName, new List<string> { error });
        }

        private void AddErrors(string propertyName, IList<string> errors)
        {
            var changed = false;
            if (!_errors.ContainsKey(propertyName))
            {
                _errors.Add(propertyName, new List<string>());
                changed = true;
            }
            errors.ToList().ForEach(x =>
            {
                if (_errors[propertyName].Contains(x)) return;
                _errors[propertyName].Add(x);
                changed = true;
            });
            if (changed)
            {
                OnErrorsChanged(propertyName);
            }
        }
        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return _errors.Values;
            }
            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
        }
        public bool HasErrors => _errors.Count != 0;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}