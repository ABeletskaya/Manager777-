using System;
using System.Windows.Forms;

namespace FileManager
{
    public partial class EnterName : Form
    {
        public string FileName { get; set; }        

        public EnterName()
        {
            InitializeComponent();
            btnOk.DialogResult = DialogResult.OK;
        }

        public EnterName(string oldName)
        {            
            InitializeComponent();
            tbFileName.Text = oldName;
            btnOk.DialogResult = DialogResult.OK;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {            
            FileName = tbFileName.Text;
        }
    }
}
