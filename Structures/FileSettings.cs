using System;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using System.ComponentModel;
using rMOD.Functions;

namespace rMOD.Structures
{
    public class FileSettings
    {
        [Description("Determines if the structure you select will be loaded the moment you select it or manually with \"Load\" button"), Category("Structures"), DisplayName("Load on Select")]
        public bool AutoLoad { get { return OPT.GetBool("structure.autoload"); } set { OPT.UpdateSetting("structure.autoload", Convert.ToInt32(value).ToString()); } }

        [Description("The directory your structure .lua files are located"), Category("Structures"), DisplayName("Structure Directory"), Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
        public string StructureDirectory { get { return OPT.GetString("structure.directory"); } set { OPT.UpdateSetting("structure.directory", value.ToString()); } }

        [Description("The directory to save newly created .RDB files to"), Category("File"), DisplayName("Save Directory"), Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
        public string SaveDirectory
        {
            get { return OPT.GetString("save.directory"); }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (System.Windows.Forms.MessageBox.Show("By defining a \"Save Directory\" rMOD will no longer allow you to define the file name of files being saved!\n\nDo you wish to continue?", "Input Required", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Hand) == System.Windows.Forms.DialogResult.Yes)
                    {
                        OPT.UpdateSetting("save.directory", value.ToString());
                    }                 
                }           
            }
        }

        [Description("Determines if (ascii) is appended to file names being loaded or saved"), Category("File"), DefaultValue(false), DisplayName("Use ASCII")]
        public bool UseASCII
        {
            get { return OPT.GetBool("use.ascii"); }
            set
            {
                GUI.Instance.UseASCII_btnState(value);
                OPT.UpdateSetting("use.ascii", Convert.ToInt32(value).ToString());
            }
        }

        [Description("Determines if newly created .RDB files will be saved in their hash name version"), Category("File"), DefaultValue(false), DisplayName("Save Hashed")]
        public bool SaveHashed { get { return OPT.GetBool("save.hashed"); } set { OPT.UpdateSetting("save.hashed", Convert.ToInt32(value).ToString()); } }
    }
}
