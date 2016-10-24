using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading.Tasks;
using System.Net;

namespace MyEBookReader
{
    public partial class MainForm : Form
    {
        private string theEBook = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            // The Project Gutenberg EBook of A Tale of Two Cities, by Charles Dickens
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += (s, eArgs) => 
            { 
                theEBook = eArgs.Result;
                txtBook.Text = theEBook;
            };
            wc.DownloadStringAsync(new Uri("http://www.gutenberg.org/files/98/98-8.txt"));            
        }

        #region Do work in parallel!
        private void btnGetStats_Click(object sender, EventArgs e)
        {
            // Get the words from the e-book.
            string[] words = theEBook.Split(new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/' },
                StringSplitOptions.RemoveEmptyEntries);
            string[] tenMostCommon = null;
            string longestWord = string.Empty;

            Parallel.Invoke(
                () =>
                {
                    // Now, find the ten most common words.
                    tenMostCommon = FindTenMostCommon(words);
                },
                () =>
                {
                    // Get the longest word. 
                    longestWord = FindLongestWord(words);
                });

            // Now that all tasks are complete, build a string to show all
            // stats in a message box.
            StringBuilder bookStats = new StringBuilder("Ten Most Common Words are:\n");
            foreach (string s in tenMostCommon)
            {
                bookStats.AppendLine(s);
            }
            bookStats.AppendFormat("Longest word is: {0}", longestWord);
            bookStats.AppendLine();
            MessageBox.Show(bookStats.ToString(), "Book info");
        }
        #endregion

        #region Task methods.
        private string[] FindTenMostCommon(string[] words)
        {
            var frequencyOrder = from word in words
                                 where word.Length > 6
                                 group word by word into g
                                 orderby g.Count() descending
                                 select g.Key;

            string[] commonWords = (frequencyOrder.Take(10)).ToArray();
            return commonWords;
        }

        private string FindLongestWord(string[] words)
        {
            return (from w in words orderby w.Length descending select w).FirstOrDefault();
        }
        #endregion
    }
}
