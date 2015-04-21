using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DBCF.Builder.WinForms
{
    public partial class ItemSettingsComponent : UserControl
    {
        public string SelectedFile { get; set; }
        public string StructureIdentifier { get; set; }
        public string SelectedCompression { get; private set; }
        
        public ItemSettingsComponent()
        {
            InitializeComponent();
        }

        private void ItemSettingsComponent_Load(object sender, System.EventArgs e)
        {
            txtFileIdentifier.Text = SelectedFile.Split(new[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries).Last();
            txtStructureIdentifier.Text = StructureIdentifier;

            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SelectedCompression = comboBox1.Items[comboBox1.SelectedIndex].ToString();
        }

    }
}
