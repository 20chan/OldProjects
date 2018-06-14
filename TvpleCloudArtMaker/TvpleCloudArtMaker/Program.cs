using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Numerics;

namespace TvpleCloudArtMaker
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead("https://www.dropbox.com/s/f9nosbumk1ggby8/TCA_MACLIST.txt?dl=1");
                StreamReader sr = new StreamReader(stream);
                string[] macs = sr.ReadToEnd().Split('\n');
                string modelNo = identifier("Win32_DiskDrive", "Signature");
                BigInteger b = BigInteger.Parse(modelNo);
                string res = BigInteger.Pow(b, 3).ToString();

                bool a = false;
                foreach (string mac in macs)
                {
                    if (mac.StartsWith(res))
                        a = true;
                }

                if (a == true)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Load());
                    if (Load.isReady)
                        Application.Run(new Form1());
                }
                else
                {
                    if (MessageBox.Show("라이센스가 등록되어있지 않았습니다. 등록하시겠습니까?", "라이센스", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\license.lcs", FileMode.Create))
                        {
                            using (StreamWriter sw = new StreamWriter(fs))
                            {
                                sw.Write(res);
                            }
                        }
                    }
                }
            }
            finally
            {

            }
        }
        private static string identifier(string wmiClass, string wmiProperty)
        //Return a hardware identifier
        {
            string result = "";
            System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                //Only get the first one
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }
    }
}
