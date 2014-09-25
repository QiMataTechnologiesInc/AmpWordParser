using QiMata.Datasheet.AmpPassThrough.Models;
using QiMata.Datasheet.AmpPassThrough.Services;
using QiMata.Datasheet.Dal.Ef;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            IComparisonService service = new NativeComparisonService();
            List<FlattenedDatasheet> dataSheets = new List<FlattenedDatasheet>(5);
            foreach(var datasheet in _context.Datasheets.Include(x => x.Sections).OrderBy(x => x.DatasheetId).Take(5))
            {
                dataSheets.Add(dataFlattenService.FlattenDatasheet(datasheet));
            }
            foreach (var datasheet1 in dataSheets)
            {
                foreach (var datasheet2 in dataSheets)
                {
                    if (datasheet1 != datasheet2)
                    {
                        Console.WriteLine("Working on datasheet1: {0} datasheet2: {1}", datasheet1.DataSheetId, datasheet2.DataSheetId);
                        service.ComapreStringSections(datasheet1, datasheet2);
                    }
                }
            }
        }
    }
}
