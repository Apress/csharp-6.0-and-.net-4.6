using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppAllCode
{
	class MainWindow : Window
	{
		// Our UI element.
		private Button btnExitApp = new Button();

		public MainWindow(string windowTitle, int height, int width)
		{
			// Configure button and set the child control.
			btnExitApp.Click += new RoutedEventHandler(btnExitApp_Clicked);
			btnExitApp.Content = "Exit Application";
			btnExitApp.Height = 25;
			btnExitApp.Width = 100;

			// Set the content of this window to a single button.
			Content = btnExitApp;

			// Configure the window.
			this.Title = windowTitle;
			this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			this.Height = height;
			this.Width = width;

			this.Closing += MainWindow_Closing;
			this.Closed += MainWindow_Closed;
			this.MouseMove += MainWindow_MouseMove;
			this.KeyDown += MainWindow_KeyDown;
		}

		private void btnExitApp_Clicked(object sender, RoutedEventArgs e)
		{
			// Did user enable /godmode?
			if ((bool) Application.Current.Properties["GodMode"])
			{
				MessageBox.Show("Cheater!");
			}

			this.Close();
		}

		private void MainWindow_Closing(object sender,
			System.ComponentModel.CancelEventArgs e)
		{
			// See if the user really wants to shut down this window.
			string msg = "Do you want to close without saving?";
			MessageBoxResult result = MessageBox.Show(msg,
			  "My App", MessageBoxButton.YesNo, MessageBoxImage.Warning);

			if (result == MessageBoxResult.No)
			{
				// If user doesn't want to close, cancel closure.
				e.Cancel = true;
			}
		}

		private void MainWindow_Closed(object sender, EventArgs e)
		{
			MessageBox.Show("See ya!");
		}

		private void MainWindow_MouseMove(object sender,
			System.Windows.Input.MouseEventArgs e)
		{
			// Set the title of the window to the current X,Y of the mouse.
			this.Title = e.GetPosition(this).ToString();
		}

		private void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			// Display key press on the button.
			btnExitApp.Content = e.Key.ToString();
		}

	}
}
