using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iTunes.Duplicate.Gui
{
    public partial class iTunesForm : Form
    {
        private StringCollection collectionTitleFilters;
        private iTunes iTunesApp;
        static BackgroundWorker bwCheckLibrary = new BackgroundWorker();
        static BackgroundWorker bwMoveFolder = new BackgroundWorker();
        static BackgroundWorker bwAddFolder = new BackgroundWorker();
        private FormState.FormStateID state;

        public iTunesForm()
        {
            InitializeComponent();

            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Text = "iTunes Duplicate Checker (" + version + ")";

            txtSourceDirectory.Text = Properties.Settings.Default.SourceDirectory;
            txtDestinationDir.Text = Properties.Settings.Default.DestinationDirectory;
            collectionTitleFilters = Properties.Settings.Default.TitleFilters;
            
            bwCheckLibrary.DoWork += bwCheckLibrary_DoWork;
            bwCheckLibrary.RunWorkerCompleted += bwCheckLibrary_RunWorkerCompleted;

            bwMoveFolder.DoWork += bwMoveFolder_DoWork;
            bwMoveFolder.RunWorkerCompleted += bwMoveFolder_RunWorkerCompleted;

            bwAddFolder.DoWork += bwAddFolder_DoWork;
            bwAddFolder.RunWorkerCompleted += bwAddFolder_RunWorkerCompleted;

            state = FormState.FormStateID.ReadyToProcess;
            ControlState();
            dgTracks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DisableButtons()
        {
            btnBrowse.Enabled = false;
            btnBrowseDest.Enabled = false;
            btnLoad.Enabled = false;
            btnCheckDuplicates.Enabled = false;
            btnRemoveDuplicates.Enabled = false;
            btnCopy.Enabled = false;
            btnAddToLibrary.Enabled = false;

            txtDestinationDir.ReadOnly = true;
            txtSourceDirectory.ReadOnly = true;

        }

        private void ControlState()
        {
            if (state == FormState.FormStateID.ReadyToProcess)
            {
                btnBrowse.Enabled = true;
                btnBrowseDest.Enabled = true;
                txtDestinationDir.ReadOnly = false;
                txtSourceDirectory.ReadOnly = false;

                btnLoad.Enabled = true;
                btnCheckDuplicates.Enabled = false;
                btnRemoveDuplicates.Enabled = false;
                btnCopy.Enabled = false;
                btnAddToLibrary.Enabled = false;

                toolStripTotalTracks1.Text = "0";
                toolStripDuplicates1.Text = "0";

                toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
                toolStripProgressBar1.Value = 0;
            }

            if (state == FormState.FormStateID.CheckDuplicates)
            {
                btnLoad.Enabled = false;
                btnCheckDuplicates.Enabled = true;
                btnRemoveDuplicates.Enabled = false;
                btnCopy.Enabled = false;
                btnAddToLibrary.Enabled = false;

                dgTracks.Columns["Path"].Visible = false;
                toolStripTotalTracks1.Text = dgTracks.Rows.Count.ToString();
            }

            if (state == FormState.FormStateID.RemoveDuplicates)
            {
                btnLoad.Enabled = false;
                btnCheckDuplicates.Enabled = false;
                btnRemoveDuplicates.Enabled = true;
                btnCopy.Enabled = false;
                btnAddToLibrary.Enabled = false;

                toolStripDuplicates1.Text = GetDuplicateCount();

                toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
                toolStripProgressBar1.Value = 0;

                dgTracks.DataSource = null;
                dgTracks.DataSource = iTunesApp.Tracks;
                dgTracks.Columns[0].Width = 40;
                dgTracks.Columns[3].Width = 40;
                dgTracks.Columns["Path"].Visible = false;
                dgTracks.Columns["Duplicate"].ReadOnly = false;
            }

            if (state == FormState.FormStateID.CopyDirectory)
            {
                btnLoad.Enabled = false;
                btnCheckDuplicates.Enabled = false;
                btnRemoveDuplicates.Enabled = false;
                btnCopy.Enabled = true;
                btnAddToLibrary.Enabled = false;

                dgTracks.DataSource = iTunesApp.Tracks;
                dgTracks.Columns[0].Width = 40;
                dgTracks.Columns[3].Width = 40;

                dgTracks.Columns["Path"].Visible = false;
                dgTracks.Columns["Duplicate"].ReadOnly = true;
            }

            if (state == FormState.FormStateID.ReadyToAddFiles)
            {
                btnLoad.Enabled = false;
                btnCheckDuplicates.Enabled = false;
                btnRemoveDuplicates.Enabled = false;
                btnCopy.Enabled = false;
                btnAddToLibrary.Enabled = true;

                toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
                toolStripProgressBar1.Value = 0;
            }

            if (state == FormState.FormStateID.WorkCompleted)
            {
                dgTracks.DataSource = null;

                state = FormState.FormStateID.ReadyToProcess;
                ControlState();
            }
        }

        private void bwCheckLibrary_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error == null)
                {
                    state = FormState.FormStateID.RemoveDuplicates;
                    ControlState();
                }
                else
                {
                    toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
                    toolStripProgressBar1.Value = 0;
                    Exception ex = new Exception(e.Error.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void bwCheckLibrary_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                iTunesApp.CheckLibraryForDuplicates();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bwMoveFolder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error == null)
                {
                    state = FormState.FormStateID.ReadyToAddFiles;
                    ControlState();
                }
                else
                {
                    toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
                    toolStripProgressBar1.Value = 0;
                    Exception ex = new Exception(e.Error.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void bwMoveFolder_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                iTunesApp.MoveToDestination(txtDestinationDir.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bwAddFolder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error == null)
                {
                    state = FormState.FormStateID.WorkCompleted;
                    ControlState();
                }
                else
                {
                    toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
                    toolStripProgressBar1.Value = 0;
                    Exception ex = new Exception(e.Error.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void bwAddFolder_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                iTunesApp.AddFolderToLibrary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       


        private void LoadSourceDirectory()
        {
            try
            {
                iTunesApp = new iTunes(txtSourceDirectory.Text, txtDestinationDir.Text, collectionTitleFilters);
                dgTracks.DataSource = iTunesApp.Tracks;
                dgTracks.Columns[0].Width = 40;
                dgTracks.Columns[3].Width = 40;
                dgTracks.Columns["Duplicate"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetDuplicateCount()
        {
            int index = 0;
            foreach (DataGridViewRow row in dgTracks.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                    index++;
            }
            return index.ToString();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                LoadSourceDirectory();
                state = FormState.FormStateID.CheckDuplicates;
                DisableButtons();
                ControlState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveDuplicates_Click(object sender, EventArgs e)
        {
            try
            {
                iTunesApp.DeleteDuplicates();
                LoadSourceDirectory();
                state = FormState.FormStateID.CopyDirectory;
                ControlState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckDuplicates_Click(object sender, EventArgs e)
        {
            try
            {
                DisableButtons();
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                bwCheckLibrary.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                DisableButtons();
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                bwMoveFolder.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddToLibrary_Click(object sender, EventArgs e)
        {
            try
            {
                DisableButtons();
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                bwAddFolder.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnBrowseDest_Click(object sender, EventArgs e)
        {
            destinationFolderDialog.ShowNewFolderButton = false;
            DialogResult result = destinationFolderDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
                txtDestinationDir.Text = destinationFolderDialog.SelectedPath;
        }

        private void btnBrowse_Click_1(object sender, EventArgs e)
        {
            sourceFolderDialog.ShowNewFolderButton = false;
            DialogResult result = sourceFolderDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
                txtSourceDirectory.Text = sourceFolderDialog.SelectedPath;
        }

        //private void dgTracks_Click(object sender, EventArgs e)
        //{

        //    if(((DataGridView)sender).CurrentCell.ColumnIndex == 0 && )
        //    {
        //        string test = null;
                            
        //    }
        //}
    }

    class FormState
    {
        public enum FormStateID
        {
            ReadyToProcess,
            LoadFolder,
            CheckDuplicates,
            RemoveDuplicates,
            CopyDirectory,
            ReadyToAddFiles,
            WorkCompleted,
            Error
        }
    }
}
