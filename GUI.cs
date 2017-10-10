using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using rMOD.Functions;
using rMOD.Structures;
using rMOD.Controls;
using rdbCore;
using rdbCore.Structures;
using MoonSharp.Interpreter;

namespace rMOD
{
    // TODO: Add possible error catching if a structure has an invalid type
    // TODO: Write centralized logging/display system for notices, errors etc..
    // TODO: Add support for pressing enter key on inputGUI
    public partial class GUI : Form
    {
        #region Properties

        public static GUI Instance;

        private List<Core> rdbCores = new List<Core>();

        private int tabIdx {
            get
            {
                int ret = 0;

                if (InvokeRequired) { this.Invoke(new MethodInvoker(delegate { ret = tabs.SelectedIndex; })); }
                else { ret = tabs.SelectedIndex; }

                return ret;
            }
        }

        private string tabName { get { return tabs.SelectedTab.Text; } }

        public TabControls TabControls { get { return (TabControls)tabs.TabPages[tabIdx].Controls[string.Format("tab_{0}_controls", tabIdx)]; } }
        internal TabControls getTabControls(string name)
        {
            int desiredIdx = tabs.TabPages.IndexOfKey(name);
            return (TabControls)tabs.TabPages[desiredIdx].Controls[string.Format("tab_{0}_controls", desiredIdx)];
        }

        public Core rCore { get { return (tabIdx > -1) ? rdbCores[tabIdx]: null; } }

        #endregion

        public GUI()
        {
            InitializeComponent();
            Instance = this;
        }

        #region Methods

        public void UpdateProgressMaximum(int max) { this.Invoke(new MethodInvoker(delegate { TabControls.SetProgressMaximum(max); })); }

        public void UpdateProgressValue(int val) { this.Invoke(new MethodInvoker(delegate { TabControls.SetProgressValue(val); })); }

        public void UpdateStatusText(string text) { this.Invoke(new MethodInvoker(delegate { status.Text = text; })); }

        public void CreateTab(string name, string text)
        {
            tabs.TabPages.Add(name, text);
            int curIdx = tabs.TabPages.IndexOfKey(name);

            // Generate controls
            tabs.TabPages[curIdx].Controls.Add(new TabControls() { Name = string.Format("tab_{0}_controls", curIdx), Dock = DockStyle.Fill });

            // Set events
            getTabControls(name).SetStructureListChangedEvent(structureList_SelectedIndexChanged);
            getTabControls(name).SetStructureListBtnClickEvent(loadStructBtn_Click);
            getTabControls(name).SetGridCellValueNeededEvent(Grid.Grid_CellValueNeeded);
            getTabControls(name).SetEncodingListChangedEvent(encoding_SelectedIndexChanged);          
            getTabControls(name).SetSearchDataBtnClickEvent(searchDataBtn_Click);

            // Set encodings for this tab
            getTabControls(name).SetEncodings(Encodings.Names);

            // Load structure names for this tab
            getTabControls(name).SetStructuresNames(StructureManager.GetNames());

            // Add IO engine instance for this tab
            rdbCores.Add(new Core(TabControls.EncodingValue));

            // Register events from this core
            rdbCores[curIdx].ProgressMaxChanged += GUI_ProgressMaxChanged;
            rdbCores[curIdx].ProgressValueChanged += GUI_ProgressValueChanged;
        }

        private void GUI_ProgressValueChanged(object sender, ProgressValueArgs e)
        {
            if (InvokeRequired) { this.Invoke(new MethodInvoker(delegate { TabControls.SetProgressValue(e.Value); })); }
            else { TabControls.SetProgressValue(e.Value); }
        }

        private void GUI_ProgressMaxChanged(object sender, ProgressMaxArgs e)
        {
            if (InvokeRequired) { this.Invoke(new MethodInvoker(delegate { TabControls.SetProgressMaximum(e.Maximum); })); }
            else { TabControls.SetProgressMaximum(e.Maximum); }           
        }

        public void SetTabText() { tabs.TabPages[tabIdx].Text = string.Format("<{0}>", TabControls.StructureListValue); }

        async void readRDB()
        {
            UpdateStatusText("Parsing RDB File...");
            changeTabsState(false);
            await Task.Run(() => { rCore.ParseRDB(TabControls.FilePath); });
            changeTabsState(true);
            tabs.TabPages[tabIdx].Text = TabControls.FileName;
            UpdateStatusText("Populating grid rows...");
            Grid.LoadData(TabControls.ColumnsSet);
            UpdateStatusText("");
            tabs.TabPages[tabIdx].ToolTipText = string.Format("File Name: {0}\nDate Created: {1}\nRows: {2}", StructureManager.FileName(TabControls.StructureListValue), generateDate(rCore.CreatedDate), rCore.RowCount);
            disableStructureList();
        }

