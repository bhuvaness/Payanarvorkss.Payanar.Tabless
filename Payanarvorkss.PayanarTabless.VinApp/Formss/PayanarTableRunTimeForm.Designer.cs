namespace WinFormsApp1.Formss
{
    partial class PayanarTableRunTimeForm
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
            this.payanarTableRunTimeView = new WinFormsApp1.Viewss.PayanarTableRunTimeView();
            this.SuspendLayout();
            // 
            // payanarTableRunTimeView
            // 
            this.payanarTableRunTimeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payanarTableRunTimeView.Location = new System.Drawing.Point(0, 0);
            this.payanarTableRunTimeView.Name = "payanarTableRunTimeView";
            this.payanarTableRunTimeView.Size = new System.Drawing.Size(1871, 845);
            this.payanarTableRunTimeView.TabIndex = 0;
            // 
            // PayanarTableRunTimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1871, 845);
            this.Controls.Add(this.payanarTableRunTimeView);
            this.Name = "PayanarTableRunTimeForm";
            this.Text = "PayanarTableDesignForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Viewss.PayanarTableRunTimeView payanarTableRunTimeView;
    }
}