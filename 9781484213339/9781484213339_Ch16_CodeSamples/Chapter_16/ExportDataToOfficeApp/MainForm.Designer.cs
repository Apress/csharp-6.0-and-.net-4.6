namespace ExportDataToOfficeApp
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
            this.lblInstructions = new System.Windows.Forms.Label();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.dataGridCars = new System.Windows.Forms.DataGridView();
            this.btnAddNewCar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.Location = new System.Drawing.Point(13, 13);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(137, 18);
            this.lblInstructions.TabIndex = 1;
            this.lblInstructions.Text = "Current Inventory";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Location = new System.Drawing.Point(288, 221);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(209, 23);
            this.btnExportToExcel.TabIndex = 2;
            this.btnExportToExcel.Text = "Export Current Inventory to Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // dataGridCars
            // 
            this.dataGridCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCars.Location = new System.Drawing.Point(16, 45);
            this.dataGridCars.Name = "dataGridCars";
            this.dataGridCars.Size = new System.Drawing.Size(481, 158);
            this.dataGridCars.TabIndex = 3;
            // 
            // btnAddNewCar
            // 
            this.btnAddNewCar.Location = new System.Drawing.Point(12, 221);
            this.btnAddNewCar.Name = "btnAddNewCar";
            this.btnAddNewCar.Size = new System.Drawing.Size(204, 23);
            this.btnAddNewCar.TabIndex = 4;
            this.btnAddNewCar.Text = "Add New Entry to Inventory";
            this.btnAddNewCar.UseVisualStyleBackColor = true;
            this.btnAddNewCar.Click += new System.EventHandler(this.btnAddNewCar_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 265);
            this.Controls.Add(this.btnAddNewCar);
            this.Controls.Add(this.dataGridCars);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.lblInstructions);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Office COM Interop App!";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.DataGridView dataGridCars;
        private System.Windows.Forms.Button btnAddNewCar;
    }
}

