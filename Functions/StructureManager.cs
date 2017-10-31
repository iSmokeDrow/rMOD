using System.Collections.Generic;
using System.IO;
using rMOD.Structures;

namespace rMOD.Functions
{
    public class StructureManager
    {
        static List<StructureInfo> structures = new List<StructureInfo>();

        public static List<StructureInfo> Structures { get { return structures; }  }

        static string infoPath = string.Format(@"{0}\{1}", Directory.GetCurrentDirectory(), "structures.info");

        static string structuresDir = (!OPT.StringIsNull("structure.directory")) ? OPT.GetString("structure.directory") : string.Format(@"{0}\Structures\", Directory.GetCurrentDirectory());

        static int dirCount { get { return Directory.GetFiles(structuresDir).Length; } }

        public static string Path(string key) { return structures.Find(s => s.Key == key).Path; }

        public static string FileName(string key)
        {
            string name = structures.Find(s=>s.Key == key).FileName;
            bool hmn = OPT.GetBool("use.ascii");
            return OPT.GetBool("use.ascii") ? name += "(ascii)" : name;
        }

        public static string TableName(string key) { return structures.Find(s => s.Key == key).TableName; }

        public static string[] GetNames()
        {
            string[] names = new string[structures.Count];

            for (int i = 0; i < structures.Count; i++) { names[i] = structures[i].Key; }

            return names;
        }

        public static void Load()
        {
            if (structures.Count > 0) { structures.Clear(); }

            if (!File.Exists(infoPath)) { create(); }
            if (!Directory.Exists(structuresDir) && OPT.StringIsNull("structure.directory")) { Directory.CreateDirectory(structuresDir); }

            read();
            compare();

            structures.Sort((x, y) => x.FileName.CompareTo(y.FileName));
        }

        static void create()
        {
            using (StreamWriter sw = new StreamWriter(File.Create(infoPath)) { AutoFlush = true })
            {               
                foreach (string filePath in Directory.GetFiles(structuresDir))
                {
                    string structName = System.IO.Path.GetFileNameWithoutExtension(filePath);
                    string infoString = string.Format(@"{0}|{1}|{2}|{3}|{4}", structName, filePath, GuessName.Result(structName, NameType.File), GuessName.Result(structName, NameType.Table), string.Empty);
                    sw.WriteLine(infoString);
                }
            }
        }

        // TODO: I'm stupid and don't actually compare files with those in the structures directory
        static void read()
        {
            // Read structures.info
            using (StreamReader sr = new StreamReader(infoPath))
            {
                string curLine = null;
                while ((curLine = sr.ReadLine()) != null)
                {
                    string[] lineBlocks = curLine.Split('|');
                    structures.Add(new StructureInfo()
                    {
                        Path = lineBlocks[1],
                        FileName = lineBlocks[2],
                        TableName = lineBlocks[3],
                    });
                }
            }
        }

        static void compare()
        {
            bool save = false;
            List<string> structFiles = new List<string>(Directory.GetFiles(structuresDir));
            foreach (string structPath in structFiles)
            {
                string fileName = System.IO.Path.GetFileName(structPath);
                string key = System.IO.Path.GetFileNameWithoutExtension(structPath);
                if (structures.FindIndex(s=>s.Key == key) == -1)
                {
                    save = true;
                    structures.Add(new StructureInfo()
                    {
                        Path = structPath,
                        FileName = GuessName.Result(key, NameType.File),
                        TableName = GuessName.Result(key, NameType.Table)
                    });
                }
            }

            if (save) { Save(); }
        }

        public static void Save()
        {
            using (StreamWriter sw = new StreamWriter(File.Open(infoPath, FileMode.Truncate, FileAccess.Write, FileShare.None)))
            {
                foreach (StructureInfo structure in structures)
                { 
                    string infoString = string.Format(@"{0}|{1}|{2}|{3}", structure.Key, structure.Path, structure.FileName, structure.TableName);
                    sw.WriteLine(infoString);
                }                
            }
        }
    }
}
