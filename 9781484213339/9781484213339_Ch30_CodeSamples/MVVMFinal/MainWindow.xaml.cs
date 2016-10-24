using System.Windows;
using MVVMFinal.ViewModels;

namespace MVVMFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindowViewModel ViewModel { get; set; } = new MainWindowViewModel();

    }
}
