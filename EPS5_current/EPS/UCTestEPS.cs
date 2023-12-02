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
using System.Threading;
//using System.Windows.Forms.DataVisualization.Charting;
using AnarSoft.Utility;
using AnarSoft.Utility.Utilities;
using VerticalProgressBar;

namespace EPS
{
    public partial class UCTestEPS : UserControl
    {
        SerialPort ComPort = new SerialPort();
        double time = 0;
        double rj = 0;
        double ij = 0;
        double SumReciveIj = 0;
        int CunterReciveIj = 0;
        double SumReciveRj = 0;
        int CunterReciveRj = 0;
        int conuterStep = 1;

        public int ConuterStep
        {
            get { return conuterStep; }
            set
            {
                conuterStep = value;
                //if (txtCounterStep != null)
                //{
                //    txtCounterStep.Text = value.ToString();
                //}
                //if (txtStateResultCount != null && StateResults != null)
                //{
                //    txtStateResultCount.Text = StateResults.Count.ToString();
                //}
               // Application.DoEvents();
            }
        }
        bool CurentResultStateij = true;
        bool CurentResultStateRj = true;
        bool isFinalTest = false;
        int indexOfTetStepThis = 0;
        // bool isOneTestThis = false;
        List<ResultTest> StateResults = new List<ResultTest>();
        //   bool flagStopProg = true;

        internal delegate void SerialDataReceivedEventHandlerDelegate(object sender, SerialDataReceivedEventArgs e);
        //internal delegate void SerialPinChangedEventHandlerDelegate(object sender, SerialPinChangedEventArgs e);
        // private SerialPinChangedEventHandler SerialPinChangedEventHandler1;
        delegate void SetTextCallback(string text);
        string InputData = String.Empty;

        List<CriPruefschritte> _ListCriPruefschritte;
        public static CriKomponenten _CriKomponenten;

        int Pressure = 0;
        double ferq = 0;
        int ActutionTime = 0;
        int ActuationProfile = 0;//vol
        int MeasurementTime = 0;
        int InjectedFuelQuantity = 0;
        int ReturnQuantity = 0;
        //  int verticalProgressBarHeight = 250;
        int verticalProgressBarWidth = 110;
        VerticalProgressBar.VerticalProgressBar verticalProgressBarIj = new VerticalProgressBar.VerticalProgressBar();
        VerticalProgressBar.VerticalProgressBar verticalProgressBarRj = new VerticalProgressBar.VerticalProgressBar();
        VerticalProgressBar.VerticalProgressBar verticalProgressBarIjYellow = new VerticalProgressBar.VerticalProgressBar();
        VerticalProgressBar.VerticalProgressBar verticalProgressBarRjYellow = new VerticalProgressBar.VerticalProgressBar();
        #region UC
        public UCTestEPS(List<CriPruefschritte> listCriPruefschritte, CriKomponenten criKomponenten, int indexOfTetStep)
        {
            // isOneTestThis = isOneTest;
            if (indexOfTetStep >= 0)//آیا یک مرحله تست انجام می شود
            {
                isFinalTest = true;
                indexOfTetStepThis = indexOfTetStep;
            }
            else
            {
                indexOfTetStepThis = 0;
            }

            ConuterStep = indexOfTetStepThis;
            InitializeComponent();
            _ListCriPruefschritte = listCriPruefschritte.OrderBy(p => p.PruefschrittNr).ToList();

            _CriKomponenten = criKomponenten;

            // SerialPinChangedEventHandler1 = new SerialPinChangedEventHandler(PinChanged);
            ComPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived_1);
            //ست کردن مقدار اولیه پروگرس ای جی
            verticalProgressBarIj.Height = pIJ.Height;
            verticalProgressBarIj.Value = 0;
            verticalProgressBarIj.Step = 1;
            verticalProgressBarIj.Color = Color.Green;
            verticalProgressBarIj.BorderStyle = BorderStyles.None;
            verticalProgressBarIj.Style = VerticalProgressBar.Styles.Solid;
            verticalProgressBarIj.Width = pIJ.Width - 1;
            // verticalProgressBarIj.BackGroundColor = Brushes.Green;
            pIJ.Controls.Add(verticalProgressBarIj);
            //ست کردن مقدار اولیه پروگرس ار جی
            verticalProgressBarRj.Height = pRj.Height;
            verticalProgressBarRj.Value = 0;
            verticalProgressBarRj.Step = 1;
            verticalProgressBarRj.Color = Color.Green;
            verticalProgressBarRj.BorderStyle = BorderStyles.None;
            verticalProgressBarRj.Style = VerticalProgressBar.Styles.Solid;
            verticalProgressBarRj.Width = pRj.Width - 1;
            pRj.Controls.Add(verticalProgressBarRj);
            // ست کردن مقدار اولیه پروگرس ای جی زرد
            verticalProgressBarIjYellow.Height = pIjYellow.Height;
            verticalProgressBarIjYellow.Value = 0;
            verticalProgressBarIjYellow.Step = 1;
            verticalProgressBarIjYellow.Color = Color.Yellow;
            verticalProgressBarIjYellow.BorderStyle = BorderStyles.None;
            verticalProgressBarIjYellow.Style = VerticalProgressBar.Styles.Solid;
            verticalProgressBarIjYellow.Width = pIjYellow.Width - 1;
            //verticalProgressBarIjYellow.BackGroundColor = Brushes.Yellow;
            pIjYellow.Controls.Add(verticalProgressBarIjYellow);

