using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AutoLotDAL.Models;
using AutoLotDAL.Repos;
using MVVMFinal.Cmds;
using MVVMFinal.Cmds.BaseClasses;

namespace MVVMFinal.ViewModels
{
    public class MainWindowViewModel
    {
        private RelayCommand<Inventory> _changeColorCmd = null;
        private RelayCommand _addCarCmd = null;
        private ICommand _changeColorCommand = null;

        public ICommand ChangeColorRelayCmd => _changeColorCmd ?? (_changeColorCmd = new RelayCommand<Inventory>(ChangeColor, CanChangeColor));
        public ICommand ChangeColorCmd => _changeColorCommand ?? (_changeColorCommand = new ChangeColorCommand());
        public ICommand AddCarCmd => _addCarCmd ?? (_addCarCmd = new RelayCommand(AddCar, CanAddCar));
        public IList<Inventory> Cars { get; set; }

        public MainWindowViewModel()
        {
            Cars = new ObservableCollection<Inventory>(new InventoryRepo().GetAll());
        }
        private void AddCar()
        {
            var maxCount = Cars?.ToList().Max(x => x.CarId) ?? 0;
            Cars?.Add(new Inventory { CarId = ++maxCount, Color = "Yellow", Make = "VW", PetName = "Birdie", IsChanged = false });
        }

        private bool CanAddCar() => Cars != null;

        private bool CanChangeColor(Inventory inventory) => inventory != null;

        private void ChangeColor(Inventory inventory)
        {
            inventory.Color = "Pink";
        }
    }
}
