using QiMata.Datasheet.AmpPassThrough.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiMata.Datasheet.AmpPassThrough.Services
{
    public interface IComparisonService
    {
        IEnumerable<StringSectionMatch> ComapreStringSections(FlattenedDatasheet datasheet);
    }
}
