using QiMata.Datasheet.Miner.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QiMata.Datasheet.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                foreach (var item in (new QiMata.Datasheet.Miner.Atmel.PdfFinder()).GetPdfLinksAsync().Result)
                {
                    PdfDownloader loader = new PdfDownloader(item);
                    loader.DownloadAndWrite();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
