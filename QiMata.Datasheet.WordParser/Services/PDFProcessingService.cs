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
        private Timer _wordProcessor;

        public bool Start(HostControl hostControl)
        {
            try
            {
                _wordProcessor = new Timer(ProcessPDFs, null, 0, TimeSpan.FromMinutes(10).Milliseconds);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void ProcessPDFs(object state)
        {
            
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
