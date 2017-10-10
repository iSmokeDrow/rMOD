using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rMOD
{
    public partial class InputGUI : Form
    {
        public InputGUI()
        {
            InitializeComponent();
        }

        public InputGUI(string description, string guessedName)
        {
            InitializeComponent();
            this.Text = description;
            this.input.Text = guessedName;          
        }

        public string Input { get { return (input.Text.Length > 0) ? input.Text : null; } }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
