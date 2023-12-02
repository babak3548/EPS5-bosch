using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EPS
{
    public partial class ucLine : UserControl
    {
        public ucLine()
        {
            InitializeComponent();
        }

        private void ucLine_Resize(object sender, EventArgs e)
        {
            lineShape1.X1 = 0;
            lineShape1.X2 = this.ClientSize.Width;
            lineShape1.Y1 = lineShape1.Y2 = 0;
        }
    }
}
