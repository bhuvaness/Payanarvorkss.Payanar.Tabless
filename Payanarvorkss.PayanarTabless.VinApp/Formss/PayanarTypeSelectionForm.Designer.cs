namespace WinFormsApp1.Formss
{
    partial class PayanarTypeSelectionForm
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
            this.payanarTypeSelectionView = new WinFormsApp1.Viewss.PayanarTypeSelectionView();
            this.SuspendLayout();
            // 
            // payanarTypeSelectionView
            // 
            this.payanarTypeSelectionView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payanarTypeSelectionView.Location = new System.Drawing.Point(0, 0);
            this.payanarTypeSelectionView.Name = "payanarTypeSelectionView";
            this.payanarTypeSelectionView.Size = new System.Drawing.Size(1698, 735);
            this.payanarTypeSelectionView.TabIndex = 0;
            // 
            // PayanarTypeSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1698, 735);
            this.Controls.Add(this.payanarTypeSelectionView);
            this.Name = "PayanarTypeSelectionForm";
            this.Text = "PayanarTypeSelectionForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Viewss.PayanarTypeSelectionView payanarTypeSelectionView;
    }
}