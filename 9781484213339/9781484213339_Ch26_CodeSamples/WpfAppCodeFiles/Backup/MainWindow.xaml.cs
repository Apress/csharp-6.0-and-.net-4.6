// MainWindow.xaml.cs
using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppAllXaml
{
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      // Remember! This method is defined
      // within the generated MainWindow.g.cs file.
      InitializeComponent();
    }

    private void btnExitApp_Clicked(object sender, RoutedEventArgs e)
    {
      this.Close();
    }
  }
}
