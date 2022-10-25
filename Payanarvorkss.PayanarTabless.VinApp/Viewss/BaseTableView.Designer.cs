namespace WinFormsApp1.Viewss
{
    partial class BaseTableView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.basePanel = new System.Windows.Forms.Panel();
            this.detailssPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.basePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.BackColor = System.Drawing.Color.White;
            this.basePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.basePanel.Controls.Add(this.detailssPanel);
            this.basePanel.Controls.Add(this.headerPanel);
            this.basePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.basePanel.Location = new System.Drawing.Point(0, 0);
            this.basePanel.Name = "basePanel";
            this.basePanel.Padding = new System.Windows.Forms.Padding(2);
            this.basePanel.Size = new System.Drawing.Size(1610, 619);
            this.basePanel.TabIndex = 0;
            // 
            // detailssPanel
            // 
            this.detailssPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailssPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailssPanel.Location = new System.Drawing.Point(2, 100);
            this.detailssPanel.Name = "detailssPanel";
            this.detailssPanel.Size = new System.Drawing.Size(1604, 515);
            this.detailssPanel.TabIndex = 1;
            // 
            // headerPanel
            // 
            this.headerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(2, 2);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1604, 98);
            this.headerPanel.TabIndex = 0;
            // 
            // BaseTableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.basePanel);
            this.Name = "BaseTableView";
            this.Size = new System.Drawing.Size(1610, 619);
            this.basePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel basePanel;
        public Panel headerPanel;
        public Panel detailssPanel;
    }
}
