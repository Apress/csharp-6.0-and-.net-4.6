using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InteractiveLaserSign
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

		private void Line1_1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Line1_2.Fill = new SolidColorBrush(Colors.Red);
		}

		private void Line2_1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			// Blur the ear when clicked.
			System.Windows.Media.Effects.BlurEffect blur =
			  new System.Windows.Media.Effects.BlurEffect();
			blur.Radius = 10;
			Line2_1.Effect = blur;
		}
	}
}
