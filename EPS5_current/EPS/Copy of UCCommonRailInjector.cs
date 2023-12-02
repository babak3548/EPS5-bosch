using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace EPS
{
    public partial class UCCommonRailInjectorManual : UserControl
    {

        SerialPort ComPort = new SerialPort();

        internal delegate void SerialDataReceivedEventHandlerDelegate(object sender, SerialDataReceivedEventArgs e);
        internal delegate void SerialPinChangedEventHandlerDelegate(object sender, SerialPinChangedEventArgs e);
        private SerialPinChangedEventHandler SerialPinChangedEventHandler1;
        delegate void SetTextCallback(string text);
        string InputData = String.Empty;

       // List<CriPruefschritte> criPruefschritte;
        List<CriPruefschritte> _ListCriPruefschritte;
        CriKomponenten _CriKomponenten;

        int Pressure = 0;
        double ferq = 0;
        int ActutionTime = 0;
        int ActuationProfile = 0;//vol
        int MeasurementTime = 0;
        int InjectedFuelQuantity = 0;
        public UCCommonRailInjectorManual(List<CriPruefschritte> listCriPruefschritte, CriKomponenten criKomponenten)
        {
            InitializeComponent();
            _ListCriPruefschritte =new List<CriPruefschritte>();
              _CriKomponenten =new  CriKomponenten();

            SerialPinChangedEventHandler1 = new SerialPinChangedEventHandler(PinChanged);
            ComPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived_1);
          
        }

        internal void PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            SerialPinChange SerialPinChange1 = 0;
            bool signalState = false;

            SerialPinChange1 = e.EventType;
           // lblCTSStatus.BackColor = Color.Green;
            //lblDSRStatus.BackColor = Color.Green;
            //lblRIStatus.BackColor = Color.Green;
            //lblBreakStatus.BackColor = Color.Green;
            switch (SerialPinChange1)
            {
                case SerialPinChange.Break:
                 //   lblBreakStatus.BackColor = Color.Red;
                    //MessageBox.Show("Break is Set");
                    break;
                case SerialPinChange.CDChanged:
                    signalState = ComPort.CtsHolding;
                    //  MessageBox.Show("CD = " + signalState.ToString());
                    break;
                case SerialPinChange.CtsChanged:
                    signalState = ComPort.CDHolding;
                  //  lblCTSStatus.BackColor = Color.Red;
                    //MessageBox.Show("CTS = " + signalState.ToString());
                    break;
                case SerialPinChange.DsrChanged:
                    signalState = ComPort.DsrHolding;
                  //  lblDSRStatus.BackColor = Color.Red;
                    // MessageBox.Show("DSR = " + signalState.ToString());
                    break;
                case SerialPinChange.Ring:
                  //  lblRIStatus.BackColor = Color.Red;
                    //MessageBox.Show("Ring Detected");
                    break;
            }
        }
        //private void orderListAndInit(List<CriPruefschritte> listCriPruefschritte)
        //{
        //    _ListCriPruefschritte.Add(listCriPruefschritte.FirstOrDefault(p => p.Pruefschrittname == "Leak test"));
        //    _ListCriPruefschritte.Add(listCriPruefschritte.FirstOrDefault(p => p.Pruefschrittname == "VL"));
        //    _ListCriPruefschritte.Add(listCriPruefschritte.FirstOrDefault(p => p.Pruefschrittname == "EM"));
        //    _ListCriPruefschritte.Add(listCriPruefschritte.FirstOrDefault(p => p.Pruefschrittname == "LL"));
        //    _ListCriPruefschritte.Add(listCriPruefschritte.FirstOrDefault(p => p.Pruefschrittname == "VL"));

        //}
        //public UCCommonRailInjectorManual()
        //{
