using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunWithCSharpAsync
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void btnCallMethod_Click(object sender, EventArgs e)
        {
            this.Text = await DoWorkAsync();
        }

        private async Task<string> DoWorkAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(10000);                 
                return "Done with work!";
            });
        }

        private async void btnVoidMethodCall_Click(object sender, EventArgs e)
        {
            await MethodReturningVoidAsync();
            MessageBox.Show("Done!");
        }

        private async Task MethodReturningVoidAsync()
        {
            await Task.Run(() =>
            { /* Do some work here... */
                Thread.Sleep(4000);
            });
        }

        private async void btnMutliAwaits_Click(object sender, EventArgs e)
        {
            await Task.Run(() => { Thread.Sleep(2000); });
            MessageBox.Show("Done with first task!");

            await Task.Run(() => { Thread.Sleep(2000); });
            MessageBox.Show("Done with second task!");

            await Task.Run(() => { Thread.Sleep(2000); });
            MessageBox.Show("Done with third task!");
        }
    }
}
