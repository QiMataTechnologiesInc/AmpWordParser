using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QiMata.Datasheet.Miner.Helpers
{
    class PdfDownloader
    {
        private const string DirectoryPath = "C:/Pdfs/";

        private Uri _link;
        private string _fileName;

        public PdfDownloader(string link)
        {
            _link = new Uri(link);
            _fileName = link.Substring(link.LastIndexOf("/"));
        }

        public void DownloadAndWrite()
        {
            System.Net.WebClient client = new System.Net.WebClient();
            client.DownloadFile(_link, DirectoryPath + _fileName);
        }
    }
}
