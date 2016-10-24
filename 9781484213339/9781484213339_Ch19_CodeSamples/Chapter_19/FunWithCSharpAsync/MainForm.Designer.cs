namespace FunWithCSharpAsync
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
            this.btnCallMethod = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnVoidMethodCall = new System.Windows.Forms.Button();
            this.btnMutliAwaits = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCallMethod
            // 
            this.btnCallMethod.Location = new System.Drawing.Point(13, 13);
            this.btnCallMethod.Name = "btnCallMethod";
            this.btnCallMethod.Size = new System.Drawing.Size(115, 31);
            this.btnCallMethod.TabIndex = 0;
            this.btnCallMethod.Text = "Call Method";
            this.btnCallMethod.UseVisualStyleBackColor = true;
            this.btnCallMethod.Click += new System.EventHandler(this.btnCallMethod_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type Here!";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(171, 47);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(253, 114);
            this.txtInput.TabIndex = 2;
            // 
            // btnVoidMethodCall
            // 
            this.btnVoidMethodCall.Location = new System.Drawing.Point(13, 67);
            this.btnVoidMethodCall.Name = "btnVoidMethodCall";
            this.btnVoidMethodCall.Size = new System.Drawing.Size(115, 32);
            this.btnVoidMethodCall.TabIndex = 3;
            this.btnVoidMethodCall.Text = "Call Void Method";
            this.btnVoidMethodCall.UseVisualStyleBackColor = true;
            this.btnVoidMethodCall.Click += new System.EventHandler(this.btnVoidMethodCall_Click);
            // 
            // btnMutliAwaits
            // 
            this.btnMutliAwaits.Location = new System.Drawing.Point(13, 129);
            this.btnMutliAwaits.Name = "btnMutliAwaits";
            this.btnMutliAwaits.Size = new System.Drawing.Size(115, 32);
            this.btnMutliAwaits.TabIndex = 4;
            this.btnMutliAwaits.Text = "Multiple Awaits";
            this.btnMutliAwaits.UseVisualStyleBackColor = true;
            this.btnMutliAwaits.Click += new System.EventHandler(this.btnMutliAwaits_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 173);
            this.Controls.Add(this.btnMutliAwaits);
            this.Controls.Add(this.btnVoidMethodCall);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCallMethod);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fun with Async and Await";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCallMethod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnVoidMethodCall;
        private System.Windows.Forms.Button btnMutliAwaits;
    }
}

