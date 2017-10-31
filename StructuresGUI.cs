using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using rMOD.Functions;
using rMOD.Structures;

namespace rMOD
{
    public partial class StructuresGUI : Form
    {
        BindingList<StructureInfo> structureBL;

        public StructuresGUI()
        {
            InitializeComponent();
        }

        public StructuresGUI(List<StructureInfo> structures)
        {
            InitializeComponent();
            structureBL = new BindingList<StructureInfo>(structures);
            structureBL.AllowNew = true;
            structureBL.AllowRemove = true;
            structureBL.AllowEdit = true;
            structureBL.ListChanged += (o, x) => { StructureManager.Save(); };
            structureGrid.DataSource = structureBL;
            formatGrid();
        }

        private void formatGrid()
        {
            structureGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            structureGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            structureGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            structureGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofDlg = new OpenFileDialog() { Title = "Please select your structure file", DefaultExt = "lua" })
            {
                ofDlg.ShowDialog(this);
                if (ofDlg.FileName.Length > 0)
                {
                    string name = Path.GetFileNameWithoutExtension(ofDlg.FileName);
                    StructureInfo newInfo = new StructureInfo() { Path = ofDlg.FileName, FileName = GuessName.Result(name, NameType.File), TableName = GuessName.Result(name, NameType.Table) };
                    structureBL.Add(newInfo);
                }
            }
        }

        // TODO: Changes to the structureBL need to trigger updates to the tab structureList
        private void remBtn_Click(object sender, EventArgs e)
        {
            string key = structureGrid.SelectedRows[0].Cells["key"].Value.ToString();
            if (key.Length > 0) { structureBL.Remove(structureBL.First(s => s.Key == key)); }          
        }
    }
}
