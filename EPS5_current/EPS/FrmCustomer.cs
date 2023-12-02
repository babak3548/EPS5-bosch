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
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }


        private void btnSave_Click_1(object sender, EventArgs e)
        {
            Form1.customer.Name = txtName.Text;
            Form1.customer.CustomerNo = txtCustomerNo.Text;
            Form1.customer.Tel = txtTel.Text;
            Form1.customer.Fax = txtFax.Text;
            Form1.customer.Email = txtEmail.Text;
            MessageBox.Show("save current customer name.");
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            txtName.Text = Form1.customer.Name;
            txtCustomerNo.Text = Form1.customer.CustomerNo;
            txtTel.Text = Form1.customer.Tel;
            txtFax.Text = Form1.customer.Fax;
            txtEmail.Text = Form1.customer.Email;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
