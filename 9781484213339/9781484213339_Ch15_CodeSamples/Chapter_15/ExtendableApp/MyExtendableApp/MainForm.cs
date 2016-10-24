using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using CommonSnappableTypes;

namespace MyExtendableApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Menu handler
        private void snapInModuleToolStripMenuItem_Click(object sender,
          EventArgs e)
        {
            // Allow user to select an assembly to load.
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.FileName.Contains("CommonSnappableTypes"))
                    MessageBox.Show("CommonSnappableTypes has no snap-ins!");
                else if (!LoadExternalModule(dlg.FileName))
                    MessageBox.Show("Nothing implements IAppFunctionality!");
            }
        }
        #endregion

        #region Load external assembly
        private bool LoadExternalModule(string path)
        {
            bool foundSnapIn = false;
            Assembly theSnapInAsm = null;

            try
            {
                // Dynamically load the selected assembly.
                theSnapInAsm = Assembly.LoadFrom(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return foundSnapIn;
            }

            // Get all IAppFunctionality compatible classes in assembly.
            var theClassTypes = from t in theSnapInAsm.GetTypes()
                                where t.IsClass &&
                                (t.GetInterface("IAppFunctionality") != null) 
                                select t;

            // Now, create the object and call DoIt() method.
            foreach (Type t in theClassTypes)
            {
                foundSnapIn = true;
                // Use late binding to create the type.
                IAppFunctionality itfApp =
                  (IAppFunctionality)theSnapInAsm.CreateInstance(t.FullName, true);
                itfApp.DoIt();
                lstLoadedSnapIns.Items.Add(t.FullName);

                // Show company info.
                DisplayCompanyData(t);

            }
            return foundSnapIn;
        }
        #endregion

        #region Show company info
        private void DisplayCompanyData(Type t)
        {
            // Get [CompanyInfo] data.
            var compInfo = from ci in t.GetCustomAttributes(false)
                           where
                               (ci.GetType() == typeof(CompanyInfoAttribute))
                           select ci;

            // Show data.
            foreach (CompanyInfoAttribute c in compInfo)
            {
                MessageBox.Show(c.CompanyUrl,
                  string.Format("More info about {0} can be found at", c.CompanyName));
            }
        }
        #endregion
    }
}
