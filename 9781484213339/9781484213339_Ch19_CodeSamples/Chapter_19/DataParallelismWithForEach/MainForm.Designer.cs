namespace DataParallelismWithForEach
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtInputArea = new System.Windows.Forms.TextBox();
            this.btnProcessImages = new System.Windows.Forms.Button();
            this.btnCancelTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Feel free to type here while the images are processed...";
            // 
            // txtInputArea
            // 
            this.txtInputArea.Location = new System.Drawing.Point(16, 48);
            this.txtInputArea.Multiline = true;
            this.txtInputArea.Name = "txtInputArea";
            this.txtInputArea.Size = new System.Drawing.Size(389, 141);
            this.txtInputArea.TabIndex = 1;
            // 
            // btnProcessImages
            // 
            this.btnProcessImages.Location = new System.Drawing.Point(199, 207);
            this.btnProcessImages.Name = "btnProcessImages";
            this.btnProcessImages.Size = new System.Drawing.Size(206, 23);
            this.btnProcessImages.TabIndex = 2;
            this.btnProcessImages.Text = "Click to Flip Your Images!";
            this.btnProcessImages.UseVisualStyleBackColor = true;
            this.btnProcessImages.Click += new System.EventHandler(this.btnProcessImages_Click);
            // 
            // btnCancelTask
            // 
            this.btnCancelTask.Location = new System.Drawing.Point(16, 207);
            this.btnCancelTask.Name = "btnCancelTask";
            this.btnCancelTask.Size = new System.Drawing.Size(75, 23);
            this.btnCancelTask.TabIndex = 3;
            this.btnCancelTask.Text = "Cancel!";
            this.btnCancelTask.UseVisualStyleBackColor = true;
            this.btnCancelTask.Click += new System.EventHandler(this.btnCancelTask_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 242);
            this.Controls.Add(this.btnCancelTask);
            this.Controls.Add(this.btnProcessImages);
            this.Controls.Add(this.txtInputArea);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fun with the TPL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInputArea;
        private System.Windows.Forms.Button btnProcessImages;
        private System.Windows.Forms.Button btnCancelTask;
    }
}

