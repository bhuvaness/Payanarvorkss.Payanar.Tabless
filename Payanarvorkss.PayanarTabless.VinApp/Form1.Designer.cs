namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.uniqueIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payanarTableDesignBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.hierarchicalPayanarTypeTreeView = new System.Windows.Forms.TreeView();
            this.toolbarPanel = new System.Windows.Forms.Panel();
            this.addTblButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.payanarTableDesignBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolbarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.uniqueIdDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.payanarTableDesignBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(1170, 249);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 102;
            this.dataGridView1.Size = new System.Drawing.Size(1518, 755);
            this.dataGridView1.TabIndex = 0;
            // 
            // uniqueIdDataGridViewTextBoxColumn
            // 
            this.uniqueIdDataGridViewTextBoxColumn.DataPropertyName = "UniqueId";
            this.uniqueIdDataGridViewTextBoxColumn.HeaderText = "UniqueId";
            this.uniqueIdDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.uniqueIdDataGridViewTextBoxColumn.Name = "uniqueIdDataGridViewTextBoxColumn";
            this.uniqueIdDataGridViewTextBoxColumn.Width = 250;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 12;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 250;
            // 
            // payanarTableDesignBindingSource
            // 
            this.payanarTableDesignBindingSource.DataSource = typeof(WinFormsApp1.Modelss.PayanarTableDesign);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.hierarchicalPayanarTypeTreeView);
            this.panel1.Controls.Add(this.toolbarPanel);
            this.panel1.Location = new System.Drawing.Point(185, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(756, 1324);
            this.panel1.TabIndex = 2;
            // 
            // hierarchicalPayanarTypeTreeView
            // 
            this.hierarchicalPayanarTypeTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hierarchicalPayanarTypeTreeView.Location = new System.Drawing.Point(0, 105);
            this.hierarchicalPayanarTypeTreeView.Name = "hierarchicalPayanarTypeTreeView";
            this.hierarchicalPayanarTypeTreeView.Size = new System.Drawing.Size(756, 1219);
            this.hierarchicalPayanarTypeTreeView.TabIndex = 4;
            this.hierarchicalPayanarTypeTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.hierarchicalPayanarTypeTreeView_NodeMouseClick);
            this.hierarchicalPayanarTypeTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.hierarchicalPayanarTypeTreeView_NodeMouseDoubleClick);
            // 
            // toolbarPanel
            // 
            this.toolbarPanel.Controls.Add(this.addTblButton);
            this.toolbarPanel.Controls.Add(this.addButton);
            this.toolbarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarPanel.Location = new System.Drawing.Point(0, 0);
            this.toolbarPanel.Name = "toolbarPanel";
            this.toolbarPanel.Size = new System.Drawing.Size(756, 105);
            this.toolbarPanel.TabIndex = 3;
            // 
            // addTblButton
            // 
            this.addTblButton.Enabled = false;
            this.addTblButton.Location = new System.Drawing.Point(196, 26);
            this.addTblButton.Name = "addTblButton";
            this.addTblButton.Size = new System.Drawing.Size(90, 58);
            this.addTblButton.TabIndex = 1;
            this.addTblButton.Text = "+Tb";
            this.addTblButton.UseVisualStyleBackColor = true;
            this.addTblButton.Click += new System.EventHandler(this.addTblButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(124, 26);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(54, 58);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2894, 1574);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.payanarTableDesignBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.toolbarPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn uniqueIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private BindingSource payanarTableDesignBindingSource;
        private Panel panel1;
        private Panel toolbarPanel;
        private TreeView hierarchicalPayanarTypeTreeView;
        private Button addButton;
        private Button addTblButton;
    }
}