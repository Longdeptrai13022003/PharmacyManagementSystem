namespace MedicalStoreManagementSystem.GUI
{
    partial class formPrint
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
            this.rpvReceipt = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvReceipt
            // 
            this.rpvReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvReceipt.Location = new System.Drawing.Point(0, 0);
            this.rpvReceipt.Name = "rpvReceipt";
            this.rpvReceipt.ServerReport.BearerToken = null;
            this.rpvReceipt.Size = new System.Drawing.Size(672, 893);
            this.rpvReceipt.TabIndex = 0;
            // 
            // formPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 893);
            this.Controls.Add(this.rpvReceipt);
            this.Name = "formPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Print";
            this.Load += new System.EventHandler(this.formPrint_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvReceipt;
    }
}