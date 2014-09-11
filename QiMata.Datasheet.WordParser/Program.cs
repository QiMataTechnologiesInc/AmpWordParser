using QiMata.Datasheet.WordParser.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace QiMata.Datasheet.WordParser
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
                {
                    x.Service<PDFProcessingService>();

                    x.SetDescription("Processes the pdfs downloaded from various websites and uploads them into the database");
                    x.SetDisplayName("PDF Datasheet Processing Service");
                    x.SetServiceName("PDFDatasheetProcessingService");
                });
        }
    }
}