        private async void loadStructure()
        {
            try
            {
                rCore.Initialize(StructureManager.Path(TabControls.StructureListValue));
                TabControls.SetSearchColumns(await Task<List<string>>.Factory.StartNew(() => getColumns()));
                tabs.TabPages[tabIdx].Text = string.Format("<{0}>", TabControls.StructureListValue);
                TabControls.SetStructBtnText("Loaded");
            }
            catch (SyntaxErrorException ex) { LuaException.Print(ex.DecoratedMessage, TabControls.StructureListValue); }
            catch (Exception ex) { MessageBox.Show(string.Format("An exception has occured!\n\nException Message:\n\n{0}", ex.Message), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private List<string> getColumns()
        {
            List<string> columns = new List<string>();
            foreach (LuaField field in rCore.FieldList) { columns.Add(field.Name); }
            return columns;
        }

        private void disableStructureList()
        {
            TabControls.StructureListEnabled = false;
            TabControls.StructureLoadButtonEnabled = false;
        }

        void changeTabsState(bool enabled) { tabs.Enabled = enabled; }

        public void UseASCII_btnState(bool enabled) { useASCIIBtn.Checked = enabled; }

        private string generateDate(string dateString)
        {
            return string.Format("{0} {1}, {2}", Enum.GetValues(typeof(Month)).GetValue(Convert.ToInt32(dateString.Substring(4, 2)) - 1), dateString.Substring(6, 2), dateString.Substring(0, 4));
        }

        #endregion

        #region Events

        private void GUI_Load(object sender, EventArgs e) { }

        private void GUI_Shown(object sender, EventArgs e)
        {
            OPT.Load();
            StructureManager.Load();
            CreateTab("tab_0", "<Unknown>");
            useASCIIBtn.Checked = OPT.GetBool("use.ascii");
        }

        private void settingsDatabase_Click(object sender, EventArgs e)
        {
            using (SettingsGUI settingsGUI = new SettingsGUI())
            {
                settingsGUI.Initialize(SettingType.Database);
                settingsGUI.ShowDialog(this);
            }
        }

        private void settingsFile_Click(object sender, EventArgs e)
        {
            using (SettingsGUI settingsGUI = new SettingsGUI())
            {
                settingsGUI.Initialize(SettingType.File);
                settingsGUI.ShowDialog(this);
            }
        }

        private void searchDataBtn_Click(object sender, EventArgs e)
        {           
            if (TabControls.GridRows > 0 && TabControls.SearchValue != null)
            {
                UpdateStatusText("Searching data...");

                foreach (DataGridViewRow row in TabControls.DataGrid.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (row.Cells[TabControls.SearchColumn].Value.ToString() == TabControls.SearchValue)
                        {
                            TabControls.DataGrid.CurrentCell = row.Cells[TabControls.SearchColumn];
                            row.Selected = true;
                        }
                    }                  
                }

                UpdateStatusText("");
            }
        }

        private void structureList_SelectedIndexChanged(object sender, EventArgs e) { if (TabControls.StructureListIndex != -1) { if (OPT.GetBool("structure.autoload")) { loadStructure(); } } }

        private void encoding_SelectedIndexChanged(object sender, EventArgs e) { if (TabControls.EncodingIndex > 0) { rdbCores[tabIdx].SetEncoding(TabControls.EncodingValue); } }

        private void loadStructBtn_Click(object sender, EventArgs e) { if (TabControls.StructureListIndex != -1) { loadStructure(); } }

        private void newTab_Click(object sender, EventArgs e)
        {
            int newIdx = tabs.TabPages.Count;
            CreateTab(string.Format("tab_{0}", newIdx), "<Unknown>");
        }

        private void closeTab_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Are you sure you want to close the {0} tab?", tabName), "Input Required", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tabs.TabPages.RemoveAt(tabIdx);
            }
        }

        private void resetTab_Click(object sender, EventArgs e)
        {
            TabControls.Reset();
            rCore.ClearData();
        }

        private void tabs_ControlRemoved(object sender, ControlEventArgs e) { rdbCores.RemoveAt(tabIdx); }

