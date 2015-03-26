namespace iTunes.Duplicate.Gui
{
    partial class iTunesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(iTunesForm));
            this.sourceFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgTracks = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddToLibrary = new System.Windows.Forms.Button();
            this.btnCheckDuplicates = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnRemoveDuplicates = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripTotalTracks1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDuplicates1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseDest = new System.Windows.Forms.Button();
            this.txtDestinationDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtSourceDirectory = new System.Windows.Forms.TextBox();
            this.destinationFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTracks)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(973, 701);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgTracks);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(973, 628);
            this.panel2.TabIndex = 1;
            // 
            // dgTracks
            // 
            this.dgTracks.AllowUserToAddRows = false;
            this.dgTracks.AllowUserToDeleteRows = false;
            this.dgTracks.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.dgTracks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgTracks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgTracks.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgTracks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgTracks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTracks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTracks.Location = new System.Drawing.Point(0, 0);
            this.dgTracks.MultiSelect = false;
            this.dgTracks.Name = "dgTracks";
            this.dgTracks.RowHeadersVisible = false;
            this.dgTracks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTracks.Size = new System.Drawing.Size(973, 561);
            this.dgTracks.TabIndex = 2;
            //this.dgTracks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgTracks_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.statusStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 561);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(973, 67);
            this.panel3.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddToLibrary);
            this.groupBox2.Controls.Add(this.btnCheckDuplicates);
            this.groupBox2.Controls.Add(this.btnCopy);
            this.groupBox2.Controls.Add(this.btnRemoveDuplicates);
            this.groupBox2.Controls.Add(this.btnLoad);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(973, 45);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // btnAddToLibrary
            // 
            this.btnAddToLibrary.Image = global::iTunes.Duplicate.Gui.Properties.Resources.iTunes10;
            this.btnAddToLibrary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddToLibrary.Location = new System.Drawing.Point(576, 16);
            this.btnAddToLibrary.Name = "btnAddToLibrary";
            this.btnAddToLibrary.Size = new System.Drawing.Size(117, 23);
            this.btnAddToLibrary.TabIndex = 10;
            this.btnAddToLibrary.Text = "5: Add";
            this.btnAddToLibrary.UseVisualStyleBackColor = true;
            this.btnAddToLibrary.Click += new System.EventHandler(this.btnAddToLibrary_Click);
            // 
            // btnCheckDuplicates
            // 
            this.btnCheckDuplicates.Image = global::iTunes.Duplicate.Gui.Properties.Resources.Search;
            this.btnCheckDuplicates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckDuplicates.Location = new System.Drawing.Point(150, 16);
            this.btnCheckDuplicates.Name = "btnCheckDuplicates";
            this.btnCheckDuplicates.Size = new System.Drawing.Size(117, 23);
            this.btnCheckDuplicates.TabIndex = 9;
            this.btnCheckDuplicates.Text = "2: Check Dupes";
            this.btnCheckDuplicates.UseVisualStyleBackColor = true;
            this.btnCheckDuplicates.Click += new System.EventHandler(this.btnCheckDuplicates_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Image = global::iTunes.Duplicate.Gui.Properties.Resources.copy;
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(434, 16);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(117, 23);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "4: Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnRemoveDuplicates
            // 
            this.btnRemoveDuplicates.Image = global::iTunes.Duplicate.Gui.Properties.Resources.Remove;
            this.btnRemoveDuplicates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveDuplicates.Location = new System.Drawing.Point(292, 16);
            this.btnRemoveDuplicates.Name = "btnRemoveDuplicates";
            this.btnRemoveDuplicates.Size = new System.Drawing.Size(117, 23);
            this.btnRemoveDuplicates.TabIndex = 7;
            this.btnRemoveDuplicates.Text = "3: Remove Dupes";
            this.btnRemoveDuplicates.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveDuplicates.UseVisualStyleBackColor = true;
            this.btnRemoveDuplicates.Click += new System.EventHandler(this.btnRemoveDuplicates_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoad.Location = new System.Drawing.Point(8, 16);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(117, 23);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "1: Load Folder";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel2,
            this.toolStripTotalTracks1,
            this.toolStripStatusLabel5,
            this.toolStripDuplicates1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 45);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(973, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(77, 17);
            this.toolStripStatusLabel2.Text = "Total Tracks: ";
            // 
            // toolStripTotalTracks1
            // 
            this.toolStripTotalTracks1.Name = "toolStripTotalTracks1";
            this.toolStripTotalTracks1.Size = new System.Drawing.Size(13, 17);
            this.toolStripTotalTracks1.Text = "0";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel5.Text = "Duplicates: ";
            // 
            // toolStripDuplicates1
            // 
            this.toolStripDuplicates1.Name = "toolStripDuplicates1";
            this.toolStripDuplicates1.Size = new System.Drawing.Size(13, 17);
            this.toolStripDuplicates1.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnBrowseDest);
            this.groupBox1.Controls.Add(this.txtDestinationDir);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.txtSourceDirectory);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(973, 73);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Destination Directory";
            // 
            // btnBrowseDest
            // 
            this.btnBrowseDest.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBrowseDest.Image = global::iTunes.Duplicate.Gui.Properties.Resources.Folder_icon;
            this.btnBrowseDest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowseDest.Location = new System.Drawing.Point(886, 40);
            this.btnBrowseDest.Name = "btnBrowseDest";
            this.btnBrowseDest.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDest.TabIndex = 6;
            this.btnBrowseDest.Text = "Browse";
            this.btnBrowseDest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowseDest.UseVisualStyleBackColor = true;
            this.btnBrowseDest.Click += new System.EventHandler(this.btnBrowseDest_Click);
            // 
            // txtDestinationDir
            // 
            this.txtDestinationDir.Location = new System.Drawing.Point(116, 40);
            this.txtDestinationDir.Name = "txtDestinationDir";
            this.txtDestinationDir.Size = new System.Drawing.Size(764, 20);
            this.txtDestinationDir.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source Directory";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBrowse.Image = global::iTunes.Duplicate.Gui.Properties.Resources.Folder_icon;
            this.btnBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowse.Location = new System.Drawing.Point(886, 14);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click_1);
            // 
            // txtSourceDirectory
            // 
            this.txtSourceDirectory.Location = new System.Drawing.Point(116, 14);
            this.txtSourceDirectory.Name = "txtSourceDirectory";
            this.txtSourceDirectory.Size = new System.Drawing.Size(764, 20);
            this.txtSourceDirectory.TabIndex = 2;
            // 
            // iTunesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 701);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(989, 739);
            this.Name = "iTunesForm";
            this.Text = "iTunes Duplicate Checker";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTracks)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog sourceFolderDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtSourceDirectory;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseDest;
        private System.Windows.Forms.TextBox txtDestinationDir;
        private System.Windows.Forms.FolderBrowserDialog destinationFolderDialog;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgTracks;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddToLibrary;
        private System.Windows.Forms.Button btnCheckDuplicates;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnRemoveDuplicates;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripTotalTracks1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripDuplicates1;
    }
}

