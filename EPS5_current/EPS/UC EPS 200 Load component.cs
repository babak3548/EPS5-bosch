using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnarSoft.Utility.Utilities;

namespace EPS
{
    public partial class UC_EPS_200_Load_component : UserControl
    {
        List<CriKomponenten> _criKomponentenList;
        // List<string> _lastList;
        public UC_EPS_200_Load_component(List<CriKomponenten> criKomponentenList)
        {
            InitializeComponent();
            _criKomponentenList = criKomponentenList;
            ReadLatestLiatFile();
        }

        private void ReadLatestLiatFile()
        {

            if (System.IO.File.Exists("LatestList.xml"))
            {
                string latestListString = System.IO.File.ReadAllText("LatestList.xml");
                Form1.LatestList = XmlSerializerUtility.DeSerialize<List<string>>(latestListString);
                //Form1.LatestList=new List<string> { "0445110008", "0445110011", "0445110012" };
                drdLatestList.DataSource = Form1.LatestList;
            }
            else
            {
                Form1.LatestList = new List<string>();
            }
        }

        private void UC_EPS_200_Load_component_Load(object sender, EventArgs e)
        {
            criKomponentenBindingSource.DataSource = _criKomponentenList;
        }

        private void txtTypeNumber_KeyUp(object sender, KeyEventArgs e)
        {
            criKomponentenBindingSource.DataSource = _criKomponentenList.Where(c => c.TypTeileNr.ToLower().Contains(txtTypeNumber.Text.Trim().ToLower()));
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            var criKomponenten = (criKomponentenBindingSource.Current as CriKomponenten);

            (this.Parent.Parent as Form1).manageUC(criKomponenten, (short)EnumsUC.UCCommonRailInjector);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Parent != null && this.Parent.Parent != null)
            {
                var z = drdLatestList.SelectedItem.ToString();
                var criKomponenten = _criKomponentenList.FirstOrDefault(x => x.TypTeileNr == z);
                //(criKomponentenBindingSource.Find( as CriKomponenten);
                (this.Parent.Parent as Form1).manageUC(criKomponenten, (short)EnumsUC.UCCommonRailInjector);
            }
        }

        private void LoadF3_Click(object sender, EventArgs e)
        {
            FrmCustomer _frmCustomer = new FrmCustomer();
            _frmCustomer.ShowDialog();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            frmSetting _frmSetting = new frmSetting();
            _frmSetting.ShowDialog();

        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            // var z = drdLatestList.SelectedItem.ToString();
            //var criKomponenten = _criKomponentenList.FirstOrDefault(x => x.TypTeileNr == z);
            //(criKomponentenBindingSource.Find( as CriKomponenten);
            (this.Parent.Parent as Form1).manageUC(null, (short)EnumsUC.UCCommonRailInjectorManual);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var stateResults = new List<ResultTest>();
            stateResults.Add(new ResultTest
            {
                TestName = "vl",
                StrResul = "",
                Pressure = "12",
                InjectedFuelQuantityActualValue = "11",
                ReturnQuantityActualValue = "14",
                InjectedFuelQuantitySetValue = "15",
                ReturnQuantitySetValue = "15",
                MeasurementTime = "17",
                ActuationTime = "18",
                boolResulRj = false,
                boolResulij = true
            });
            var x = new CreatePDF(stateResults);
        }


    }
}
