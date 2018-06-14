using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoyCompiler
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Any())
            {
                foreach (string path in args)
                {
                    if (!System.IO.File.Exists(path))
                        return;
                }


                Application.Run(new Form1(args));

            }
            else
                Application.Run(new Form1());
        }
    }
}