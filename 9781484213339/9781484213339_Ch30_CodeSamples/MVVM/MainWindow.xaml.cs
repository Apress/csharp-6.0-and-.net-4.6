using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MVVM.Cmds;
using MVVM.Cmds.BaseClasses;
using MVVM.Models;
using MVVM.ViewModels;

namespace MVVM
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