            // ست کردن مقدار اولیه پروگرس ار جی زرد
            verticalProgressBarRjYellow.Height = pRjYellow.Height;
            verticalProgressBarRjYellow.Value = 0;
            verticalProgressBarRjYellow.Step = 1;
            verticalProgressBarRjYellow.Color = Color.Yellow;
            verticalProgressBarRjYellow.BorderStyle = BorderStyles.None;
            verticalProgressBarRjYellow.Style = VerticalProgressBar.Styles.Solid;
            verticalProgressBarRjYellow.Width = pRjYellow.Width - 1;
            // verticalProgressBarRjYellow.BackGroundColor = Brushes.Yellow;
            pRjYellow.Controls.Add(verticalProgressBarRjYellow);



        }

        private void UCTestEPS_Load(object sender, EventArgs e)
        {
            //  PIj2.Top = label36.Top + 10;
            //  PIj2.TopLevelControl = label36.TopLevelControl + 10;
            criPruefschritteBindingSource.DataSource = _ListCriPruefschritte;
            InitTextboxs(_ListCriPruefschritte[indexOfTetStepThis]);

            drdActuationProfile.Items.Add(_CriKomponenten.Ansteuerprofil);
            drdActuationProfile.SelectedIndex = 0;

        }

        private void InitTextboxs(CriPruefschritte CurrentCriPruefschritte)
        {
            txtTestStepName.Text = CurrentCriPruefschritte.Pruefschrittname.AccessNullToShowValue();
            txtActutionTime.Text = CurrentCriPruefschritte.Ansteuerdauer.AccessNullToShowValue();
            txtPressure.Text = CurrentCriPruefschritte.Arbeitsdruck.AccessNullToShowValue();
            txt1InjectedFuelQuantity.Text = CurrentCriPruefschritte.Einspritzmenge.AccessNullToShowValue();
            txt2InjectedFuelQuantity.Text = CurrentCriPruefschritte.EinspritzmengeToleranz.AccessNullToShowValue();
            txt1ReturnQuantity.Text = CurrentCriPruefschritte.Ruecklaufmenge.AccessNullToShowValue();
            txt2ReturnQuantity.Text = CurrentCriPruefschritte.RuecklaufmengeToleranz.AccessNullToShowValue();
            txtMeasurementTime.Text = CurrentCriPruefschritte.Messzeit.AccessNullToShowValue();
            lblij.Text = (txt1InjectedFuelQuantity.Text.ToDouble() - txt2InjectedFuelQuantity.Text.ToDouble()).ToString();
            lblrj.Text = (txt1ReturnQuantity.Text.ToDouble() - txt2ReturnQuantity.Text.ToDouble()).ToString();
            txtPIj2.Text = (txt1InjectedFuelQuantity.Text.ToDouble() + txt2InjectedFuelQuantity.Text.ToDouble()).ToString();
            txtPRj2.Text = (txt1ReturnQuantity.Text.ToDouble() + txt2ReturnQuantity.Text.ToDouble()).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //GetNextTestValue();
            (this.Parent.Parent as Form1).manageUC(_CriKomponenten, (short)EnumsUC.UCCommonRailInjector);
        }

