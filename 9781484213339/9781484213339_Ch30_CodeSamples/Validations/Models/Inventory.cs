using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

//Reference System.ComponentModel.DataAnnotations

namespace Validations.Models
{
    public partial class Inventory : INotifyPropertyChanged
    {
        private int _carId;
        [Required]
        public int CarId
        {
            get { return _carId; }
            set
            {
                if (value == _carId) return;
                _carId = value;
                OnPropertyChanged();
            }
        }

        private string _make;
        [Required, StringLength(50)]
        public string Make
        {
            get { return _make; }
            set
            {
                if (value == _make) return;
                _make = value;
                if (Make == "ModelT")
                {
                    AddError(nameof(Make), "Too Old");
                }
                else
                {
                    ClearErrors(nameof(Make));
                }
                OnPropertyChanged(nameof(Make));
                //OnPropertyChanged(nameof(Color));
            }
        }

        private string _color;
        [Required, StringLength(50)]
        public string Color
        {
            get { return _color; }
            set
            {
                if (value == _color) return;
                _color = value;
                OnPropertyChanged(nameof(Color));
                //OnPropertyChanged(nameof(Make));
            }
        }

        private string _petName;
        [StringLength(50)]
        public string PetName
        {
            get { return _petName; }
            set
            {
                if (value == _petName) return;
                _petName = value;
                OnPropertyChanged();
            }
        }

        private bool _isChanged;
        public bool IsChanged
        {
            get { return _isChanged; }
            set
            {
                if (value == _isChanged) return;
                _isChanged = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName != nameof(IsChanged))
            {
                IsChanged = true;
            }
           //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }

    }
}
