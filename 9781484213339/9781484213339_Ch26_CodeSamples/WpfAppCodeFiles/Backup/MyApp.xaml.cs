// MyApp.xaml.cs
using System;
using System.Windows;
using System.Windows.Controls;
namespace WpfAppAllXaml
{
  public partial class MyApp : Application
  {
    private void AppExit(object sender, ExitEventArgs e)
    {
      MessageBox.Show("App has exited");
    }
  }
}