//Leak test
//VL
//EM
//LL
//VL
        //}
        private void UCCommonRailInjector_Load(object sender, EventArgs e)
        {
           // criPruefschritteBindingSource.DataSource = _ListCriPruefschritte;
            //InitTextboxs(_ListCriPruefschritte.FirstOrDefault());

          //  txtTypeNumber.Text = _CriKomponenten.TypTeileNr;
            //drdManufacturer.Items.Add( _CriKomponenten.Hersteller);
           // drdManufacturer.SelectedIndex = 0;
           // drdActuationProfile.Items.Add(_CriKomponenten.Ansteuerprofil);
          //  drdActuationProfile.SelectedIndex = 0;
           // TxtSerialnumber.Text=_CriKomponenten.

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CriPruefschritte CurrentCriPruefschritte = (criPruefschritteBindingSource.Current as CriPruefschritte);

           // InitTextboxs(CurrentCriPruefschritte);
        }

        //private void InitTextboxs(CriPruefschritte CurrentCriPruefschritte)
        //{
        //    txtTestStepName.Text = CurrentCriPruefschritte.Pruefschrittname.AccessNullToShowValue();
        //    txtActutionTime.Text = CurrentCriPruefschritte.Ansteuerdauer.AccessNullToShowValue();
        //    txtPressure.Text = CurrentCriPruefschritte.Arbeitsdruck.AccessNullToShowValue();
        //    txt1InjectedFuelQuantity.Text = CurrentCriPruefschritte.Einspritzmenge.AccessNullToShowValue();
        //    txt2InjectedFuelQuantity.Text = CurrentCriPruefschritte.EinspritzmengeToleranz.AccessNullToShowValue();
        //    txt1ReturnQuantity.Text = CurrentCriPruefschritte.Ruecklaufmenge.AccessNullToShowValue();
        //    txt2ReturnQuantity.Text = CurrentCriPruefschritte.RuecklaufmengeToleranz.AccessNullToShowValue();
        //    txtMeasurementTime.Text = CurrentCriPruefschritte.Messzeit.AccessNullToShowValue();
        //}
        private CriPruefschritte CreateCriPruefschritte()
        {
            CriPruefschritte CurrentCriPruefschritte = new CriPruefschritte();
             CurrentCriPruefschritte.Pruefschrittname =txtTestStepName.Text.ToNullInSystem();
             CurrentCriPruefschritte.Ansteuerdauer = txtActutionTime.Text.ToNullInSystem();
             CurrentCriPruefschritte.Arbeitsdruck = txtPressure.Text.ToNullInSystem();
             CurrentCriPruefschritte.Einspritzmenge = txt1InjectedFuelQuantity.Text.ToNullInSystem();
             CurrentCriPruefschritte.EinspritzmengeToleranz = txt2InjectedFuelQuantity.Text.ToNullInSystem();
             CurrentCriPruefschritte.Ruecklaufmenge = txt1ReturnQuantity.Text.ToNullInSystem();
             CurrentCriPruefschritte.RuecklaufmengeToleranz = txt2ReturnQuantity.Text.ToNullInSystem();
             CurrentCriPruefschritte.Messzeit = txtMeasurementTime.Text.ToNullInSystem();
             return CurrentCriPruefschritte;
        }


        private void LoadF3_Click(object sender, EventArgs e)
        {
            (this.Parent.Parent as Form1).manageUC(null, (short)EnumsUC.UC_EPS_200_Load_component);
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
           //;
            //شماره تست جاری
            //List<CriPruefschritte> listCriPruefschritte, CriKomponenten criKomponenten
             _CriKomponenten.TypTeileNr = txtTypeNumber.Text;
            _CriKomponenten.Ansteuerprofil = drdActuationProfile.SelectedItem.ToString();
            _CriKomponenten.Hersteller = txtManufacturer.Text;
            int indexOfTest = 0;

          //  List<CriPruefschritte> listCriPruefschritte = new List<CriPruefschritte>();
            _ListCriPruefschritte.Add(CreateCriPruefschritte());
           // criPruefschritte.

            (this.Parent.Parent as Form1).manageUC(_CriKomponenten, (short)EnumsUC.UCTestEPS, indexOfTest, _ListCriPruefschritte);


        //    GetParamDataUC();
        //    try
        //    {
        //        // open port 
        //        ComPort.PortName = "COM3";//Convert.ToString(cboPorts.Text);
        //        ComPort.BaudRate = 115200; //Convert.ToInt32(cboBaudRate.Text);
        //        ComPort.DataBits = 8;//Convert.ToInt16(cboDataBits.Text);
        //        ComPort.StopBits = StopBits.One; //(StopBits)Enum.Parse(typeof(StopBits), cboStopBits.Text);
        //        ComPort.Handshake = Handshake.None;// (Handshake)Enum.Parse(typeof(Handshake), cboHandShaking.Text);
        //        ComPort.Parity = Parity.None;//(Parity)Enum.Parse(typeof(Parity), cboParity.Text);
        //        ComPort.Open();
        //        lblPort.Text = "open";
        //    }
        //    catch (Exception)
        //    {
        //        throw  new  Exception("error open port");
        //    }

        }

        private void GetParamDataUC()
        {
            Pressure = 0;
            ferq = 0;
            ActutionTime = 0;
            ActuationProfile = 0; 
            MeasurementTime = 0;
            InjectedFuelQuantity = 0;

            Pressure = txtPressure.Text.ToInteger() * 10;
            ferq = 0;
            ActutionTime = txtActutionTime.Text.ToInteger();
            ActuationProfile = drdActuationProfile.SelectedItem.ToString().GetNumberVal();//vol
            MeasurementTime = txtMeasurementTime.Text.ToInteger();
            InjectedFuelQuantity = txt1InjectedFuelQuantity.Text.ToInteger();

            if (ActutionTime == 0 || InjectedFuelQuantity== 0 ) { ferq = 0; }
            else if (ActutionTime >= 200 & InjectedFuelQuantity >= 6) { ferq = 16.8; }
            else if (ActutionTime > 200 & InjectedFuelQuantity < 6) { ferq = 33.2; }
            else if (ActutionTime < 200 & InjectedFuelQuantity < 6) { ferq = 64; }
            else { ferq = 16.8; }

        }


        private void port_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            InputData = ComPort.ReadExisting();
            if (InputData != String.Empty)
            {
                this.BeginInvoke(new SetTextCallback(SetText), new object[] { InputData });
            }

            //rp
            //rf
            //ra
            //rv
            //rt
        }

        private void SetText(string text)
        {
            try
            {
               // MessageBox.Show(text);
                //rtxtMicrRicive.Text = rtxtMicrRicive.Text + (text + "\r\n");
                if (text.Contains("p")) { WriteStringToPort(Pressure.ToString()); ComPort.Write("\r\n"); }
                if (text.Contains("f")) { WriteStringToPort(ferq.ToString()); ComPort.Write("\r\n"); }
                if (text.Contains("a")) { WriteStringToPort(ActutionTime.ToString()); ComPort.Write("\r\n"); }
                if (text.Contains("v")) { WriteStringToPort(ActuationProfile.ToString()); ComPort.Write("\r\n"); }
                if (text.Contains("t")) { WriteStringToPort(MeasurementTime.ToString()); ComPort.Write("\r\n"); }

               // this.rtbIncoming.Text += text;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }
       void  WriteStringToPort(string str)
        {
            //string x = "";
            var a = str.ToArray();
            foreach (var ch in a)
	         {
                // x += ch;
                ComPort.Write(ch.ToString());
         	}
        }
        


        private void button1_Click(object sender, EventArgs e)
        {
          //var x=  "#ij17.0500#".Between("#ij", "#");
            criPruefschritteBindingSource.MoveNext();
        }

        private void p_Click(object sender, EventArgs e)
        {
            WriteStringToPort(Pressure.ToString()); ComPort.Write("\r\n"); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WriteStringToPort(ferq.ToString()); ComPort.Write("\r\n"); 
        }

        private void a_Click(object sender, EventArgs e)
        {
            WriteStringToPort(ActutionTime.ToString()); ComPort.Write("\r\n"); 
        }

        private void v_Click(object sender, EventArgs e)
        {
            WriteStringToPort(ActuationProfile.ToString()); ComPort.Write("\r\n");
        }

        private void t_Click(object sender, EventArgs e)
        {
            WriteStringToPort(MeasurementTime.ToString()); ComPort.Write("\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            criPruefschritteBindingSource.MovePrevious();
        }


    }
}
