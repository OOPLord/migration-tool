using DataLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NClass.GUI.Dialogs
{
    public partial class UndoSQLDialog : Form
    {
        public UndoSQLDialog()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            string rootFolder = Deployment.DeterminePaths();
            string migrationsDirectory = rootFolder + Path.DirectorySeparatorChar + "Migrations";
            fileDialog.InitialDirectory = migrationsDirectory;

            var dialogResult = fileDialog.ShowDialog();

            if (dialogResult != DialogResult.OK)
            {
                return;
            }

            filePathTextBox.Text = fileDialog.FileName;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(filePathTextBox.Text))
            {
                return;
            }


        }
    }
}
