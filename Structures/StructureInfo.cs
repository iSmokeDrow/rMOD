using System.ComponentModel;

namespace rMOD.Structures
{
    public class StructureInfo : INotifyPropertyChanged
    {
        private string tableName;
        private string fileName;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        public string Key { get { return System.IO.Path.GetFileNameWithoutExtension(Path); } }
        public string Path { get; set; }    
        public string TableName { get { return tableName; } set { tableName = value; NotifyPropertyChanged(nameof(TableName)); } }
        public string FileName { get { return fileName; } set { fileName = value; NotifyPropertyChanged(nameof(FileName)); } }       
    }
}
