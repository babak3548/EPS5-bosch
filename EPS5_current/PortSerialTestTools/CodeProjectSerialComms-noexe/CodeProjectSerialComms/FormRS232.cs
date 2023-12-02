using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeProjectSerialComms
{
    public partial class FormRS232 : Form
    {
        public FormRS232()
        {
            InitializeComponent();
        }
        public List<string> GetAllPorts()
        {
            try
            {
                List<String> allPorts = new List<String>();
                foreach (String portName in System.IO.Ports.SerialPort.GetPortNames())
                {
                    allPorts.Add(portName);
                }
                return allPorts;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //private List<ManagementObject> getAllComPort()
        //{
        //    List<ManagementObject> objct = new List<ManagementObject>();
        //    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM " +
        //    WIN_SERIAL_OBJECT_NAME + ""))
        //    {
        //        foreach (ManagementObject serialPortObj in searcher.Get())
        //        {
        //            objct.Add(serialPortObj);
        //        }
        //    }
        //    return objct;
        //}
        private void button1_Click(object sender, EventArgs e)
        {


            var ports = GetAllPorts();
            foreach (var item in ports)
            {
                textBox1.Text += item;
            }

        }
    }
}
