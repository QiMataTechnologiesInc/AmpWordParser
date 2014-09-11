using QiMata.Datasheet.AmpPassThrough.Services;
using QiMata.Datasheet.Dal.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiMata.Datasheet.AmpPassThrough
{
    class Program
    {
        private static DatasheetContext _context = new DatasheetContext();

        static void Main(string[] args)
        {
            DataFlattenerService dataFlattenService = new DataFlattenerService();
            foreach(var datasheet in _context.Datasheets)
            {
                dataFlattenService.FlattenDatasheet(datasheet);
            }
        }
    }
}
