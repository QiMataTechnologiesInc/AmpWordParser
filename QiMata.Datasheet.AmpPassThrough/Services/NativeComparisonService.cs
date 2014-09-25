using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QiMata.Datasheet.AmpPassThrough.Services
{
    class NativeStaticHelper
    {
        [DllImport("QiMata.Datasheet.AmpWordParser.dll", CallingConvention = CallingConvention.StdCall)]
        extern public static void CreateObjects();

        [DllImport("QiMata.Datasheet.AmpWordParser.dll", CallingConvention = CallingConvention.StdCall)]
        extern public static void SetDatasheetIds(int datasheet1Id, int datasheet2Id);

        [DllImport("QiMata.Datasheet.AmpWordParser.dll",CallingConvention = CallingConvention.StdCall)]
        extern public static void AddSection(int datasheetId, int sectionId, string sectionText, int stringHash, int stringLength, Guid id);

        [DllImport("QiMata.Datasheet.AmpWordParser.dll",CallingConvention = CallingConvention.StdCall)]
        extern public static void ComapreStringSections();
    }

    class NativeComparisonService : IComparisonService
    {
        

        public IEnumerable<Models.StringSectionMatch> ComapreStringSections(Models.FlattenedDatasheet datasheet1, Models.FlattenedDatasheet datasheet2)
        {
            NativeStaticHelper.CreateObjects();

            NativeStaticHelper.SetDatasheetIds(datasheet1.DataSheetId, datasheet2.DataSheetId);

            foreach(var section in datasheet1.FlattenedSections)
            {
                foreach(var stringSection in section.StringSections)
                {
                    NativeStaticHelper.AddSection(datasheet1.DataSheetId, section.SectionId, stringSection.String, stringSection.StringHash, stringSection.StringLength, stringSection.Id);
                }
            }

            foreach (var section in datasheet2.FlattenedSections)
            {
                foreach (var stringSection in section.StringSections)
                {
                    NativeStaticHelper.AddSection(datasheet2.DataSheetId, section.SectionId, stringSection.String, stringSection.StringHash, stringSection.StringLength, stringSection.Id);
                }
            }

            NativeStaticHelper.ComapreStringSections();


            throw new NotImplementedException();
        }
    }
}
