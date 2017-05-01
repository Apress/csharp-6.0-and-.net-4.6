using System.ComponentModel;
using System.Runtime.CompilerServices;

//Reference System.ComponentModel.DataAnnotations

namespace Notifications.Models
{
    public class Inventory : INotifyPropertyChanged
    {

        private int _carId;
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
        public string Make
        {
            get { return _make; }
            set
            {
                if (value == _make) return;
                _make = value;
                OnPropertyChanged();
            }
        }

        private string _color;
        public string Color
        {
            get { return _color; }
            set
            {
                if (value == _color) return;
                _color = value;
                OnPropertyChanged();
            }
        }

        private string _petName;
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
            get { return _isChanged;}
            set
            {
                if (value == _isChanged) return;
                _isChanged = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName != nameof(IsChanged))
            {
                IsChanged = true;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }
    }
}
