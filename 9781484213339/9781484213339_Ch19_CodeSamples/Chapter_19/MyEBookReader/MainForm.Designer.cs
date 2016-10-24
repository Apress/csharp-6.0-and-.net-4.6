namespace MyEBookReader
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBook = new System.Windows.Forms.TextBox();
            this.btnGetStats = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBook
            // 
            this.txtBook.Location = new System.Drawing.Point(13, 13);
            this.txtBook.Multiline = true;
            this.txtBook.Name = "txtBook";
            this.txtBook.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBook.Size = new System.Drawing.Size(585, 282);
            this.txtBook.TabIndex = 0;
            // 
            // btnGetStats
            // 
            this.btnGetStats.Location = new System.Drawing.Point(487, 313);
            this.btnGetStats.Name = "btnGetStats";
            this.btnGetStats.Size = new System.Drawing.Size(111, 23);
            this.btnGetStats.TabIndex = 2;
            this.btnGetStats.Text = "Get Book Stats";
            this.btnGetStats.UseVisualStyleBackColor = true;
            this.btnGetStats.Click += new System.EventHandler(this.btnGetStats_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(397, 313);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 348);
            this.Controls.Add(this.btnGetStats);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtBook);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My EBook Reader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBook;
        private System.Windows.Forms.Button btnGetStats;
        private System.Windows.Forms.Button btnDownload;
    }
}

