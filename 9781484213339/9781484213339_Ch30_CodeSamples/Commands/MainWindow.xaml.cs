using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Commands.Cmds;
using Commands.Models;

namespace Commands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly ObservableCollection<Inventory> _cars;

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

        private ICommand _changeColorCommand = null;
        public ICommand ChangeColorCmd =>
            _changeColorCommand ?? (_changeColorCommand = new ChangeColorCommand());

        private ICommand _addCarCommand = null;
        public ICommand AddCarCmd =>
            _addCarCommand ?? (_addCarCommand = new AddCarCommand(_cars));

        private ICommand _removeCarCommand = null;
        public ICommand RemoveCarCmd =>
            _removeCarCommand ?? (_removeCarCommand = new RemoveCarCommand(_cars));


    }
}
