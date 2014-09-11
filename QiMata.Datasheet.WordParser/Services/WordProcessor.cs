using QiMata.Datasheet.Dal.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiMata.Datasheet.WordParser.Services
{
    class WordProcessor
    {
        private string _wordInstanceName;
        private string _pdfFilePath;
        private string _pdfProvider;
        private DatasheetContext _context;

        public WordProcessor(string wordInstanceName,
            string pdfFilePath,
            string pdfProvider)
        {
            _pdfFilePath = pdfFilePath;
            _wordInstanceName = wordInstanceName;
            _context = new DatasheetContext();
        }

        public async Task Process()
        {
            NetOffice.WordApi.Application app = new NetOffice.WordApi.Application();
            NetOffice.WordApi.Application.GetActiveInstances().Single(x => x.Documents.Any(y => y.Name == _wordInstanceName));
            app.DisplayAlerts = NetOffice.WordApi.Enums.WdAlertLevel.wdAlertsNone;
            var doc = app.Documents.Single(x => x.Name == _wordInstanceName);

            var datasheet = new Datasheet.Dal.Ef.Datasheet
                {
                    FilePath = _pdfFilePath,
                    Pdf = GetPdf(),
                    PdfProvider = _pdfProvider,
                };


            foreach (var section in app.Selection.Sections)
            {
                var newSection = new Section
                {

                };

                datasheet.Sections.Add(newSection);
                if (section.Range.Text != null)
                {
                    newSection.SectionText = section.Range.Text;
                }
                else
                {
                    //Extract image!
                    //newSection.SectionImage = section.Range.
                }
            }

            _context.Datasheets.Add(datasheet);
            await _context.SaveChangesAsync();
        }

        private byte[] GetPdf()
        {
            throw new NotImplementedException();
        }
    }
}
