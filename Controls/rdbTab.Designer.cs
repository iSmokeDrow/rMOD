namespace rMOD.Controls
{
    partial class rdbTab
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
            this.loadStructBtn = new System.Windows.Forms.Button();
            this.searchDataBtn = new System.Windows.Forms.Button();
            this.searchColumns = new System.Windows.Forms.ComboBox();
            this.searchValue = new System.Windows.Forms.TextBox();
            this.encodingsList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.structureList = new System.Windows.Forms.ComboBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // loadStructBtn
            // 
            this.loadStructBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadStructBtn.Location = new System.Drawing.Point(700, 3);
            this.loadStructBtn.Name = "loadStructBtn";
            this.loadStructBtn.Size = new System.Drawing.Size(75, 23);
            this.loadStructBtn.TabIndex = 24;
            this.loadStructBtn.Text = "Load";
            this.loadStructBtn.UseVisualStyleBackColor = true;
            // 
            // searchDataBtn
            // 
            this.searchDataBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchDataBtn.Location = new System.Drawing.Point(700, 32);
            this.searchDataBtn.Name = "searchDataBtn";
            this.searchDataBtn.Size = new System.Drawing.Size(75, 23);
            this.searchDataBtn.TabIndex = 23;
            this.searchDataBtn.Text = "Search";
            this.searchDataBtn.UseVisualStyleBackColor = true;
            // 
            // searchColumns
            // 
            this.searchColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchColumns.FormattingEnabled = true;
            this.searchColumns.Location = new System.Drawing.Point(473, 34);
            this.searchColumns.Name = "searchColumns";
            this.searchColumns.Size = new System.Drawing.Size(221, 21);
            this.searchColumns.TabIndex = 22;
            // 
            // searchValue
            // 
            this.searchValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchValue.Location = new System.Drawing.Point(192, 34);
            this.searchValue.MinimumSize = new System.Drawing.Size(100, 21);
            this.searchValue.Name = "searchValue";
            this.searchValue.Size = new System.Drawing.Size(275, 20);
            this.searchValue.TabIndex = 21;
            this.searchValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // encodingsList
            // 
            this.encodingsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.encodingsList.FormattingEnabled = true;
            this.encodingsList.Location = new System.Drawing.Point(65, 34);
            this.encodingsList.Name = "encodingsList";
            this.encodingsList.Size = new System.Drawing.Size(121, 21);
            this.encodingsList.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Encoding:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(411, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Choose Structure:";
            // 
            // DataGrid
            // 
            this.DataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Location = new System.Drawing.Point(4, 61);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataGrid.Size = new System.Drawing.Size(771, 346);
            this.DataGrid.TabIndex = 17;
            this.DataGrid.VirtualMode = true;
            // 
            // structureList
            // 
            this.structureList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.structureList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.structureList.FormattingEnabled = true;
            this.structureList.Location = new System.Drawing.Point(509, 5);
            this.structureList.Name = "structureList";
            this.structureList.Size = new System.Drawing.Size(185, 21);
            this.structureList.TabIndex = 16;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(4, 426);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(771, 23);
            this.progressBar.TabIndex = 15;
            // 
            // TabControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loadStructBtn);
            this.Controls.Add(this.searchDataBtn);
            this.Controls.Add(this.searchColumns);
            this.Controls.Add(this.searchValue);
            this.Controls.Add(this.encodingsList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.structureList);
            this.Controls.Add(this.progressBar);
            this.Name = "TabControls";
            this.Size = new System.Drawing.Size(780, 454);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadStructBtn;
        private System.Windows.Forms.Button searchDataBtn;
        private System.Windows.Forms.ComboBox searchColumns;
        private System.Windows.Forms.TextBox searchValue;
        private System.Windows.Forms.ComboBox encodingsList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.ComboBox structureList;
        internal System.Windows.Forms.ProgressBar progressBar;
    }
}
