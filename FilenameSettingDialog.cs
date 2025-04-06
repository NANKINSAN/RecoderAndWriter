using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecoderAndWriter
{
    public partial class FilenameSettingDialog : Form
    {
        public String Filename;
        public FilenameSettingDialog()
        {
            InitializeComponent();
            this.txtFilename.Text = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".wav";
            this.Filename = this.txtFilename.Text;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            this.Filename = this.txtFilename.Text;
            this.Close();
        }
    }
}
