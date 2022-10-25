namespace WinFormsApp1.Viewss
{
    partial class PayanarTypeSelectionView
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.searchLinkLabel = new System.Windows.Forms.LinkLabel();
            this.payanarTypessDataGridView = new System.Windows.Forms.DataGridView();
            this.payanarTypeSelectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headerPanel.SuspendLayout();
            this.detailssPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.payanarTypessDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.payanarTypeSelectionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.searchLinkLabel);
            this.headerPanel.Controls.Add(this.richTextBox1);
            this.headerPanel.Size = new System.Drawing.Size(1590, 98);
            // 
            // detailssPanel
            // 
            this.detailssPanel.Controls.Add(this.payanarTypessDataGridView);
            this.detailssPanel.Size = new System.Drawing.Size(1590, 728);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(843, 96);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // searchLinkLabel
            // 
            this.searchLinkLabel.AutoSize = true;
            this.searchLinkLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.searchLinkLabel.Location = new System.Drawing.Point(870, 26);
            this.searchLinkLabel.Name = "searchLinkLabel";
            this.searchLinkLabel.Size = new System.Drawing.Size(133, 41);
            this.searchLinkLabel.TabIndex = 2;
            this.searchLinkLabel.TabStop = true;
            this.searchLinkLabel.Text = "Search()";
            // 
            // payanarTypessDataGridView
            // 
            this.payanarTypessDataGridView.AllowUserToAddRows = false;
            this.payanarTypessDataGridView.AllowUserToDeleteRows = false;
            this.payanarTypessDataGridView.AutoGenerateColumns = false;
            this.payanarTypessDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.payanarTypessDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tableNameDataGridViewTextBoxColumn,
            this.columnNameDataGridViewTextBoxColumn});
            this.payanarTypessDataGridView.DataSource = this.payanarTypeSelectionBindingSource;
            this.payanarTypessDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payanarTypessDataGridView.Location = new System.Drawing.Point(0, 0);
            this.payanarTypessDataGridView.Name = "payanarTypessDataGridView";
            this.payanarTypessDataGridView.ReadOnly = true;
            this.payanarTypessDataGridView.RowHeadersVisible = false;
            this.payanarTypessDataGridView.RowHeadersWidth = 102;
            this.payanarTypessDataGridView.RowTemplate.Height = 49;
            this.payanarTypessDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.payanarTypessDataGridView.Size = new System.Drawing.Size(1588, 726);
            this.payanarTypessDataGridView.TabIndex = 0;
            this.payanarTypessDataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.payanarTypessDataGridView_CellMouseDoubleClick);
            // 
            // payanarTypeSelectionBindingSource
            // 
            this.payanarTypeSelectionBindingSource.DataSource = typeof(WinFormsApp1.Modelss.PayanarTypeSelection);
            // 
            // tableNameDataGridViewTextBoxColumn
            // 
            this.tableNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tableNameDataGridViewTextBoxColumn.DataPropertyName = "TableFullName";
            this.tableNameDataGridViewTextBoxColumn.HeaderText = "TableName";
            this.tableNameDataGridViewTextBoxColumn.MinimumWidth = 200;
            this.tableNameDataGridViewTextBoxColumn.Name = "tableNameDataGridViewTextBoxColumn";
            this.tableNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnNameDataGridViewTextBoxColumn
            // 
            this.columnNameDataGridViewTextBoxColumn.DataPropertyName = "ColumnName";
            this.columnNameDataGridViewTextBoxColumn.HeaderText = "ColumnName";
            this.columnNameDataGridViewTextBoxColumn.MinimumWidth = 300;
            this.columnNameDataGridViewTextBoxColumn.Name = "columnNameDataGridViewTextBoxColumn";
            this.columnNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.columnNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // PayanarTypeSelectionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "PayanarTypeSelectionView";
            this.Size = new System.Drawing.Size(1596, 832);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.detailssPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.payanarTypessDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.payanarTypeSelectionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox richTextBox1;
        private LinkLabel searchLinkLabel;
        private DataGridView payanarTypessDataGridView;
        private BindingSource payanarTypeSelectionBindingSource;
        private DataGridViewTextBoxColumn tableNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn columnNameDataGridViewTextBoxColumn;
    }
}
