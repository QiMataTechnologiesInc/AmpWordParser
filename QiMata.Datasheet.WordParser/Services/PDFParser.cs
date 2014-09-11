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

        public PDFParser(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<bool> ParseAndSave()
        {
            try
            {
                StartWordWithPdf();
                await ProcessTextFromWord();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private Task ProcessTextFromWord()
        {
            //TODO: Put in the right paths
            WordProcessor processor = new WordProcessor(GetInstanceName(_filePath),
                "","");
            return processor.Process();
        }

        private string GetInstanceName(string _filePath)
        {
            throw new NotImplementedException();
        }

        private void StartWordWithPdf()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "start Winword.exe \"" + _filePath + "\"";
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}
