using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using rMOD.Structures;

namespace rMOD.Controls
{
    public partial class TabControls : UserControl
    {
        public string FilePath { get; set; }
        public string FileName { get { return System.IO.Path.GetFileName(FilePath); } }

        public TabControls()
        {
            InitializeComponent();
        }

        public void SetStructureListChangedEvent(EventHandler handler) { structureList.SelectedIndexChanged += handler; }
        public void SetStructureListBtnClickEvent(EventHandler handler) { structureList.Click += handler; }
        public void SetGridCellValueNeededEvent(DataGridViewCellValueEventHandler handler) { DataGrid.CellValueNeeded += handler; }
        public void SetEncodingListChangedEvent(EventHandler handler) { encodingsList.SelectedIndexChanged += handler; }
        public void SetSearchDataBtnClickEvent(EventHandler handler) { searchDataBtn.Click += handler; }

        public void SetProgressMaximum(int max) { progressBar.Maximum = max; }
        public void SetProgressValue(int val) { progressBar.Value = val; }
        public void SetStructuresNames(string[] names) { structureList.Items.AddRange(names); }
        public void SetStructBtnText(string text) { loadStructBtn.Text = text; }
        public void SetGridRowcount(int count) { DataGrid.RowCount = count; }
        public void SetEncodings(string[] encodings) { encodingsList.DataSource = encodings; }
        public void SetSearchColumns(List<string> columns) { searchColumns.DataSource = columns; }
        public bool StructureListEnabled { get { return structureList.Enabled; } set { structureList.Enabled = value; }  }
        public bool StructureLoadButtonEnabled { get { return loadStructBtn.Enabled; } set { loadStructBtn.Enabled = value; } }

        public void Reset()
        {
            encodingsList.SelectedIndex = 0;
            searchColumns.SelectedIndex = -1;
            searchValue.ResetText();
            DataGrid.Rows.Clear();
        }

        public void ResetColumns() { DataGrid.Columns.Clear(); }

        public void AddGridColumns(DataGridViewColumn[] columns) { DataGrid.Columns.AddRange(columns); }
        public void AddGridRows(DataGridViewRow[] rows) { DataGrid.Rows.AddRange(rows); }

        public void AutoResizeGridColumns() { DataGrid.AutoResizeColumns(); }

        public int StructureListIndex { get { return structureList.SelectedIndex; } }
        public string StructureListValue { get { return structureList.Text; } }
        public Encoding EncodingValue { get { return Encodings.GetByName(encodingsList.Text); } }
        public int EncodingIndex { get { return encodingsList.SelectedIndex; } }
        public int GridRows { get { return DataGrid.Rows.Count; } }
        public bool ColumnsSet { get { return DataGrid.Columns.Count > 0; } }
        public string SearchColumn { get { return searchColumns.Text; } }
        public string SearchValue { get { return searchValue.Text; } }

        public DataGridView Grid { get { return DataGrid; } }
    }
}
