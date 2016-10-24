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

namespace RenderingWithVisuals
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.MouseDown += MyVisualHost_MouseDown;
		}

		private void MyVisualHost_MouseDown(object sender, MouseButtonEventArgs e)
		{
			// Figure out where the user clicked.
			Point pt = e.GetPosition((UIElement)sender);

			// Call helper function via delegate to see if we clicked on a visual.
			VisualTreeHelper.HitTest(this, null,
			MyCallback, new PointHitTestParameters(pt));
		}

		public HitTestResultBehavior MyCallback(HitTestResult result)
		{
			// Toggle between a skewed rendering and normal rendering,
			// if a visual was clicked.
			if (result.VisualHit.GetType() == typeof(DrawingVisual))
			{
				((DrawingVisual)result.VisualHit).Transform = 
					((DrawingVisual)result.VisualHit).Transform == null ? 
					new SkewTransform(7, 7) : null;
			}

			// Tell HitTest() to stop drilling into the visual tree.
			return HitTestResultBehavior.Stop;
		}


		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			const int textFontSize = 30;

			// Make a System.Windows.Media.FormattedText object.
			var text = new FormattedText("Hello Visual Layer!",
			  new System.Globalization.CultureInfo("en-us"),
			  FlowDirection.LeftToRight,
			  new Typeface(this.FontFamily, FontStyles.Italic,
							FontWeights.DemiBold, FontStretches.UltraExpanded),
			  textFontSize,
			  Brushes.Green);

			// Create a DrawingVisual, and obtain the DrawingContext.
			var drawingVisual = new DrawingVisual();
			using (DrawingContext drawingContext = drawingVisual.RenderOpen())
			{
				// Now, call any of the methods of DrawingContext to render data.
				drawingContext.DrawRoundedRectangle(Brushes.Yellow, new Pen(Brushes.Black, 5),
				  new Rect(5, 5, 450, 100), 20, 20);
				drawingContext.DrawText(text, new Point(20, 20));
			}

			// Dynamically make a bitmap, using the data in the DrawingVisual.
			var bmp = new RenderTargetBitmap(500, 100, 100, 90,
			  PixelFormats.Pbgra32);
			bmp.Render(drawingVisual);

			// Set the source of the Image control!
			myImage.Source = bmp;
		}
	}
}
