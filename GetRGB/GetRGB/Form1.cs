using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace GetRGB
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        public Form1()
        {
            InitializeComponent();
        }

        Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
        public Color GetColorAt(Point location)
        {
            using (Graphics gdest = Graphics.FromImage(screenPixel))
            {
                using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr hSrcDC = gsrc.GetHdc();
                    IntPtr hDC = gdest.GetHdc();
                    int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();
                }
            }

            return screenPixel.GetPixel(0, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point cursor = new Point();
            GetCursorPos(ref cursor);

            Color c = GetColorAt(cursor);
            Color rev = Color.FromArgb(c.R ^ 255, c.G ^ 255, c.B ^ 255);
            this.label3.Text = "#" + c.R.ToString("X" + 2) + c.G.ToString("X" + 2) + c.B.ToString("X" + 2);
            this.label6.Text = c.R.ToString();
            this.label7.Text = c.G.ToString();
            this.label8.Text = c.B.ToString();
            label3.ForeColor = label1.ForeColor = label2.ForeColor = label4.ForeColor = label5.ForeColor = label6.ForeColor = label7.ForeColor = label8.ForeColor = rev;

            this.BackColor = c;
        }
    }
}
