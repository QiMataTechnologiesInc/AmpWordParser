using QiMata.Datasheet.WordParser.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;

namespace QiMata.Datasheet.WordParser.Services
{
    class PDFProcessingService : ServiceControl
    {
        private const string Directory = "D:/Pdfs";
        private Timer _wordProcessor;
        private TaskContainer _taskContainer;

        public bool Start(HostControl hostControl)
        {
            try
            {
                
                //_wordProcessor = new Timer(ProcessPDFs, null, 0, TimeSpan.FromMinutes(10).Milliseconds);
                _taskContainer = new TaskContainer(10);
                ProcessPDFs(null);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void ProcessPDFs(object state)
        {
            foreach(var file in System.IO.Directory.GetFiles(Directory))
            {
                PDFParser parser = new PDFParser(file);
                _taskContainer.AddAndRun(Task.Run(async () => await parser.ParseAndSave()));
            }
        }

        public bool Stop(HostControl hostControl)
        {
            try
            {
                _wordProcessor.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
