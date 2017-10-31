using System;
using System.ComponentModel;
using rMOD.Functions;

namespace rMOD.Structures
{
    public class DatabaseSettings
    {
        [Description("The IP at which your database can be connected to"), Category("Connection")]
        public string IP { get { return OPT.GetString("db.ip"); } set { OPT.UpdateSetting("db.ip", value.ToString()); } }

        [Description("The Port (if any) your database is behind"), Category("Connection"), DefaultValue(1433)]
        public int Port { get { return OPT.GetInt("db.port"); } set { OPT.UpdateSetting("db.port", value.ToString()); } }

        [Description("Determines if rMOD will use Windows Authentication to connect to the database, this does not require Username/Password."), Category("Connection"), DefaultValue(false)]
        public bool Trusted { get { return OPT.GetBool("db.trusted.connection"); } set { OPT.UpdateSetting("db.trusted.connection", Convert.ToInt32(value).ToString()); } }

        [Description("The database name of your Arcadia, e.g. ....Arcadia or 62World"), Category("Credentials"), DefaultValue("Arcadia"), DisplayName("Arcadia Name")]
        public string WorldName { get { return OPT.GetString("db.world.name"); } set { OPT.UpdateSetting("db.world.name", value.ToString()); } }

        [Description("The username used to connect to the world database"), Category("Credentials"), DefaultValue("sa"), DisplayName("Arcadia Username")]
        public string WorldUser { get { return OPT.GetString("db.world.username"); } set { OPT.UpdateSetting("db.world.username", value.ToString()); } }

        [Description("The password used to connect to the world database"), Category("Credentials"), DisplayName("Arcadia Password")]
        public string WorldPass { get { return OPT.GetString("db.world.password"); } set { OPT.UpdateSetting("db.world.password", value.ToString()); } }

        [Description("Determines if the target table of the save operation will be dropped and recreate or truncated before inserting the .rdb data"), Category("Saving"), DisplayName("Drop Table")]
        public bool DropTable { get { return OPT.GetBool("db.save.drop"); } set { OPT.UpdateSetting("db.save.drop", value.ToString()); } }

        [Description("Determines if the target table of the save operation will be backed up before inserting the .rdb data"), Category("Saving"), DisplayName("Backup Table")]
        public bool BackupTable { get { return OPT.GetBool("db.save.backup"); } set { OPT.UpdateSetting("db.save.backup", value.ToString()); } }
    }
}
