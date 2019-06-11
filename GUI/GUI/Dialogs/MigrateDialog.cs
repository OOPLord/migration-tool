using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NClass.GUI.Dialogs
{
    public partial class MigrateDialog : Form
    {
        public MigrateDialog()
        {
            InitializeComponent();
        }

        public string FileName { get; set; }

        private void Button1_Click(object sender, EventArgs e)
        {
            string name = this.textBox1.Text;

            if (!string.IsNullOrWhiteSpace(name))
            {
                this.FileName = this.textBox1.Text;
            }
            else
            {
                this.FileName = "auto";
            }

            this.DialogResult = DialogResult.OK;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
