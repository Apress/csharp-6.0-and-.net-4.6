using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Create an alais to the Excel object model.
using Excel = Microsoft.Office.Interop.Excel;

namespace ExportDataToOfficeApp
{
    public partial class MainForm : Form
    {
        List<Car> carsInStock = null;

        public MainForm()
        {
            InitializeComponent();
        }

        #region UI event handlers
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(carsInStock);
            // ExportToExcel2008(carsInStock);
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            carsInStock = new List<Car> 
            {
                new Car {Color="Green", Make="VW", PetName="Mary"},
                new Car {Color="Red", Make="Saab", PetName="Mel"},
                new Car {Color="Black", Make="Ford", PetName="Hank"},
                new Car {Color="Yellow", Make="BMW", PetName="Davie"} 
            };
            UpdateGrid();
        }

        private void btnAddNewCar_Click(object sender, EventArgs e)
        {
            NewCarDialog d = new NewCarDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                // Add new car to list.
                carsInStock.Add(d.theCar);
                UpdateGrid();
            }
        }
        #endregion

        #region Export to Excel spreadsheet using C# dynamic features.
        static void ExportToExcel(List<Car> carsInStock)
        {
            // Load up Excel, then make a new empty workbook.
            Excel.Application excelApp = new Excel.Application();
            excelApp.Workbooks.Add();

            // This example uses a single workSheet. 
            Excel._Worksheet workSheet = excelApp.ActiveSheet;

            // Establish column headings in cells.
            workSheet.Cells[1, "A"] = "Make";
            workSheet.Cells[1, "B"] = "Color";
            workSheet.Cells[1, "C"] = "Pet Name";

            // Now, map all data in List<Car> to the cells of the spread sheet. 
            int row = 1;
            foreach (Car c in carsInStock)
            {
                row++;
                workSheet.Cells[row, "A"] = c.Make;
                workSheet.Cells[row, "B"] = c.Color;
                workSheet.Cells[row, "C"] = c.PetName;
            }

            // Give our table data a nice look and feel. 
            workSheet.Range["A1"].AutoFormat(
                Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);

            // Save the file, quit Excel and display message to user. 
            workSheet.SaveAs(string.Format(@"{0}\Inventory.xlsx", Environment.CurrentDirectory));
            excelApp.Quit();
            MessageBox.Show("The Inventory.xslx file has been saved to your app folder", "Export complete!");
        }
        #endregion

        #region Export to Excel spreadsheed without C# 4.0 and higher features.
        static void ExportToExcel2008(List<Car> carsInStock)
        {
            Excel.Application excelApp = new Excel.Application();

            // Must mark missing params! 
            excelApp.Workbooks.Add(Type.Missing);

            // Must cast Object as _Worksheet! 
            Excel._Worksheet workSheet = (Excel._Worksheet)excelApp.ActiveSheet;

            // Must cast each Object as Range object then call
            // call low level Value2 property!
            ((Excel.Range)excelApp.Cells[1, "A"]).Value2 = "Make";
            ((Excel.Range)excelApp.Cells[1, "B"]).Value2 = "Color";
            ((Excel.Range)excelApp.Cells[1, "C"]).Value2 = "Pet Name";

            int row = 1;
            foreach (Car c in carsInStock)
            {
                row++;
                // Must cast each Object as Range and call low level Value2 prop!
                ((Excel.Range)workSheet.Cells[row, "A"]).Value2 = c.Make;
                ((Excel.Range)workSheet.Cells[row, "B"]).Value2 = c.Color;
                ((Excel.Range)workSheet.Cells[row, "C"]).Value2 = c.PetName;
            }

            // Must call get_Range method and then specify all missing args!. 
            excelApp.get_Range("A1", Type.Missing).AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing);

            // Must specify all missing optional args!  
            workSheet.SaveAs(string.Format(@"{0}\Inventory.xlsx", Environment.CurrentDirectory),
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing);
            excelApp.Quit();
            MessageBox.Show("The Inventory.xslx file has been saved to your app folder", "Export complete!");
        }
        #endregion

        #region Update the grid.
        private void UpdateGrid()
        {
            // Reset the source of data. 
            dataGridCars.DataSource = null;
            dataGridCars.DataSource = carsInStock;
        }
        #endregion
    }
}
