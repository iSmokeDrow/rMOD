using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rMOD.Functions;
using rMOD.Structures;

namespace rMOD
{
    public partial class SettingsGUI : Form
    {
        bool save = false;

        object properties;

        public SettingsGUI()
        {
            InitializeComponent();           
        }

        public void Initialize(SettingType type)
        {
            switch (type)
            {
                case SettingType.Database:
                    properties = new DatabaseSettings();
                    break;

                case SettingType.File:
                    properties = new FileSettings();                  
                    break;
            }

            propertyGrid.SelectedObject = properties;
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) { save = true; }

        private void SettingsGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (save)
                OPT.Save();
        }
    }
}
