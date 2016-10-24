using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace RenderingWithVisuals
{
	class CustomVisualFrameworkElement : FrameworkElement
	{
		private VisualCollection _theVisuals;
		public CustomVisualFrameworkElement()
		{
			// Fill the VisualCollection with a few DrawingVisual objects.
			// The ctor arg represents the owner of the visuals.
			_theVisuals = new VisualCollection(this) {AddRect(), AddCircle()};
		}
		private Visual AddCircle()
		{
			var drawingVisual = new DrawingVisual();

			// Retrieve the DrawingContext in order to create new drawing content.
			using (DrawingContext drawingContext = drawingVisual.RenderOpen())
			{
				// Create a circle and draw it in the DrawingContext.
				var rect = new Rect(new Point(160, 100), new Size(320, 80));
				drawingContext.DrawEllipse(Brushes.DarkBlue, null, new Point(70, 90), 40, 50);
			}
			return drawingVisual;
		}
		private Visual AddRect()
		{
			var drawingVisual = new DrawingVisual();
			using (DrawingContext drawingContext = drawingVisual.RenderOpen())
			{
				var rect = new Rect(new Point(160, 100), new Size(320, 80));
				drawingContext.DrawRectangle(Brushes.Tomato, null, rect);
			}
			return drawingVisual;
		}
		protected override int VisualChildrenCount => _theVisuals.Count;

		protected override Visual GetVisualChild(int index)
		{
			// Value must be greater than zero, so do a sainity check.
			if (index < 0 || index >= _theVisuals.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return _theVisuals[index];
		}

	}
}
