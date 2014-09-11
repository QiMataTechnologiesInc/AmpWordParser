using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiMata.Datasheet.AmpPassThrough.Models
{
    public class FlattenedDatasheet
    {
        public int DataSheetId { get; set; }
        public ICollection<FlattenedSection> FlattenedSections { get; set; }
    }
}
