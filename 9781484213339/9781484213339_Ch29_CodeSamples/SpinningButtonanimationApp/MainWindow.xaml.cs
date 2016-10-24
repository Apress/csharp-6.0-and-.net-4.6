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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpinningButtonanimationApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private bool _isSpinning = false;
		public MainWindow()
		{
			InitializeComponent();
		}

		private void btnSpinner_MouseEnter(object sender, MouseEventArgs e)
		{
			if (_isSpinning) return;
			_isSpinning = true;
			// Make a double animation object, and register
			// with the Completed event.
			var dblAnim = new DoubleAnimation
			{
				// Button has four seconds to finish the spin!
				Duration = new Duration(TimeSpan.FromSeconds(4)),
				// Set the start value and end value.
				From = 0,
				To = 360
			};

			dblAnim.Completed += (o, s) => { _isSpinning = false; };
			// Now, create a RotateTransform object, and set
			// it to the RenderTransform property of our
			// button.
			var rt = new RotateTransform();
			btnSpinner.RenderTransform = rt;

			// Now, animation the RotateTransform object.
			rt.BeginAnimation(RotateTransform.AngleProperty, dblAnim);
		}

		private void btnSpinner_OnClick(object sender, RoutedEventArgs e)
		{
			var dblAnim = new DoubleAnimation
			{
				From = 1.0,
				To = 0.0
			};
			// Reverse when done.
			dblAnim.AutoReverse = true;

			btnSpinner.BeginAnimation(Button.OpacityProperty, dblAnim);
		}
	}
}
