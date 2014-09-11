using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiMata.Datasheet.AmpPassThrough.Models
{
    public class FlattenedSection
    {
        public int DatasheetId { get; set; }
        public int SectionId { get; set; }
        public ICollection<StringSection> StringSections { get; set; }
    }
}
