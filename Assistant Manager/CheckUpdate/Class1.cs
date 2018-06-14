using System.Net;

namespace CheckUpdate
{
    public class UpdateChecker
    {
        private const string link = "https://www.dropbox.com/s/cihsymhpks2n7ku/VERSION.txt?dl=1";
        private string AppName = string.Empty;
        public UpdateChecker(string name)
        {
            this.AppName = name;
        }

        public VERSION Get()
        {
            WebClient w = new WebClient();
            w.Encoding = System.Text.Encoding.UTF8;
            string result = w.DownloadString(new System.Uri(link));
            string[] lines = result.Split('\n');
            foreach(string line in lines)
            {
                if(line.StartsWith(AppName))
                {
                    VERSION v_ = new VERSION();
                    v_.AppName = this.AppName;
                    v_.Version = (float)System.Convert.ToDouble(line.Split('?')[1]);
                    v_.DownloadLink = line.Split('?')[2];
                    v_.SUCCEED = true;
                    return v_;
                }
            }
            VERSION v = new VERSION();
            v.SUCCEED = false;
            return v;
        }
    }

    public struct VERSION
    {
        public bool SUCCEED;
        public string AppName;
        public float Version;
        public string DownloadLink;
    }
}
