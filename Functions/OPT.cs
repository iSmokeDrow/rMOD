using System;
using System.Collections.Generic;
using System.IO;

namespace rMOD.Functions
{
    public class OPT
    {
        protected static Dictionary<string, string> SettingsList = new Dictionary<string, string>();

        public static bool SettingExists(string key) { return (SettingsList[key] != null) ? true : false; }

        public static bool StringIsNull(string key) { return string.IsNullOrEmpty(Convert.ToString((SettingsList[key]))); }

        public static string GetString(string key) { return (SettingExists(key)) ? SettingsList[key] : null; }

        public static bool GetBool(string key) { return (SettingExists(key)) ? Convert.ToBoolean(Convert.ToInt32(SettingsList[key])) : false; }

        public static int GetInt(string key) { return (SettingExists(key)) ? Convert.ToInt32(SettingsList[key]) : 0; }

        public static double GetDouble(string key) { return (SettingExists(key)) ? Convert.ToDouble(SettingsList[key]) : 0.0; }

        public static bool UpdateSetting(string key, string value)
        {
            if (SettingsList[key] != null) { SettingsList[key] = value; return true; }

            return false;
        }

        public static void Load()
        {
            if (File.Exists("rMOD.opt"))
            {
                using (StreamReader sR = new StreamReader("rMOD.opt"))
                {
                    string currentLineValue = null;
                    while ((currentLineValue = sR.ReadLine()) != null)
                    {
                        if (!currentLineValue.StartsWith("#"))
                        {
                            //Break the line 
                            string[] lineBlocks = currentLineValue.Split(new char[] { ':' }, 2);
                            string settingName = lineBlocks[0];
                            string settingValue = lineBlocks[1];
                            SettingsList.Add(settingName, settingValue);
                        }
                    }

                    Console.WriteLine("[OK]");
                }
            }
            else { Console.WriteLine("[Fail]\n\t-The rMOD.opt does not exist, create it!"); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public static void Save()
        {
            if (File.Exists("rMOD.opt")) { File.Delete("rMOD.opt"); }

            using (StreamWriter sW = new StreamWriter(File.Create("rMOD.opt")))
            {
                foreach (KeyValuePair<string, string> pair in SettingsList) { sW.Write(string.Format("{0}:{1}\n", pair.Key, pair.Value)); }
            }
        }
    }
}