        private void readFileBtn_Click(object sender, EventArgs e)
        {
            if (TabControls.StructureListIndex != -1)
            {
                using (OpenFileDialog ofDlg = new OpenFileDialog() { Filter = "RDB files (*.rdb)|*.rdb|All files (*.*)|*.*", Title = "Select your rdb", FileName = StructureManager.FileName(TabControls.StructureListValue) })
                {
                    string filePath = null;
                    ofDlg.ShowDialog(this);
                    if (!string.IsNullOrEmpty(ofDlg.FileName)) { filePath = ofDlg.FileName; }
                    if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                    {
                        TabControls.FilePath = filePath; 
                        readRDB();
                    }
                }
            }
            else { MessageBox.Show("You haven't loaded a Structure LUA yet!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void loadSQLBtn_Click(object sender, EventArgs e)
        {
            if (TabControls.StructureListIndex != -1)
            {
                string tableName = null;
                using (InputGUI input = new InputGUI("Please enter the table name", StructureManager.TableName(TabControls.StructureListValue)))
                {
                    input.ShowDialog();
                    tableName = input.Input;
                }

                if (!string.IsNullOrEmpty(tableName))
                {
                    tabs.TabPages[tabIdx].Text = tableName;

                    int rowCount = Database.FetchRowCount(tableName);

                    changeTabsState(false);
                    rCore.SetData(Database.FetchTable(rowCount, tableName));
                    Grid.LoadData(TabControls.ColumnsSet);
                    tabs.TabPages[tabIdx].ToolTipText = string.Format("Table Name: {0}\nRows: {1}", tableName, rowCount);
                    disableStructureList();
                    changeTabsState(true);
                }
            }
            else { MessageBox.Show("You haven't loaded a Structure LUA yet!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private async void saveFileBtn_Click(object sender, EventArgs e)
        {
            DataCore.Core dCore = new DataCore.Core();

            if (TabControls.GridRows > 0)
            {
                string savePath = OPT.GetString("save.directory");
                if (string.IsNullOrEmpty(savePath))               
                {
                    string structFileName = string.Concat(StructureManager.FileName(TabControls.StructureListValue),".rdb");
                    string fileName = OPT.GetBool("save.hashed") ? dCore.EncodeName(structFileName) : structFileName;

                    using (SaveFileDialog sfDlg = new SaveFileDialog() { Filter = "RDB files (*.rdb)|*.rdb|All files (*.*)|*.*", Title = "Define the name of your rdb", FileName = fileName })
                    {
                        if (sfDlg.ShowDialog(this) == DialogResult.OK) { if (!string.IsNullOrEmpty(sfDlg.FileName)) { savePath = sfDlg.FileName; } }
                    }
                }
                else { savePath += GuessName.Result(TabControls.StructureListValue, NameType.File); }

                if (!string.IsNullOrEmpty(savePath)) { await Task.Run(() => { rdbCores[tabIdx].WriteRDB(savePath); }); }
            }
        }

        async void saveSQLBtn_Click(object sender, EventArgs e)
        {
            if (TabControls.GridRows > 0)
            {
                string tableName = null;
                using (InputGUI input = new InputGUI("Please enter the table name", StructureManager.TableName(TabControls.StructureListValue)))
                {
                    input.ShowDialog();
                    tableName = input.Input;
                }

                if (!string.IsNullOrEmpty(tableName))
                {
                    UpdateStatusText("Saving to database...");
                    await Task.Run(() => { Database.ExportToTable(rCore.Data, tableName); });
                    UpdateStatusText("");
                }
            }
        }

        private void manageStructuresBtn_Click(object sender, EventArgs e) { using (StructuresGUI structureGUI = new StructuresGUI(StructureManager.Structures)) { structureGUI.ShowDialog(this); } }

        private void reloadBtn_Click(object sender, EventArgs e) { StructureManager.Load(); }

        private void GUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C) { closeTab_Click(null, EventArgs.Empty); }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.D) { loadSQLBtn_Click(null, EventArgs.Empty); }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.N) { newTab_Click(null, EventArgs.Empty); }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.O) { readFileBtn_Click(null, EventArgs.Empty); }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.R) { resetTab_Click(null, EventArgs.Empty); }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S) { saveFileBtn_Click(null, EventArgs.Empty); }
        }

        private void about_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("rMOD v.5\n\nThis program is the first successful attempt at a C# .rdb Editor that uses an outside file (in this case .lua) to script information about the .rdb being manipulated.\n\nSupported Epics: 9.1 and lower (Sorry I have not at this time implemented methods of reading .ref/.rdu, perhaps in the future)\n\nDeveloper note: I want to give many thanks to Glandu2 who is a great inspiration to me and was a integral part of my creating the editing engine (rdbCore.dll) and was totally cool with me ripping off his gui for the most part :P\n\nTHANK YOU SO MUCH GLANDU2!"), "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void reloadData_Click(object sender, EventArgs e)
        {
            resetTab_Click(null, EventArgs.Empty);
            readRDB();
        }

        private void reload_Click(object sender, EventArgs e)
        {
            resetTab_Click(null, EventArgs.Empty);
            TabControls.ResetColumns();
            loadStructBtn_Click(null, EventArgs.Empty);
            readRDB();
        }

        private void tabs_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (tabs.GetTabRect(tabIdx).Contains(e.Location))
                {
                    bool enabled = tabName != "<Unknown>";
                    tabContextMenu.Items[0].Enabled = enabled;
                    tabContextMenu.Items[1].Enabled = enabled;
                    tabContextMenu.Show(this, e.Location);
                }
            }
        }

        private void currentToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if (tabs.TabCount > 0)
            {
                bool enabled = tabName != "<Unknown>";
                ToolStripDropDownItem menuTabs = (ToolStripDropDownItem)menu.Items[1];
                ToolStripDropDownItem menuTabs_children = (ToolStripDropDownItem)menuTabs.DropDownItems[1];
                ToolStripItemCollection menuTabs_children_items = menuTabs_children.DropDownItems;
                menuTabs_children_items[0].Enabled = enabled;
                menuTabs_children_items[1].Enabled = enabled;
            }          
        }

        private void useASCIIBtn_Click(object sender, EventArgs e)
        {
            useASCIIBtn.Checked = (useASCIIBtn.Checked) ? false : true;
            OPT.UpdateSetting("use.ascii", Convert.ToInt32(useASCIIBtn.Checked).ToString());
        }

        #endregion
    }
}