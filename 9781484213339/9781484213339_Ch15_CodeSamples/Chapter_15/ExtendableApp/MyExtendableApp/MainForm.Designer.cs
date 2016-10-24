namespace MyExtendableApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.snapInModuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstLoadedSnapIns = new System.Windows.Forms.ListBox();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // snapInModuleToolStripMenuItem
            // 
            this.snapInModuleToolStripMenuItem.Name = "snapInModuleToolStripMenuItem";
            this.snapInModuleToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.snapInModuleToolStripMenuItem.Text = "&Snap In Module...";
            this.snapInModuleToolStripMenuItem.Click += new System.EventHandler(this.snapInModuleToolStripMenuItem_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(531, 24);
            this.mainMenuStrip.TabIndex = 2;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.snapInModuleToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // lstLoadedSnapIns
            // 
            this.lstLoadedSnapIns.FormattingEnabled = true;
            this.lstLoadedSnapIns.Location = new System.Drawing.Point(12, 101);
            this.lstLoadedSnapIns.Name = "lstLoadedSnapIns";
            this.lstLoadedSnapIns.Size = new System.Drawing.Size(507, 95);
            this.lstLoadedSnapIns.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 208);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.lstLoadedSnapIns);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Extensible App!";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem snapInModuleToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ListBox lstLoadedSnapIns;
    }
}

