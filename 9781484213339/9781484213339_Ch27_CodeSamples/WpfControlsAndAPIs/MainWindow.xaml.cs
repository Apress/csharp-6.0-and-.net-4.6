using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AutoLotDAL.Models;
using AutoLotDAL.Repos;

namespace WpfControlsAndAPIs
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
			this.inkRadio.IsChecked = true;
			this.comboColors.SelectedIndex = 0;
			PopulateDocument();
			EnableAnnotations();
			// Rig up some Click handlers for the save/load of the flow doc.
			btnSaveDoc.Click += (o, s) =>
			{
				using (FileStream fStream = File.Open(
				  "documentData.xaml", FileMode.Create))
				{
					XamlWriter.Save(this.myDocumentReader.Document, fStream);
				}
			};

			btnLoadDoc.Click += (o, s) =>
			{
				using (FileStream fStream = File.Open("documentData.xaml", FileMode.Open))
				{
					try
					{
						FlowDocument doc = XamlReader.Load(fStream) as FlowDocument;
						this.myDocumentReader.Document = doc;
					}
					catch (Exception ex) { MessageBox.Show(ex.Message, "Error Loading Doc!"); }
				}
			};
			SetBindings();
			ConfigureGrid();
		}

		private void RadioButtonClicked(object sender, RoutedEventArgs e)
		{
			switch ((sender as RadioButton)?.Content.ToString())
			{
				// These strings must be the same as the Content values for each
				// RadioButton.
				case "Ink Mode!":
					this.myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
					break;

				case "Erase Mode!":
					this.myInkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
					break;

				case "Select Mode!":
					this.myInkCanvas.EditingMode = InkCanvasEditingMode.Select;
					break;
			}

		}

		private void ColorChanged(object sender, SelectionChangedEventArgs e)
		{
			// Get the selected value in the combo box.
			//string colorToUse =
			//  (comboColors.SelectedItem as ComboBoxItem)?.Content.ToString();
			string colorToUse =
			  (comboColors.SelectedItem as StackPanel)?.Tag.ToString();

			// Change the color used to render the strokes.
			this.myInkCanvas.DefaultDrawingAttributes.Color =
			  (Color)ColorConverter.ConvertFromString(colorToUse);

		}

		private void SaveData(object sender, System.Windows.RoutedEventArgs e)
		{
			// Save all data on the InkCanvas to a local file.
			using (FileStream fs = new FileStream("StrokeData.bin", FileMode.Create))
			{
				this.myInkCanvas.Strokes.Save(fs);
				fs.Close();
			}
		}

		private void LoadData(object sender, System.Windows.RoutedEventArgs e)
		{
			// Fill StrokeCollection from file.
			using (FileStream fs = new FileStream("StrokeData.bin",
			  FileMode.Open, FileAccess.Read))
			{
				StrokeCollection strokes = new StrokeCollection(fs);
				this.myInkCanvas.Strokes = strokes;
			}
		}

		private void Clear(object sender, System.Windows.RoutedEventArgs e)
		{
			// Clear all strokes.
			this.myInkCanvas.Strokes.Clear();
		}

		private void PopulateDocument()
		{
			// Add some data to the List item.
			this.listOfFunFacts.FontSize = 14;
			this.listOfFunFacts.MarkerStyle = TextMarkerStyle.Circle;
			this.listOfFunFacts.ListItems.Add(new ListItem(new
			  Paragraph(new Run("Fixed documents are for WYSIWYG print ready docs!"))));
			this.listOfFunFacts.ListItems.Add(new ListItem(
			  new Paragraph(new Run("The API supports tables and embedded figures!"))));
			this.listOfFunFacts.ListItems.Add(new ListItem(
			  new Paragraph(new Run("Flow documents are read only!"))));
			this.listOfFunFacts.ListItems.Add(new ListItem(new Paragraph(new Run
			  ("BlockUIContainer allows you to embed WPF controls in the document!")
			  )));

			// Now add some data to the Paragraph.
			// First part of sentence.
			Run prefix = new Run("This paragraph was generated ");

			// Middle of paragraph.
			Bold b = new Bold();
			Run infix = new Run("dynamically");
			infix.Foreground = Brushes.Red;
			infix.FontSize = 30;
			b.Inlines.Add(infix);

			// Last part of paragraph.
			Run suffix = new Run(" at runtime!");

			// Now add each piece to the collection of inline elements
			// of the Paragraph.
			this.paraBodyText.Inlines.Add(prefix);
			this.paraBodyText.Inlines.Add(infix);
			this.paraBodyText.Inlines.Add(suffix);
		}
		private void EnableAnnotations()
		{
			// Create the AnnotationService object that works
			// with our FlowDocumentReader.
			AnnotationService anoService = new AnnotationService(myDocumentReader);

			// Create a MemoryStream that will hold the annotations.
			MemoryStream anoStream = new MemoryStream();

			// Now, create an XML-based store based on the MemoryStream.
			// You could use this object to programmatically add, delete,
			// or find annotations.
			AnnotationStore store = new XmlStreamStore(anoStream);

			// Enable the annotation services.
			anoService.Enable(store);
		}
		private void SetBindings()
		{
			// Create a Binding object.
			Binding b = new Binding();

			// Register the converter, source, and path.
			b.Converter = new MyDoubleConverter();
			b.Source = this.mySB;
			b.Path = new PropertyPath("Value");

			// Call the SetBinding method on the Label.
			this.labelSBThumb.SetBinding(Label.ContentProperty, b);
		}
		private void ConfigureGrid()
		{
			using (var repo = new InventoryRepo())
			{
				// Build a LINQ query that gets back some data from the Inventory table.
				gridInventory.ItemsSource = repo.GetAll().Select(x=>new { x.CarId,x.Make,x.Color,x.PetName});
			}
		}

	}
}
