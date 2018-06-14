using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public class Block
    {
        public Panel backPanel; //투명한 판넬
        private Label valueLabel;
        private uint value;
        public uint Value
        {
            get { return value; }
            set { this.value = value; Invalidate(); }
        }

        public Block(int width, int height)
        {
            backPanel = new Panel();
            backPanel.BackColor = System.Drawing.Color.Blue;
            backPanel.Size = new System.Drawing.Size(width, height);

            valueLabel = new Label();
            valueLabel.AutoSize = false;
            valueLabel.BackColor = backPanel.BackColor;
            valueLabel.Size = backPanel.Size;
            valueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            backPanel.Controls.Add(valueLabel);
            Value = 0;
        }

        private void Invalidate()
        {
            if (value == 0)
                backPanel.BackColor = System.Drawing.Color.Blue;
            else if (value <= 2)
                backPanel.BackColor = System.Drawing.Color.White;
            else if (value <= 4)
                backPanel.BackColor = System.Drawing.Color.MistyRose;
            else if (value <= 8)
                backPanel.BackColor = System.Drawing.Color.Salmon;
            else if (value <= 32)
                backPanel.BackColor = System.Drawing.Color.IndianRed;
            else if (value <= 128)
                backPanel.BackColor = System.Drawing.Color.Yellow;
            else if (value <= 1024)
                backPanel.BackColor = System.Drawing.Color.LightYellow;
            else if (value <= 4086)
                backPanel.BackColor = System.Drawing.Color.DarkGray;
            else
                backPanel.BackColor = System.Drawing.Color.Red;

            valueLabel.BackColor = backPanel.BackColor;
            valueLabel.Text = value == 0 ? "" : value.ToString();
        }
    }
}
