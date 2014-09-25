using QiMata.Datasheet.Dal.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiMata.Datasheet.WordParser.Services
{
    class PDFParser
    {
        private string _filePath;
        private DatasheetContext _context;

        public PDFParser(string filePath)
        {
            _filePath = filePath;
            _context = new DatasheetContext();
        }

        public async Task<bool> ParseAndSave()
        {
            try
            {
                await StartWordWithPdfAdProcess();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string GetInstanceName(string _filePath)
        {
            //fix for more interesting instances
            return "Atmel";
            throw new NotImplementedException();
        }

        private Task StartWordWithPdfAdProcess()
        {
            var pdfBytes = System.IO.File.ReadAllBytes(_filePath);
            using (NetOffice.WordApi.Application app = new NetOffice.WordApi.Application())
            {
#if DEBUG
                app.Visible = true;
#endif
                var doc = app.Documents.Open(_filePath);

                var datasheet = new Datasheet.Dal.Ef.Datasheet
                {
                    FilePath = _filePath,
                    Pdf = pdfBytes,
                    PdfProvider = GetInstanceName(_filePath),
                };

                foreach (var section in doc.Paragraphs)
                {
                    var newSection = new Section
                    {

                    };

                    datasheet.Sections.Add(newSection);
                    if (!String.IsNullOrEmpty(section.Range.Text) && ! String.IsNullOrWhiteSpace(section.Range.Text))
                    {
                        newSection.SectionText = section.Range.Text;
                    }
                    else
                    {
                        //Extract image!
                        //newSection.SectionImage = section.Range.
                    }
                }
                app.Quit();
                _context.Datasheets.Add(datasheet);
                return _context.SaveChangesAsync();
            }
        }
    }
}
