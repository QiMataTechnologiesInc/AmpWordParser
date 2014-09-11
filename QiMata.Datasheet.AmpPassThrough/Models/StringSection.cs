using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiMata.Datasheet.AmpPassThrough.Models
{
    public class StringSection
    {
        public Guid Id { get; set; }

        public int StringHash { get; set; }

        public int StringLength { get; set; }

        public int DatasheetId { get; set; }

        public int SectionId { get; set; }

        public string String { get; set; }
    }
}
