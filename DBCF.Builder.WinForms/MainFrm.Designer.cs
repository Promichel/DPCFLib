namespace DBCF.Builder.WinForms
{
    partial class MainFrm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Content");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lblSolution = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoadSolution = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveSolution = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ctxSolutionContent = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCtxAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxBtnAddFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.dPCFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ctxSolutionContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSolution,
            this.dPCFToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(751, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lblSolution
            // 
            this.lblSolution.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSaveSolution,
            this.btnLoadSolution,
            this.toolStripSeparator1,
            this.btnClose});
            this.lblSolution.Name = "lblSolution";
            this.lblSolution.Size = new System.Drawing.Size(63, 20);
            this.lblSolution.Text = "Solution";
            // 
            // btnLoadSolution
            // 
            this.btnLoadSolution.Name = "btnLoadSolution";
            this.btnLoadSolution.Size = new System.Drawing.Size(159, 22);
            this.btnLoadSolution.Text = "LoadFromFile Solution ...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // btnClose
            // 
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(159, 22);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveSolution
            // 
            this.btnSaveSolution.Name = "btnSaveSolution";
            this.btnSaveSolution.Size = new System.Drawing.Size(159, 22);
            this.btnSaveSolution.Text = "Save Solution ...";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Size = new System.Drawing.Size(751, 373);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.ctxSolutionContent;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Knoten0";
            treeNode1.Text = "Content";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(250, 373);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewSelectionChanged);
            // 
            // ctxSolutionContent
            // 
            this.ctxSolutionContent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCtxAddItem,
            this.ctxBtnAddFolder,
            this.removeItemToolStripMenuItem});
            this.ctxSolutionContent.Name = "ctxSolutionContent";
            this.ctxSolutionContent.Size = new System.Drawing.Size(145, 70);
            // 
            // btnCtxAddItem
            // 
            this.btnCtxAddItem.Name = "btnCtxAddItem";
            this.btnCtxAddItem.Size = new System.Drawing.Size(152, 22);
            this.btnCtxAddItem.Text = "Add Item ...";
            this.btnCtxAddItem.Click += new System.EventHandler(this.btnCtxAddItem_Click);
            // 
            // removeItemToolStripMenuItem
            // 
            this.removeItemToolStripMenuItem.Name = "removeItemToolStripMenuItem";
            this.removeItemToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeItemToolStripMenuItem.Text = "Remove Item";
            // 
            // ctxBtnAddFolder
            // 
            this.ctxBtnAddFolder.Name = "ctxBtnAddFolder";
            this.ctxBtnAddFolder.Size = new System.Drawing.Size(152, 22);
            this.ctxBtnAddFolder.Text = "Add Folder ...";
            this.ctxBtnAddFolder.Click += new System.EventHandler(this.ctxBtnAddFolder_Click);
            // 
            // dPCFToolStripMenuItem
            // 
            this.dPCFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createArchiveToolStripMenuItem});
            this.dPCFToolStripMenuItem.Name = "dPCFToolStripMenuItem";
            this.dPCFToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.dPCFToolStripMenuItem.Text = "DPCF";
            // 
            // createArchiveToolStripMenuItem
            // 
            this.createArchiveToolStripMenuItem.Name = "createArchiveToolStripMenuItem";
            this.createArchiveToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.createArchiveToolStripMenuItem.Text = "Create Archive ...";
            this.createArchiveToolStripMenuItem.Click += new System.EventHandler(this.createArchiveToolStripMenuItem_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 397);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFrm";
            this.Text = "Dynamic Patchable Content File Builder";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ctxSolutionContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem lblSolution;
        private System.Windows.Forms.ToolStripMenuItem btnLoadSolution;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnClose;
        private System.Windows.Forms.ToolStripMenuItem btnSaveSolution;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip ctxSolutionContent;
        private System.Windows.Forms.ToolStripMenuItem btnCtxAddItem;
        private System.Windows.Forms.ToolStripMenuItem removeItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctxBtnAddFolder;
        private System.Windows.Forms.ToolStripMenuItem dPCFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createArchiveToolStripMenuItem;
    }
}

