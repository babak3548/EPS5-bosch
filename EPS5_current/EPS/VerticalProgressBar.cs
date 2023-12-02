using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace EPS
{


    //public class VerticalProgressBar : ProgressBar
    //{


    //  //  public VerticalProgressBar()
    //  //{
    //  //  this.SetStyle(ControlStyles.UserPaint, true);
    //  //}
    //  //I added a new property to the progress bar to let the user change the color
    //  public Brush BackGroundColor 
    //  { 
    //    get; 
    //    set;
    //  }

    //  //protected override void OnPaint(PaintEventArgs e)
    //  //{
    //  //  Rectangle rec = e.ClipRectangle;

    //  //  rec.Width = Convert.ToInt32(Math.Truncate(rec.Width * (Convert.ToDouble(Value) / Maximum))) - 4;
    //  //  if (ProgressBarRenderer.IsSupported)
    //  //  {
    //  //    ProgressBarRenderer.DrawVerticalBar(e.Graphics, e.ClipRectangle);
    //  //  }
    //  //  rec.Height = rec.Height - 4;

    //  //  if (BackColor==null)
    //  //  {
    //  //    e.Graphics.FillRectangle(Brushes.YellowGreen, 2, 2, rec.Width, rec.Height);
    //  //  }
    //  //  else
    //  //  {
    //  //    e.Graphics.FillRectangle(BackGroundColor, 2, 2, rec.Width, rec.Height);
    //  //  }
    //  //}

    //  protected override CreateParams CreateParams
    //  {
    //      get
    //      {
    //          CreateParams cp = base.CreateParams;
    //          cp.Style |= 0x04;
    //          cp.ExStyle |= 0x20; //0x20;
    //          //cp.ClassStyle
    //       //   cp.Style
    //          return cp;
    //      }
    //  }
    //}
}
