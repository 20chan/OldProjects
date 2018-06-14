using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using System.Runtime.InteropServices;
using CubeMit.Hook;
using System.Web;
using WinHttp;

namespace TvpleCloudArtMaker
{
    enum State
    {
        IDLE, DRAWING, PLAYING
    }
    enum PanelMouseState
    {
        UP, DOWN
    }

    struct CPoint
    {
        public CPoint(float x, float y)
        {
            X = x; Y = y;
        }
        public float X, Y;
    }
    public partial class Form1 : MaterialForm
    {
        DEBUG debugForm = new DEBUG();

        private const uint LBUTTONDOWN = 0x00000002;
        private const uint LBUTTONUP = 0x00000004;
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);
        [DllImport("user32.dll")]
        static extern int SetCursorPos(int x, int y);
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        public Form1()
        {
            InitializeComponent();
            p = new Pen(Color.Blue, 2.5f);
            toSend = Properties.Settings.Default.toSend;
            drawInterval = Properties.Settings.Default.drawInterval;
            this.timer1.Interval = drawInterval;
            Get_Size(tvpleLink);
        }

        State state = State.IDLE;
        PanelMouseState mouseState = PanelMouseState.UP;
        List<CPoint> points = new List<CPoint>();
        Graphics g;
        Pen p;


        public static string toSend = "●";
        public static int drawInterval = 50;
        public static string tvpleLink = "http://tvple.com/331040";
        public static string headerLink = "http://t.tvple.com/cloud/22n9bZlj2nSDlmLLdEI52oGR5JUdRHG_6NgnYuoxJi0%3D";

        public Size screen_Size = new Size();

        private void AddPoint(Graphics _graphic, CPoint _penelPoing)
        {
            try
            {
                _graphic = this.panel1.CreateGraphics();
                _graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                _graphic.DrawArc(p, _penelPoing.X, _penelPoing.Y, 1, 1, 0, 360);
                //_graphic.DrawLine(p, new Point(_point.X - 1, _point.Y - 1), new Point(_point.X + 1, _point.Y + 1));
                //_graphic.DrawLine(p, new Point(_point.X - 1, _point.Y + 1), new Point(_point.X + 1, _point.Y - 1));
                points.Add(_penelPoing);
            }
            catch { }
        }

        private CPoint realPanelPos()
        {
            float x = Cursor.Position.X - this.Location.X - panel1.Location.X;
            float y = Cursor.Position.Y - this.Location.Y - panel1.Location.Y;
            return new CPoint(x, y);
        }

        private CPoint GetScreenPos(CPoint _p)
        {

            float real_X = 0, real_Y = 0;
            try
            {
                real_X = ( _p.X * (screen_Size.Width) / panel1.Size.Width) / screen_Size.Width;
                real_Y = (_p.Y * (screen_Size.Height) / panel1.Size.Height) / screen_Size.Height;
            }
            catch { }
            return new CPoint(real_X, real_Y);
        }

        private void Play()
        {
            //this.Hide();
            System.Threading.Thread.Sleep(2000);
            foreach (CPoint po in points)
            {
                CPoint p = GetScreenPos(po);
                //move_Click(po);
                Send_Cloud(p.Y.ToString(), this.materialSingleLineTextField1.Text, toSend, p.X.ToString());
                //System.Threading.Thread.Sleep(timeGap);
                //type_String(toSend);
                //SendKeys.SendWait(toSend);
                //System.Threading.Thread.Sleep(timeGap);
                //KeyboardHook.MakeKeyEvent(Keys.D, KeyEventType.CLICK);
                //KeyboardHook.MakeKeyEvent(Keys.Enter, KeyEventType.CLICK);
                //System.Threading.Thread.Sleep(timeGap);
                //if (!this.Created) return;
            }
            //this.Show();
            state = State.IDLE;
        }
        void move_Click(Point _p)
        {
            int xpos = _p.X;
            int ypos = _p.Y;

            SetCursorPos(xpos, ypos);

            mouse_event(LBUTTONDOWN, 0, 0, 0, 0);
            mouse_event(LBUTTONUP, 0, 0, 0, 0);

        }

        void type_String(string str)
        {
            foreach (char c in str)
            {
                ConsoleKey ck;
                Enum.TryParse<ConsoleKey>(c.ToString(), true, out ck);

                if (ck != 0)
                {
                    keybd_event((byte)ck, 0, 0, UIntPtr.Zero);
                }
            }
        }

