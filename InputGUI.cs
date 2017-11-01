using System;
using System.Windows.Forms;
using rMOD.Structures;

namespace rMOD
{
    public partial class InputGUI : Form
    {
        public InputGUI(string description, string guessedName)
        {
            InitializeComponent();
            Text = description;
            input.Text = guessedName;
            DialogResult = DialogResult.Cancel;
        }

        public string Value { get { return (input.Text.Length > 0) ? input.Text : null; } }

        private void okBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Hide();
        }
    }
}
