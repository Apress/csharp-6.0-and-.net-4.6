using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Validations.Models;

namespace Validations
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

        private void btnChangeColor_Click(object sender, RoutedEventArgs e)
        {
            var car = _cars?.FirstOrDefault(x => x.CarId == ((Inventory)cboCars.SelectedItem)?.CarId);
            if (car != null)
            {
                car.Color = "Pink";
            }

        }
        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {
            var maxCount = _cars?.Max(x => x.CarId) ?? 0;
            _cars?.Add(new Inventory { CarId = ++maxCount, Color = "Yellow", Make = "VW", PetName = "Birdie", IsChanged = false });
        }

        private void btnRemoveCar_Click(object sender, RoutedEventArgs e)
        {
            _cars.RemoveAt(0);
        }
    }
}
