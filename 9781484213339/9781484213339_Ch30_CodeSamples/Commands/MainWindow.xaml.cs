using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Commands.Cmds;
using Commands.Cmds.BaseClasses;
using Commands.Models;

namespace Commands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly ObservableCollection<Inventory> _cars;
        private RelayCommand<Inventory> _changeColorCmd = null;
        private RelayCommand _addCarCmd = null;
        private ICommand _changeColorCommand = null;

        public MainWindow()
        {
            InitializeComponent();
            _cars = new ObservableCollection<Inventory>
            {
                //IsChanged must be last in the list
                new Inventory {CarId=1,Color="Blue",Make="Chevy",PetName="Kit", IsChanged = false},
                new Inventory {CarId=2,Color="Red",Make="Ford",PetName="Red Rider", IsChanged = false },
            };
            cboCars.ItemsSource = _cars;
        }

        public ICommand ChangeColorRelayCmd => _changeColorCmd ?? (_changeColorCmd = new RelayCommand<Inventory>(ChangeColor, CanChangeColor));
        public ICommand ChangeColorCmd => _changeColorCommand ?? (_changeColorCommand = new ChangeColorCommand());

        public ICommand AddCarCmd => _addCarCmd ?? (_addCarCmd = new RelayCommand(AddCar,CanAddCar));


        private void AddCar()
        {
            var maxCount = _cars?.Max(x => x.CarId) ?? 0;
            _cars?.Add(new Inventory { CarId = ++maxCount, Color = "Yellow", Make = "VW", PetName = "Birdie", IsChanged = false });
        }

        private bool CanAddCar() => _cars != null;

        private bool CanChangeColor(Inventory inventory) => inventory != null;

        private void ChangeColor(Inventory inventory)
        {
            inventory.Color = "Pink";
        }
    }
}
