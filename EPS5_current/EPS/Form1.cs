using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnarSoft.Utility.Utilities;

namespace EPS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static List<CriKomponenten> ListCriKomponentens;//لیست سوزن ها
        List<CriPruefschritte> _listCriPruefschritte;//لیست اطلاعات تمام سوزن ها
        public static List<string> LatestList;
        public static Setting setting ;
        public static Customer customer;

      //  List<CriKomponenten> criKomponentenList;
                    // EPS200_SecureSQL1Entities : DbContext
          //  EPS200_SecureSQL1Entities dbC = new EPS200_SecureSQL1Entities();
          //  var x = dbC.CriPruefschritte.ToList();
          //  var z = new AnarSoft.Utility.Utilities.XmlSerializerUtility();

          //string strCriPruefschritte=  AnarSoft.Utility.Utilities.XmlSerializerUtility.Serialize(x);
          //var resDesial = AnarSoft.Utility.Utilities.XmlSerializerUtility.DeSerialize<List<CriPruefschritte>>(strCriPruefschritte);
            //criKomponentenList = dbC.CriKomponenten.ToList();
            //criKomponentenBindingSource.DataSource = criKomponentenList;
        private void CreateFile()
        {
            EPS200_SecureSQL1Entities dbC = new EPS200_SecureSQL1Entities();
           // _listCriKomponenten = dbC.CriKomponenten.ToList();
            string strCriKomponenten= XmlSerializerUtility.Serialize(dbC.CriKomponenten.ToList());
           string EncripStrCriKomponenten = StringCipher.Encrypt(strCriKomponenten, StringCipher.passPhrase);
           System.IO.File.WriteAllText("Kompo.xml", EncripStrCriKomponenten);

           string strCriPruefschritte = XmlSerializerUtility.Serialize(dbC.CriPruefschritte.ToList());
           string EncripStrCriPruefschritte = StringCipher.Encrypt(strCriPruefschritte, StringCipher.passPhrase);
           System.IO.File.WriteAllText("Pruef.xml", EncripStrCriPruefschritte);
        
        }     
        private void Form1_Load(object sender, EventArgs e)
        {
           // CreateFile();
            LoadData();
           string  EncripStrCriKomponenten=  System.IO.File.ReadAllText("Kompo.xml");
           string strCriKomponenten = StringCipher.Decrypt(EncripStrCriKomponenten, StringCipher.passPhrase);
           ListCriKomponentens = XmlSerializerUtility.DeSerialize<List<CriKomponenten>>(strCriKomponenten);

           string EncripStrCriPruefschritte= System.IO.File.ReadAllText("Pruef.xml");
           string strCriPruefschritte = StringCipher.Decrypt(EncripStrCriPruefschritte, StringCipher.passPhrase);
           _listCriPruefschritte = XmlSerializerUtility.DeSerialize<List<CriPruefschritte>>(strCriPruefschritte);
         
            manageUC(null, (short)EnumsUC.UC_EPS_200_Load_component);
        }
        private void LoadData()
        {
            if (System.IO.File.Exists("Setting.xml"))
            {
                string SettingString = System.IO.File.ReadAllText("Setting.xml");
                Form1.setting = XmlSerializerUtility.DeSerialize<Setting>(SettingString);
             }
            else {
                Form1.setting = new Setting();
            }
            customer = new Customer();
        }
        public void manageUC(object UCObjVal, short enumsUC, int indexOfTestStep =-1, List<CriPruefschritte> listCriPruefschritte=null)
        {
            this.panel1.Controls.Clear();
           if ((short)EnumsUC.UC_EPS_200_Load_component == enumsUC) 
           {
               UC_EPS_200_Load_component UCEpsL = new UC_EPS_200_Load_component(ListCriKomponentens);
               this.panel1.Controls.Add(UCEpsL);
           }
           else if ((short)EnumsUC.UCCommonRailInjector == enumsUC)
            {                                              
                CriKomponenten criKomponenten = (UCObjVal as CriKomponenten);
                List<CriPruefschritte> listCriPruefschritteFiltered = _listCriPruefschritte.Where(p => p.TypTeileNr == criKomponenten.TypTeileNr).ToList();
                UCCommonRailInjector UCCRI = new UCCommonRailInjector(listCriPruefschritteFiltered, criKomponenten);
                this.panel1.Controls.Add(UCCRI);
            }
           else if ((short)EnumsUC.UCCommonRailInjectorManual == enumsUC)
           {
               UCCommonRailInjectorManual UCCRI = new UCCommonRailInjectorManual(null, null);
               this.panel1.Controls.Add(UCCRI);
           }
           else if ((short)EnumsUC.UCTestEPS == enumsUC)
           {
               UCTestEPS UCTEPS;
               CriKomponenten criKomponenten = (UCObjVal as CriKomponenten);
               if (listCriPruefschritte ==null )//اگر اطلاعات سوزن دستی وارد نشده بود
               {
                   listCriPruefschritte = _listCriPruefschritte.Where(p => p.TypTeileNr == criKomponenten.TypTeileNr).ToList();
               }
               UCTEPS = new UCTestEPS(listCriPruefschritte, criKomponenten, indexOfTestStep);
               this.panel1.Controls.Add(UCTEPS); 
           }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new aboutEPS();
            frm.ShowDialog();
        }

    }
}