        private void GetNextTestValue()
        {
            criPruefschritteBindingSource.MoveNext();
            //if (criPruefschritteBindingSource.Count == criPruefschritteBindingSource.IndexOf(criPruefschritteBindingSource.Current) + 1)
            //{
            //    isFinalTest = true;
            //}
            CriPruefschritte CurrentCriPruefschritte = (criPruefschritteBindingSource.Current as CriPruefschritte);
            //StateResults.Count == ConuterState
            ConuterStep++;
            //StateResults.Add(new ResultTest
            //{
            //    boolResulij = false,
            //    boolResulRj = false
            //    ,
            //    StrResul = "این تست را کاربر رد کرده است",
            //    TestName = txtTestStepName.Text
            //});
            InitTextboxs(CurrentCriPruefschritte);
        }
        #endregion UC

        #region RS232

        private void LoadF3_Click(object sender, EventArgs e)
        {
            (this.Parent.Parent as Form1).manageUC(null, (short)EnumsUC.UC_EPS_200_Load_component);
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {

            GetParamDataUC();
            AddNewTestedInjector(_CriKomponenten.TypTeileNr);
            if (!ComPort.IsOpen)
            {
                try
                {
                    // open port 
                    ComPort.PortName = Form1.setting.Port;//Convert.ToString(cboPorts.Text);
                    ComPort.BaudRate = 115200; //Convert.ToInt32(cboBaudRate.Text);
                    ComPort.DataBits = 8;//Convert.ToInt16(cboDataBits.Text);
                    ComPort.StopBits = StopBits.One; //(StopBits)Enum.Parse(typeof(StopBits), cboStopBits.Text);
                    ComPort.Handshake = Handshake.None;// (Handshake)Enum.Parse(typeof(Handshake), cboHandShaking.Text);
                    ComPort.Parity = Parity.None;//(Parity)Enum.Parse(typeof(Parity), cboParity.Text);
                    ComPort.Open();
                    //lblPort.Text = "open";
                }
                catch (Exception)
                {
                    throw new Exception("Port is not join to divice or Error open port");
                }
            }
            //شروع تست
            //ComPort.Write("2");
            //richSending.Text = "2";
            ComPort.Write("\r\n");
            // ComPort.Write("\r\n");
            //ComPort.Write("\r\n");
            // richSending.Text += "\r\n";
            //ComPort.Write("a");
            //richSending.Text = "a";


        }

        private void AddNewTestedInjector(string injectorNumber)
        {
            if (Form1.LatestList.FirstOrDefault(l => l == injectorNumber) == null
                && Form1.ListCriKomponentens.FirstOrDefault(l => l.TypTeileNr == injectorNumber) != null)
            {
                if (Form1.LatestList.Count <= 20)
                {
                    Form1.LatestList.Add(injectorNumber);
                }
                else
                {
                    Form1.LatestList.RemoveAt(0);
                    Form1.LatestList.Add(injectorNumber);
                }
                string LatestListStr = XmlSerializerUtility.Serialize(Form1.LatestList);
                System.IO.File.WriteAllText("LatestList.xml", LatestListStr);
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (ComPort.IsOpen)
            {
                ComPort.Write("2");
                ComPort.Write("2");
                ComPort.Write("\r\n");
                ComPort.Close();
            }
        }

        private void GetParamDataUC()
        {
            Pressure = 0;
            ferq = 0;
            ActutionTime = 0;
            ActuationProfile = 0;
            MeasurementTime = 0;
            InjectedFuelQuantity = 0;
            ReturnQuantity = 0;

            Pressure = txtPressure.Text.ToInteger() * 10;
            ferq = 0;
            ActutionTime = txtActutionTime.Text.ToInteger();
            ActuationProfile = drdActuationProfile.SelectedItem.ToString().GetNumberVal();//vol
            MeasurementTime = txtMeasurementTime.Text.ToInteger();
            InjectedFuelQuantity = txt1InjectedFuelQuantity.Text.ToInteger();
            ReturnQuantity = txt1ReturnQuantity.Text.ToInteger();

            if (ActutionTime == 0 || InjectedFuelQuantity == 0) { ferq = 0; }
            else if (ActutionTime >= 200 & InjectedFuelQuantity >= 6) { ferq = 16; }
            else if (ActutionTime > 200 & InjectedFuelQuantity < 6) { ferq = 32; }
            else if (ActutionTime < 200 & InjectedFuelQuantity < 6) { ferq = 64; }
            else { ferq = 16; }

        }

        private void port_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(250);
            time += 1;
            if (ComPort.IsOpen)
            { InputData = ComPort.ReadExisting(); }
            if (InputData != String.Empty)
            {
                if (this.InvokeRequired)
                    this.BeginInvoke(new SetTextCallback(SendAndRecive), new object[] { InputData });
                else
                    SendAndRecive(InputData);
            }

        }
        private void ResetDigrams()
        {
            try
            {
                PIj2.BackColor = this.BackColor;
                PRj2.BackColor = this.BackColor;
                verticalProgressBarIj.Value = (int)(0.0).EqualPanelLenghValue(30);
                verticalProgressBarIjYellow.Value = (int)(0.0).EqualPanelLenghValue(30);
                verticalProgressBarRj.Value = (int)(0.0).EqualPanelLenghValue(30);
                verticalProgressBarRjYellow.Value = (int)(0.0).EqualPanelLenghValue(30);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        protected void DrawChartIj(double valParamete)
        {
            try
            {
                double baseValueParameter = 2 * txt2InjectedFuelQuantity.Text.ToDouble();
                if (baseValueParameter < valParamete)
                {
                    PIj2.BackColor = Color.Red;
                    CurentResultStateij = false;
                    verticalProgressBarIj.Value = (int)baseValueParameter.EqualPanelLenghValue(baseValueParameter);
                    // verticalProgressBarIj.BackColor = Color.Red;//
                }
                else if (valParamete < 0)
                {
                    CurentResultStateij = false;
                    verticalProgressBarIj.Value = (int)(0.0).EqualPanelLenghValue(baseValueParameter);
                    PIj2.BackColor = this.BackColor;
                    // verticalProgressBarIj.BackColor = Color.Red;
                }
                else
                {
                    PIj2.BackColor = this.BackColor;
                    verticalProgressBarIj.Value = (int)valParamete.EqualPanelLenghValue(baseValueParameter);
                    CurentResultStateij = true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void DrawChartRj(double valParamete)
        {
            try
            {
                double baseValueParameter = 2 * txt2ReturnQuantity.Text.ToDouble();
                if (baseValueParameter < valParamete)
                {
                    PRj2.BackColor = Color.Red;
                    CurentResultStateRj = false;
                    verticalProgressBarRj.Value = (int)baseValueParameter.EqualPanelLenghValue(baseValueParameter);
                    //verticalProgressBarRj.BackColor = Color.Red;
                }
                else if (valParamete < 0)
                {
                    CurentResultStateRj = false;
                    verticalProgressBarRj.Value = (int)(0.0).EqualPanelLenghValue(baseValueParameter);
                    //  verticalProgressBarRj.BackColor = Color.Red;
                    PRj2.BackColor = this.BackColor;
                }
                else
                {
                    PRj2.BackColor = this.BackColor;
                    verticalProgressBarRj.Value = (int)valParamete.EqualPanelLenghValue(baseValueParameter);
                    CurentResultStateRj = true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //رسم نمودار پایین
        protected void DrawChartIjYellow(double valParamete)
        {
            try
            {
                double baseValueParameter = txt1InjectedFuelQuantity.Text.ToDouble() - txt2InjectedFuelQuantity.Text.ToDouble();

                if (baseValueParameter < valParamete)
                {
                    //verticalProgressBarIjYellow.BackColor = Color.Transparent;
                    verticalProgressBarIjYellow.Value = (int)(baseValueParameter).EqualPanelLenghValue(baseValueParameter);
                }
                else
                {
                    //verticalProgressBarIjYellow.BackColor = Color.Yellow;
                    verticalProgressBarIjYellow.Value = (int)valParamete.EqualPanelLenghValue(baseValueParameter);
                    CurentResultStateRj = false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //رسم نمودار پایین
        protected void DrawChartRjYellow(double valParamete)
        {
            try
            {
                double baseValueParameter = txt1ReturnQuantity.Text.ToDouble() - txt2ReturnQuantity.Text.ToDouble();

                if (baseValueParameter < valParamete)
                {
                    verticalProgressBarRjYellow.Value = (int)(baseValueParameter).EqualPanelLenghValue(baseValueParameter);
                }
                else
                {
                    //verticalProgressBarRjYellow.BackColor = Color.Yellow;
                    verticalProgressBarRjYellow.Value = (int)valParamete.EqualPanelLenghValue(baseValueParameter);
                    CurentResultStateRj = false;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void SendAndRecive(string reciveStr)
        {
            try
            {
                #region send rs232
                if (reciveStr.Contains("#start"))
                {
                    //   richSending.Text += "#start" + "\r\n";
                    ComPort.Write("8");
                    ComPort.Write("\r\n");
                }
                if (reciveStr.Contains("#pi"))
                {
                    // richSending.Text += Pressure.ToString() + "\r\n";
                    WriteStringToPort(Pressure.ToString());
                    ComPort.Write("\r\n");
                }
                if (reciveStr.Contains("#fi"))
                {
                    //  richSending.Text += ferq.ToString() + "\r\n";
                    WriteStringToPort(ferq.ToString());
                    ComPort.Write("\r\n");
                }
                if (reciveStr.Contains("#ai"))
                {
                    // richSending.Text += ActutionTime.ToString() + "\r\n";
                    WriteStringToPort(ActutionTime.ToString());
                    ComPort.Write("\r\n");
                }
                if (reciveStr.Contains("#vi"))
                {
                    // richSending.Text += ActuationProfile.ToString() + "\r\n";
                    WriteStringToPort(ActuationProfile.ToString());
                    ComPort.Write("\r\n");
                }
                if (reciveStr.Contains("#ti"))
                {
                    //  richSending.Text += MeasurementTime.ToString() + "\r\n";
                    WriteStringToPort(MeasurementTime.ToString());
                    ComPort.Write("\r\n");
                    //زمانی که آخرین ولیو یک تست را ارسال می کند مقدار شمارنده مراحل را یک مرتبه افزایش میدهد و تا زمانی که نتیجه 
                    //تست اون مرحله به لیست نتایج اضافه نشود دیگر این شمارنده افزایش نمی یابد
                    if (StateResults.Count == ConuterStep && !isFinalTest)// (StateResults.Count == ConuterStep && StateResults.Count < 4)
                    { ConuterStep += 1; }
                }
                if (reciveStr.Contains("#test step"))//شروع یک مرحله از تست رو مشخص می کنه
                {
                    //if (ConuterStep == 1)
                    //{
                    //    ComPort.Write("3");
                    //    ComPort.Write("\r\n");
                    //}
                    //else 
                    if (InjectedFuelQuantity > 0 && ReturnQuantity <= 0)
                    {
                        ComPort.Write("2");
                        ComPort.Write("\r\n");
                    }
                    else if (InjectedFuelQuantity <= 0 && ReturnQuantity > 0)
                    {
                        ComPort.Write("1");
                        ComPort.Write("\r\n");
                    }
                    else if (InjectedFuelQuantity <= 0 && ReturnQuantity <= 0)
                    {
                        ComPort.Write("1");
                        ComPort.Write("\r\n");
                    }
                    else
                    {
                        ComPort.Write("3");
                        ComPort.Write("\r\n");
                    }
                    //
                    //
                }
                #endregion send rs232
                //recive rs232
                #region Recive rs232

                if (reciveStr.Contains("#pr"))
                {
                    //  txtReciving.Text = reciveStr + "\r\n";
                    txtPr.Text = reciveStr.Between("#pr", "#");
                }
                if (reciveStr.Contains("#te"))
                {
                    //  txtReciving.Text = reciveStr + "\r\n";
                    txtTe.Text = reciveStr.Between("#te", "#");
                }
                if (reciveStr.Contains("#tr"))
                {
                    //  txtReciving.Text = reciveStr + "\r\n";
                    txtTr.Text = reciveStr.Between("#tr", "#");
                }
                if (reciveStr.Contains("#ij"))
                {
                    //  txtReciving.Text = reciveStr + "\r\n"; 
                    txtIj.Text = reciveStr.Between("#ij", "#");
                    ij = txtIj.Text.ToDouble();
                    SumReciveIj += ij;
                    CunterReciveIj++;
                    DrawChartIj(ij - (txt1InjectedFuelQuantity.Text.ToDouble() - txt2InjectedFuelQuantity.Text.ToDouble()));
                    DrawChartIjYellow(ij);
                }
                if (reciveStr.Contains("#rj"))
                {
                    //   txtReciving.Text = reciveStr + "\r\n";
                    txtRj.Text = reciveStr.Between("#rj", "#");
                    rj = txtRj.Text.ToDouble();
                    SumReciveRj += rj;
                    CunterReciveRj++;
                    DrawChartRj(rj - (txt1ReturnQuantity.Text.ToDouble() - txt2ReturnQuantity.Text.ToDouble()));
                    DrawChartRjYellow(rj);
                }
                if (reciveStr.Contains("#vl"))
                {
                    txtFuel.Text = reciveStr.Between("#vl", "#");
                    if (txtVl.Text.ToInteger() == 1) txtFuel.Text = "empty";
                    if (txtVl.Text.ToInteger() == 2) txtFuel.Text = "middle";
                    if (txtVl.Text.ToInteger() == 3) txtFuel.Text = "full";
                }
                //برای تست مجودی مخزن #lv
                //مقادیر سه عدد می باشد
                //1 یعنی خالی
                //2 نیمه پر
                //3 فول پر
                // 
                #endregion Recive rs232

                #region Control
                if (reciveStr.Contains("finish"))
                {
                    //یعنی تمام مراحل تست تمام شده است
                    if (
                        isFinalTest |
                          (criPruefschritteBindingSource.Count == criPruefschritteBindingSource.IndexOf(criPruefschritteBindingSource.Current) + 1)
                        )
                    {
                        StateResults.Add(SetResultState());
                        ComPort.Write("22");
                        ComPort.Write("\r\n");
                        MessageBox.Show("عملیات تست پایان یافت");
                        var x = new CreatePDF(StateResults);        //نمایش گزارش نتیجه پی دی اف
                        btnStop_Click(null, null);
                    }
                    //یعنی تست مرحله جاری تمام شده است و شما نتیجه تست را در لیست مورد نظر اضافه کنید
                    //و در خواست عبور به مرحله بعد را به میکرو کنترولر اعلام می کند
                    else //if (StateResults.Count < ConuterStep)
                    {
                        StateResults.Add(SetResultState());
                        GetNextTestValue();
                        GetParamDataUC();
                        //نتیجه تست مشخص می گردد و بر اساس سناریو تعرف شده تصمیم به ادامه یا  قطع تست انجام می شود 
                        //کدی به میکرو کنترولر ارسال گردد تا میکروکنترولر بفهمد اطلاعات تست جدید لود شده است 
                        ComPort.Write("9");
                        ComPort.Write("\r\n");
                    }
                    //else//در خواست عبور به مرحله بعد را تا زمانی که میکرو کنترولر آن را دریافت کند ادامه می دهد
                    //{
                    //    ComPort.Write("9");
                    //    ComPort.Write("\r\n");
                    //}
                    ResetDigrams();
                }
                #endregion Control
                //   this.rtbIncoming.Text += reciveStr;
                Application.DoEvents();
            }
            catch (Exception ex)
            {

                //throw ex;
            }

        }

        private ResultTest SetResultState()
        {
            double avregeIj = SumReciveIj / CunterReciveIj;
            SumReciveIj = 0;
            CunterReciveIj = 0;

            double avregeRj = SumReciveRj / CunterReciveRj;
            SumReciveRj = 0;
            CunterReciveRj = 0;

            bool IjIsSuccess = false;
            bool RjIsSuccess = false;
            if (
                avregeIj >= (txt1InjectedFuelQuantity.Text.ToDouble() - txt2InjectedFuelQuantity.Text.ToDouble()) &&
                avregeIj <= (txt1InjectedFuelQuantity.Text.ToDouble() + txt2InjectedFuelQuantity.Text.ToDouble())
                )
            {
                IjIsSuccess = true;
            }
            if (
                avregeRj >= (txt1ReturnQuantity.Text.ToDouble() - txt2ReturnQuantity.Text.ToDouble()) &&
                avregeRj <= (txt1ReturnQuantity.Text.ToDouble() + txt2ReturnQuantity.Text.ToDouble())
            )
            {
                RjIsSuccess = true;
            }
            //(txt1InjectedFuelQuantity.Text.ToDouble() - txt2InjectedFuelQuantity.Text.ToDouble())
            return new ResultTest
            {
                TestName = txtTestStepName.Text,
                ////StrResul = (CurentResultStateRj == false || CurentResultStateij == false ?
                ////  " تست " + txtTestStepName.Text + " با شکست مواجه شد  "
                ////: " تست " + txtTestStepName.Text + " با موفقیت پایان یافت "),
                //boolResulRj = CurentResultStateRj,
                //boolResulij = CurentResultStateij,
                InjectedFuelQuantityActualValue = avregeIj.ToString(),
                ReturnQuantityActualValue = avregeRj.ToString(),
                InjectedFuelQuantitySetValue = txt1InjectedFuelQuantity.Text + " ± " + txt2InjectedFuelQuantity.Text,
                ReturnQuantitySetValue = txt1ReturnQuantity.Text + " ± " + txt2ReturnQuantity.Text,
                StrResul = (IjIsSuccess && RjIsSuccess).ToString(),
                MeasurementTime = txtMeasurementTime.Text,
                Pressure = txtPressure.Text,
                ActuationTime = txtActutionTime.Text
            };
        }

        void WriteStringToPort(string str)
        {
            //string x = "";
            var a = str.ToArray();
            foreach (var ch in a)
            {
                // x += ch;
                ComPort.Write(ch.ToString());
            }
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

        #endregion RS232

        #region TempTest
        private void btnSendOneValue_Click(object sender, EventArgs e)
        {
            //ComPort.Write(txtSendOneValue.Text);
            string strEmulutedate = "";
            Random rnd = new Random();
            int range1 = 0;
            int range2 = 1;
            range1 = txtRange1.Text.ToInteger();
            range2 = txtRange2.Text.ToInteger();
            while (true)
            {
                Thread.Sleep(500);
                //range1 = txtRange1.Text.ToInteger();
                //range2 = txtRange2.Text.ToInteger();
                //if (range1 > range2){range1=0;range2=1;};
                //strEmulutedate = "#"+txtDigramValue.Text+ rnd.Next(range1,range2) + "#ttsr";
                if (range1 > range2 + 10) { range1 = 0; };
                strEmulutedate = "#" + txtDigramValue.Text + (range1++) + "#ttsr";
                SendAndRecive(strEmulutedate);

                Application.DoEvents();

            }

        }
        private void p_Click(object sender, EventArgs e)
        {
            WriteStringToPort(Pressure.ToString()); ComPort.Write("\r\n");
        }

        private void button3_Click(object sender, EventArgs e)
        {

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
            //  WriteStringToPort(MeasurementTime.ToString()); ComPort.Write("\r\n");
            //Series series = this.chart1.Series.Add("bar1");

            // Add point.
            while (true)
            {
                Random rnd = new Random();
                //  rnd.Next(1, 10);

                // Random rnd = new Random();
                //  chart1.Series[0].Points.Clear();
                // for (int g = 5; g <= 15; g++)
                //{
                // DataPoint dp = new DataPoint(5, rnd.Next(100));
                //if (chart1.Series[0].Points.Count() > 150) chart1.Series[0].Points.RemoveAt(0);
                //    chart1.Series[0].Points.Add(1);
                //    chart1.ResetAutoValues();

                // }
                // chart1.refresh();

            }

        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            // var list = new Dictionary<string,string> { {"1", "test1" }, { "2","test2" }, {"3", "test3" }, {"4", "test4" } };
            // var x = new CreatePDF(list);
            // ComPort.Write("\r\n");
        }
        #endregion TempTest



        private void rtbIncoming_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void PIj2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblij_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtRecivingAll_TextChanged(object sender, EventArgs e)
        {

        }





    }
}
