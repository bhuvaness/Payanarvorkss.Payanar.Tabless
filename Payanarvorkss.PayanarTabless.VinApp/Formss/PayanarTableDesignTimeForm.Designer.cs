namespace WinFormsApp1.Formss
{
    partial class PayanarTableDesignTimeForm
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
            this.payanarTableDesignView1 = new WinFormsApp1.Viewss.PayanarTableDesignTimeView();
            this.SuspendLayout();
            // 
            // payanarTableDesignView1
            // 
            this.payanarTableDesignView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payanarTableDesignView1.Location = new System.Drawing.Point(0, 0);
            this.payanarTableDesignView1.Name = "payanarTableDesignView1";
            this.payanarTableDesignView1.Size = new System.Drawing.Size(1871, 845);
            this.payanarTableDesignView1.TabIndex = 0;
            // 
            // PayanarTableDesignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1871, 845);
            this.Controls.Add(this.payanarTableDesignView1);
            this.Name = "PayanarTableDesignForm";
            this.Text = "PayanarTableDesignForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Viewss.PayanarTableDesignTimeView payanarTableDesignView1;
    }
}