using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public class BlockManager
    {
        public Block[,] Blocks;
        public Control BlockControl;

        private int x, y;
        private int width, height;
        private int gapX, gapY;
        public BlockManager(int x, int y, int width, int height, int gapX, int gapY)
        {
            Blocks = new Block[x, y];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Blocks[i, j] = new Block(width, height);
                }
            }

            this.x = x; this.y = y;
            this.width = width; this.height = height;
            this.gapX = gapX; this.gapY = gapY;

            CreateControl();
            SetRandomValue(2);

            d = new debuger();
            d.Show();
            Debug(Arrow.NONE);

            //Blocks[0, 0].Value = 4; Blocks[0, 1].Value = 0; Blocks[0, 2].Value = 2; Blocks[0, 3].Value = 2;
        }

        private void CreateControl()
        {
            BlockControl = new Panel();
            BlockControl.Size = new System.Drawing.Size((gapX + width) * x + gapX, (gapY + height) * y + gapY);
            BlockControl.BackColor = System.Drawing.Color.Orange;

            int locX = gapX, locY = gapY;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Blocks[i, j].backPanel.Location = new System.Drawing.Point(locX, locY);
                    this.BlockControl.Controls.Add(Blocks[i, j].backPanel);
                    locX += width + gapX;
                }
                locX = gapX;
                locY += height + gapY;
            }
        }
        debuger d;
        private void Debug(Arrow arrow)
        {
            d.Append(arrow, Blocks, x, y);
        }

        public int[,] Board()
        {
            int[,] res = new int[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    res[i, j] = (int)Math.Log(1+2* (int)Blocks[i, j].Value, 2);
                }
            }

            return res;
        }

        private void SetRandomValue(int count)
        {
            if (CountZero() < count) return;
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                int _x = 0, _y = 0;
                do
                {
                    _x = r.Next(x); _y = r.Next(y);
                }
                while (Blocks[_x, _y].Value != 0);

                Blocks[_x, _y].Value = (uint)r.Next(1, 3) * 2;
            }
        }

        public bool CheckGameOver()
        {
            if (CountZero() != 0)
                return false;
            if (CanMove(Arrow.LEFT) && CanMove(Arrow.RIGHT) && CanMove(Arrow.UP) && CanMove(Arrow.DOWN))
                return false;
            return true;
        }

        private int CountZero()
        {
            int zero = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (Blocks[i, j].Value == 0)
                        zero++;
                }
            }

            return zero;
        }

        public void Restart()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Blocks[i, j].Value = 0;
                }
            }

            SetRandomValue(2);
        }

        public enum Arrow { NONE, LEFT, RIGHT, UP, DOWN }
        public void Move(Arrow arrow)
        {
            switch (arrow)
            {
                #region LEFT
                case Arrow.LEFT:
                    for (int j = 0; j < x; j++)
                    {
                        for (int i = 0; i < y; i++)
                        {
                            if (j > 0)
                            {
                                if (Blocks[i, j - 1].Value == 0)
                                {
                                    int lastNull = j - 1;
                                    for (int _j = j - 1; _j >= 0; _j--)
                                    {
                                        if (Blocks[i, _j].Value == 0)
                                        {
                                            lastNull = _j;
                                        }
                                        else
                                            break;
                                    }

                                    if (lastNull != 0 && Blocks[i, lastNull - 1].Value == Blocks[i, j].Value)
                                    {
                                        Blocks[i, lastNull - 1].Value = Blocks[i, j].Value * 2;
                                        Blocks[i, j].Value = 0;
                                    }
                                    else
                                    {
                                        Blocks[i, lastNull].Value = Blocks[i, j].Value;
                                        Blocks[i, j].Value = 0;
                                    }
                                }
                                else if (Blocks[i, j - 1].Value == Blocks[i, j].Value)
                                {
                                    Blocks[i, j - 1].Value = Blocks[i, j].Value * 2;
                                    Blocks[i, j].Value = 0;
                                }
                            }
                        }
                    }
                    break;
                #endregion

                #region RIGHT
                case Arrow.RIGHT:
                    for (int j = x - 1; j >= 0; j--)
                    {
                        for (int i = 0; i < y; i++)
                        {
                            if (j < x - 1)
                            {
                                if (Blocks[i, j + 1].Value == 0)
                                {
                                    int lastNull = j + 1;
                                    for (int _j = j + 1; _j < x; _j++)
                                    {
                                        if (Blocks[i, _j].Value == 0)
                                        {
                                            lastNull = _j;
                                        }
                                        else
                                            break;
                                    }

                                    if (lastNull != x - 1 && Blocks[i, lastNull + 1].Value == Blocks[i, j].Value)
                                    {
                                        Blocks[i, lastNull + 1].Value = Blocks[i, j].Value * 2;
                                        Blocks[i, j].Value = 0;
                                    }
                                    else
                                    {
                                        Blocks[i, lastNull].Value = Blocks[i, j].Value;
                                        Blocks[i, j].Value = 0;
                                    }
                                }
                                else if (Blocks[i, j + 1].Value == Blocks[i, j].Value)
                                {
                                    Blocks[i, j + 1].Value = Blocks[i, j].Value * 2;
                                    Blocks[i, j].Value = 0;
                                }
                            }
                        }
                    }
                    break;
                #endregion

                #region UP
                case Arrow.UP:
                    for (int i = 0; i < x; i++)
                    {
                        for (int j = 0; j < y; j++)
                        {
                            if (i > 0)
                            {
                                if (Blocks[i - 1, j].Value == 0)
                                {
                                    int lastNull = i - 1;
                                    for (int _i = i - 1; _i >= 0; _i--)
                                    {
                                        if (Blocks[_i, j].Value == 0)
                                        {
                                            lastNull = _i;
                                        }
                                        else
                                            break;
                                    }

                                    if (lastNull != 0 && Blocks[lastNull - 1, j].Value == Blocks[i, j].Value)
                                    {
                                        Blocks[lastNull - 1, j].Value = Blocks[i, j].Value * 2;
                                        Blocks[i, j].Value = 0;
                                    }
                                    else
                                    {
                                        Blocks[lastNull, j].Value = Blocks[i, j].Value;
                                        Blocks[i, j].Value = 0;
                                    }
                                }
                                else if (Blocks[i - 1, j].Value == Blocks[i, j].Value)
                                {
                                    Blocks[i - 1, j].Value = Blocks[i, j].Value * 2;
                                    Blocks[i, j].Value = 0;
                                }
                            }
                        }
                    }
                    break;
                #endregion

                #region DOWN
                case Arrow.DOWN:
                    for (int i = x - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < y; j++)
                        {
                            if (i < x - 1)
                            {
                                if (Blocks[i + 1, j].Value == 0)
                                {
                                    int lastNull = i + 1;
                                    for (int _i = i + 1; _i < x; _i++)
                                    {
                                        if (Blocks[_i, j].Value == 0)
                                        {
                                            lastNull = _i;
                                        }
                                        else
                                            break;
                                    }

                                    if (lastNull != x - 1 && Blocks[lastNull + 1, j].Value == Blocks[i, j].Value)
                                    {
                                        Blocks[lastNull + 1, j].Value = Blocks[i, j].Value * 2;
                                        Blocks[i, j].Value = 0;
                                    }
                                    else
                                    {
                                        Blocks[lastNull, j].Value = Blocks[i, j].Value;
                                        Blocks[i, j].Value = 0;
                                    }
                                }
                                else if (Blocks[i + 1, j].Value == Blocks[i, j].Value)
                                {
                                    Blocks[i + 1, j].Value = Blocks[i, j].Value * 2;
                                    Blocks[i, j].Value = 0;
                                }
                            }
                        }
                    }
                    break;
                    #endregion

            }
            if (!CheckGameOver() && CanMove(arrow))
                SetRandomValue(1);

            Debug(arrow);
        }

        public bool CanMove(Arrow arrow)
        {
            switch (arrow)
            {
                case Arrow.LEFT:
                    for (int j = 1; j < x; j++)
                    {
                        for (int i = 0; i < y; i++)
                        {
                            if (Blocks[i, j - 1].Value == 0)
                                return true;
                            if (Blocks[i, j - 1].Value == Blocks[i, j].Value)
                                return true;
                        }
                    }
                    break;

                case Arrow.RIGHT:
                    for (int j = x - 2; j >= 0; j--)
                    {
                        for (int i = 0; i < y; i++)
                        {
                                if (Blocks[i, j + 1].Value == 0)
                                return true;
                            if (Blocks[i, j + 1].Value == Blocks[i, j].Value)
                                return true;
                        }
                    }
                    break;

                case Arrow.UP:
                    for (int i = 1; i < x; i++)
                    {
                        for (int j = 0; j < y; j++)
                        {
                            if (Blocks[i - 1, j].Value == 0)
                                return true;
                            if (Blocks[i - 1, j].Value == Blocks[i, j].Value)
                                return true;
                        }
                    }
                    break;
                case Arrow.DOWN:
                    for (int i = x - 2; i >= 0; i--)
                    {
                        for (int j = 0; j < y; j++)
                        {
                            if (Blocks[i + 1, j].Value == 0)
                                return true;
                            if (Blocks[i + 1, j].Value == Blocks[i, j].Value)
                                return true;
                        }
                    }
                    break;
            }

            return false;
        }
        
        public uint MaxValue()
        {
            uint max = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    max = Math.Max(Blocks[i, j].Value, max);
                }
            }

            return max;
        }
    }
}