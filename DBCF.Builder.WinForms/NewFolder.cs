using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBCF.Builder.WinForms
{
    public partial class NewFolder : Form
    {
        public string FolderName { get; private set; }
        public NewFolder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderName = textBox1.Text;
            Close();
        }
    }
}
