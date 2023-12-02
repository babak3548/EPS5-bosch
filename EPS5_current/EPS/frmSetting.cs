using AnarSoft.Utility.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPS
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            Form1.setting.Name = txtName.Text;
            Form1.setting.Tel = txtTel.Text;
            Form1.setting.Fax = txtFax.Text;
            Form1.setting.Email = txtEmail.Text;
            Form1.setting.Checker = txtChecker.Text;
            Form1.setting.Port = txtPort.Text;
            try
            {
                string strSetting = XmlSerializerUtility.Serialize(Form1.setting);
                System.IO.File.WriteAllText("Setting.xml", strSetting);
                MessageBox.Show("saved successfully");
            }
            catch (Exception ex)
            {
                
                throw;
            }

        

        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            txtName.Text = Form1.setting.Name;
            txtTel.Text = Form1.setting.Tel;
            txtFax.Text = Form1.setting.Fax;
            txtEmail.Text = Form1.setting.Email;
            txtChecker.Text = Form1.setting.Checker;
            txtPort.Text = Form1.setting.Port;
            if (!string.IsNullOrWhiteSpace(Form1.setting.Port)) txtPort.Enabled = false;
        }
    }
}
