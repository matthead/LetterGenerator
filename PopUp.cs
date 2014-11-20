using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace allstate
{
    public partial class PopUp : Form
    {
        public PopUp()
        {
            InitializeComponent();
        }

        private void addPolicy_Click(object sender, EventArgs e)//trigger from addpolicy button
        {
            this.DialogResult = DialogResult.OK;
            newPolicy = addPolicyBox.Text;
        }
        public string GetNewPolicy()
        {
            return newPolicy;
        }
        private string newPolicy;
    }
}