        void Send_Cloud(string y, string pos, string text, string x)
        {
            string _text = "text=" + HttpUtility.UrlEncode(text);
            string url = headerLink.Split('&')[0] + "&" + headerLink.Split('&')[1];
            url += "&text=" + text + "&pos=" + pos + "&x=" + x + "&y=" + y + "&_=" + headerLink.Split('&')[6].Split('=')[1];
            WinHttpRequest Winhttp = new WinHttpRequest();

            Winhttp.Open("GET", url);
            //Winhttp.SetRequestHeader("Cookie", this.textBox1.Text);
            Winhttp.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            Winhttp.Send();
            //MessageBox.Show(y + "&" + pos + "&" + text + "&" + x);
            Winhttp.WaitForResponse();
        }

        void Get_Size(string link)
        {
            WinHttpRequest Winhttp = new WinHttpRequest();

            Winhttp.Open("GET", link);
            Winhttp.Send();
            Winhttp.WaitForResponse();
            string result = Encoding.UTF8.GetString(Winhttp.ResponseBody);

            string[] Separators = new string[] { "fa fa-fw fa-television" };
            string[] strResults = result.Split(Separators, StringSplitOptions.None);

            string[] results1 = strResults[1].Split(new string[] { "</span>" }, StringSplitOptions.None);
            string[] size = results1[1].Split(new string[] { "</li>" }, StringSplitOptions.None);
            string finalsize = size[0];

            int x = Convert.ToInt32(System.Text.RegularExpressions.Regex.Replace(finalsize.Split('x')[0], @"\D", ""));
            int y = Convert.ToInt32(System.Text.RegularExpressions.Regex.Replace(finalsize.Split('x')[1], @"\D", ""));

            this.screen_Size = new System.Drawing.Size(x, y);
            this.materialLabel3.Text = "Video Size : (" + x.ToString() + "," + y.ToString() + ")";
        }

        private void BTN_DrawStart_Click(object sender, EventArgs e)
        {
            state = State.DRAWING;
            this.BTN_Clear.Enabled = this.BTN_DrawStart.Enabled = this.BTN_Play.Enabled = false;
            this.timer1.Interval = drawInterval;
        }

        private void BTN_DrawEnd_Click(object sender, EventArgs e)
        {
            state = State.IDLE;
            this.BTN_Clear.Enabled = this.BTN_DrawStart.Enabled = this.BTN_Play.Enabled = true;
        }

        private void BTN_Clear_Click(object sender, EventArgs e)
        {
            try
            {
                g = panel1.CreateGraphics();
                g.Clear(panel1.BackColor);
            }
            catch { }
            points = new List<CPoint>();
        }

        private void BTN_Play_Click(object sender, EventArgs e)
        {
            state = State.PLAYING;
            Play();
            try
            {
                g = panel1.CreateGraphics();
                g.Clear(panel1.BackColor);
            }
            catch { }
            points = new List<CPoint>();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseState = PanelMouseState.DOWN;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseState = PanelMouseState.UP;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.materialLabel1.Text = "X : " + GetScreenPos(realPanelPos()).X.ToString();
            this.materialLabel2.Text = "Y : " + GetScreenPos(realPanelPos()).Y.ToString();

            if (state == State.DRAWING)
            {
                if (mouseState == PanelMouseState.DOWN)
                {
                    if (realPanelPos().X > this.panel1.Width || realPanelPos().X < 0 || realPanelPos().Y > this.panel1.Height || realPanelPos().Y < 0)
                        return;
                    AddPoint(g, realPanelPos());
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.panel1.Size = new Size(this.Size.Width - 25, this.Size.Height - 138);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings f = new Settings();
            f.ShowDialog();
        }

        #region Opacity
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.9;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.80;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.70;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.60;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.50;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.40;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.30;
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.20;
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.10;
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
        }
        #endregion

        private void materialSingleLineTextField1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
                e.Handled = true;
        }
    }

    public class DoubleBufferPanel : Panel
    {
        public DoubleBufferPanel()
        {
            this.SetStyle(ControlStyles.DoubleBuffer |
              ControlStyles.UserPaint |
              ControlStyles.AllPaintingInWmPaint,
              true);

            this.UpdateStyles();
        }
    }
}