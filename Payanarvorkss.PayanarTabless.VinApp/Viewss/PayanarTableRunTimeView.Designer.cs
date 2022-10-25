namespace WinFormsApp1.Viewss
{
    partial class PayanarTableRunTimeView
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
            this.components = new System.ComponentModel.Container();
            this.tableNameRichTextBox = new System.Windows.Forms.RichTextBox();
            this.addLinkLabel = new System.Windows.Forms.LinkLabel();
            this.columnsPanel = new System.Windows.Forms.Panel();
            this.rowsDataGridView = new System.Windows.Forms.DataGridView();
            this.columnToolBasePanel = new System.Windows.Forms.Panel();
            this.deleteColumnLinkLabel = new System.Windows.Forms.LinkLabel();
            this.addColumnLinkLabel = new System.Windows.Forms.LinkLabel();
            this.payanarTableDesignBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rowsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.headerPanel.SuspendLayout();
            this.detailssPanel.SuspendLayout();
            this.columnsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rowsDataGridView)).BeginInit();
            this.columnToolBasePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.payanarTableDesignBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.addLinkLabel);
            this.headerPanel.Controls.Add(this.tableNameRichTextBox);
            this.headerPanel.Padding = new System.Windows.Forms.Padding(2);
            this.headerPanel.Size = new System.Drawing.Size(1755, 78);
            // 
            // detailssPanel
            // 
            this.detailssPanel.Controls.Add(this.columnsPanel);
            this.detailssPanel.Location = new System.Drawing.Point(2, 80);
            this.detailssPanel.Size = new System.Drawing.Size(1755, 672);
            // 
            // tableNameRichTextBox
            // 
            this.tableNameRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableNameRichTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableNameRichTextBox.Location = new System.Drawing.Point(2, 2);
            this.tableNameRichTextBox.Name = "tableNameRichTextBox";
            this.tableNameRichTextBox.Size = new System.Drawing.Size(843, 72);
            this.tableNameRichTextBox.TabIndex = 0;
            this.tableNameRichTextBox.Text = "";
            // 
            // addLinkLabel
            // 
            this.addLinkLabel.AutoSize = true;
            this.addLinkLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addLinkLabel.Location = new System.Drawing.Point(878, 20);
            this.addLinkLabel.Name = "addLinkLabel";
            this.addLinkLabel.Size = new System.Drawing.Size(105, 41);
            this.addLinkLabel.TabIndex = 1;
            this.addLinkLabel.TabStop = true;
            this.addLinkLabel.Text = "Save()";
            this.addLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.saveLinkLabel_LinkClicked);
            // 
            // columnsPanel
            // 
            this.columnsPanel.Controls.Add(this.rowsDataGridView);
            this.columnsPanel.Controls.Add(this.columnToolBasePanel);
            this.columnsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.columnsPanel.Location = new System.Drawing.Point(0, 0);
            this.columnsPanel.Name = "columnsPanel";
            this.columnsPanel.Size = new System.Drawing.Size(1753, 670);
            this.columnsPanel.TabIndex = 0;
            // 
            // rowsDataGridView
            // 
            this.rowsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rowsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rowsDataGridView.Location = new System.Drawing.Point(0, 71);
            this.rowsDataGridView.Name = "rowsDataGridView";
            this.rowsDataGridView.RowHeadersWidth = 102;
            this.rowsDataGridView.RowTemplate.Height = 49;
            this.rowsDataGridView.Size = new System.Drawing.Size(1753, 599);
            this.rowsDataGridView.TabIndex = 1;
            this.rowsDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rowsDataGridView_CellContentDoubleClick);
            this.rowsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.rowsDataGridView_CellDoubleClick);
            // 
            // columnToolBasePanel
            // 
            this.columnToolBasePanel.Controls.Add(this.deleteColumnLinkLabel);
            this.columnToolBasePanel.Controls.Add(this.addColumnLinkLabel);
            this.columnToolBasePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.columnToolBasePanel.Location = new System.Drawing.Point(0, 0);
            this.columnToolBasePanel.Name = "columnToolBasePanel";
            this.columnToolBasePanel.Size = new System.Drawing.Size(1753, 71);
            this.columnToolBasePanel.TabIndex = 0;
            // 
            // deleteColumnLinkLabel
            // 
            this.deleteColumnLinkLabel.AutoSize = true;
            this.deleteColumnLinkLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.deleteColumnLinkLabel.Location = new System.Drawing.Point(148, 15);
            this.deleteColumnLinkLabel.Name = "deleteColumnLinkLabel";
            this.deleteColumnLinkLabel.Size = new System.Drawing.Size(131, 41);
            this.deleteColumnLinkLabel.TabIndex = 3;
            this.deleteColumnLinkLabel.TabStop = true;
            this.deleteColumnLinkLabel.Text = "Delete()";
            // 
            // addColumnLinkLabel
            // 
            this.addColumnLinkLabel.AutoSize = true;
            this.addColumnLinkLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addColumnLinkLabel.Location = new System.Drawing.Point(19, 15);
            this.addColumnLinkLabel.Name = "addColumnLinkLabel";
            this.addColumnLinkLabel.Size = new System.Drawing.Size(99, 41);
            this.addColumnLinkLabel.TabIndex = 2;
            this.addColumnLinkLabel.TabStop = true;
            this.addColumnLinkLabel.Text = "Add()";
            this.addColumnLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.addColumnLinkLabel_LinkClicked);
            // 
            // payanarTableDesignBindingSource
            // 
            this.payanarTableDesignBindingSource.DataSource = typeof(WinFormsApp1.Modelss.PayanarTableDesign);
            // 
            // PayanarTableRunTimeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "PayanarTableRunTimeView";
            this.Size = new System.Drawing.Size(1761, 756);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.detailssPanel.ResumeLayout(false);
            this.columnsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rowsDataGridView)).EndInit();
            this.columnToolBasePanel.ResumeLayout(false);
            this.columnToolBasePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.payanarTableDesignBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox tableNameRichTextBox;
        private LinkLabel addLinkLabel;
        private Panel columnsPanel;
        private Panel columnToolBasePanel;
        private BindingSource payanarTableDesignBindingSource;
        private LinkLabel deleteColumnLinkLabel;
        private LinkLabel addColumnLinkLabel;
        private DataGridView rowsDataGridView;
        private BindingSource rowsBindingSource;
    }
}
