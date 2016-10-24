using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace PLINQDataProcessingWithCancellation
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource cancelToken = new CancellationTokenSource();

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            // Start a new "task" to process the files. 
            Task.Factory.StartNew(() =>
            {
                ProcessIntData();
            });
        }

        private void ProcessIntData()
        {
            // Get a very large array of integers. 
            int[] source = Enumerable.Range(1, 10000000).ToArray();

            // Find the numbers where num % 3 == 0 is true, returned
            // in descending order. 
            int[] modThreeIsZero = null;
            try
            {
                modThreeIsZero = (from num in source.AsParallel().WithCancellation(cancelToken.Token)
                                  where num % 3 == 0
                                  orderby num descending
                                  select num).ToArray();
                MessageBox.Show(string.Format("Found {0} numbers that match query!", modThreeIsZero.Count()));
            }
            catch (OperationCanceledException ex)
            {
                this.Invoke((Action)delegate
                {
                    this.Text = ex.Message;
                });
            }                
        }
    }
}
