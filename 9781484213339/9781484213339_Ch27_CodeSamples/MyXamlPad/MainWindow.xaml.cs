using System;
using System.IO;
using System.Windows;
using System.Windows.Markup;

namespace MyXamlPad
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
		private void btnViewXaml_Click(object sender, RoutedEventArgs e)
		{
			// Write out the data in the text block to a local *.xaml file.
			File.WriteAllText("YourXaml.xaml", txtXamlData.Text);
			// This is the window that will be dynamically XAML-ed.
			Window myWindow = null;
			// Open local *.xaml file.
			try
			{
				using (Stream sr = File.Open("YourXaml.xaml", FileMode.Open))
				{
					// Connect the XAML to the Window object.
					myWindow = (Window)XamlReader.Load(sr);

					// Show window as a dialog and clean up.
					myWindow.ShowDialog();
					myWindow.Close();
					myWindow = null;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		private void Window_Closed(object sender, EventArgs e)
		{
			// Write out the data in the text block to a local *.xaml file.
			File.WriteAllText("YourXaml.xaml", txtXamlData.Text);
			Application.Current.Shutdown();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			// When the main window of the app loads,
			// place some basic XAML text into the text block.
			if (File.Exists("YourXaml.xaml"))
			{
				txtXamlData.Text = File.ReadAllText("YourXaml.xaml");
			}
			else
			{
				txtXamlData.Text =
				"<Window xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\n"
				+ "xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\"\n"
				+ "Height =\"400\" Width =\"500\" WindowStartupLocation=\"CenterScreen\">\n"
				+ "<StackPanel>\n"
				+ "</StackPanel>\n"
				+ "</Window>";
			}

		}

	}
}
