using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace __Pythagoras__
{
    public struct RAT //Right Angle Triangle. 절대 쥐가 아님.
    {
        public int a, b, c;
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int GetGCD(int value1, int value2)
        {
            while (value1 != 0 && value2 != 0)
            {
                if (value1 > value2)
                    value1 %= value2;
                else
                    value2 %= value1;
            }
            return Math.Max(value1, value2);
        }

        private bool Coprime(int value1, int value2)
        {
            return GetGCD(value1, value2) == 1;
        }

        private bool isRightValue(int m, int n)
        {
            if (m <= n)
                return false;
            if (n <= 0)
                return false;
            if (!Coprime(m, n))
                return false;
            if (m % 2 == 0)
            {
                if (n % 2 == 0)
                    return false;
            }
            else
            {
                if (n % 2 != 0)
                    return false;
            }
            return true;
        }

        private RAT MakeRAT(int m, int n)
        {
            int a = (int)(Math.Pow(m, 2) - Math.Pow(n, 2));
            int b = 2 * m * n;
            int c = (int)(Math.Pow(m, 2) + Math.Pow(n, 2));

            RAT result = new RAT();
            result.a = a; result.b = b; result.c = c;

            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(this.textBox1.Text);
            int _m = 0, _n = 0;
            Random r = new Random();


            for (int i = 0; i <= total; i++)
            {
                _m = r.Next(0, total);
                _n = r.Next(0, total);
                do
                {
                    _m = r.Next(0, total);
                    _n = r.Next(0, total);
                }
                while (!isRightValue(_m, _n));

                RAT result = MakeRAT(_m, _n);
                this.textBox2.Text += ("(" + result.a.ToString() + ", " + result.b.ToString() + ", " + result.c.ToString() + ")\r\n");
            }
        }
    }
}
