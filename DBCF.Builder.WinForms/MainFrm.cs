using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DynaStudios.DPCFLib.Format;

namespace DBCF.Builder.WinForms
{
    public partial class MainFrm : Form
    {
        private readonly Dictionary<string, ItemSettingsComponent> _items;
        private ItemSettingsComponent _selectedItemSettings;

        public MainFrm()
        {
            InitializeComponent();

            _items = new Dictionary<string, ItemSettingsComponent>();
        }
        private void TreeViewSelectionChanged(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Index == 0) return;
            if (!e.Node.Name.StartsWith("|F|"))
            {
                SelectItem(e.Node.Name);            
            }
        }

        private void btnCtxAddItem_Click(object sender, EventArgs e)
        {
            //Check if Selected Node is a Directory or the Root Directory
            var ofd = new OpenFileDialog
            {
                CheckFileExists = true,
                Multiselect = false
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var selectedFile = ofd.FileName;
                var selectedItemSettings = new ItemSettingsComponent
                {
                    SelectedFile = selectedFile,
                    StructureIdentifier = TraverseStructure()
                };

                _items.Add(selectedFile, selectedItemSettings);
                treeView1.SelectedNode.Nodes.Add(selectedFile, selectedFile.Split(new[] {Path.DirectorySeparatorChar}, StringSplitOptions.RemoveEmptyEntries).Last());
                treeView1.SelectedNode.Expand();
                SelectItem(selectedFile);
            }
        }

        private string TraverseStructure()
        {
            var fullPath = treeView1.SelectedNode.FullPath;
            var substring = fullPath.Substring(7);
            if (substring.Length > 1)
            {
                substring = substring.Substring(1).Replace(@"\", @"/");
            }
            return substring;
        }

        private void SelectItem(string selectedFile)
        {
            var panel = splitContainer1.Panel2;
            panel.Controls.Clear();
            _selectedItemSettings = _items[selectedFile];
            _selectedItemSettings.Dock = DockStyle.Fill;
            panel.Controls.Add(_selectedItemSettings);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ctxBtnAddFolder_Click(object sender, EventArgs e)
        {
            var newFolder = new NewFolder();
            if (newFolder.ShowDialog(this) == DialogResult.Cancel)
            {
                treeView1.SelectedNode.Nodes.Add("|F|" + newFolder.FolderName, newFolder.FolderName);
                treeView1.SelectedNode.Expand();
            }
        }

        private void createArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = 0;
            Dictionary<string, int> stringDictionary = new Dictionary<string, int>();

            ListNodes(treeView1.Nodes[0], ref index, ref stringDictionary);
        }

        private void ListNodes(TreeNode node, ref int index, ref Dictionary<string, int> stringDictionary)
        {
            foreach (TreeNode subnode in node.Nodes)
            {
                var name = subnode.Name;
                if (name.StartsWith("|F|"))
                {
                    var fullPath = subnode.FullPath;
                    var substring = fullPath.Substring(7);
                    if (substring.Length > 1)
                    {
                        substring = substring.Substring(1).Replace(@"\", @"/");
                    }
                    name = substring;
                }
                else
                {
                    name = subnode.Text;
                }

                if (!stringDictionary.ContainsKey(name))
                {
                    stringDictionary.Add(name, index);
                    index++;
                }
                ListNodes(subnode, ref index, ref stringDictionary);
            }
            // Print out node
        }

    }
}
