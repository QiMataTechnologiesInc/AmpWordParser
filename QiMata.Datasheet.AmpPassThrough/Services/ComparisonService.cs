using QiMata.Datasheet.AmpPassThrough.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiMata.Datasheet.AmpPassThrough.Services
{
    public class ComparisonService : IComparisonService
    {
        public IEnumerable<StringSectionMatch> ComapreStringSections(FlattenedDatasheet datasheet)
        {
            List<StringSectionMatch> matches = new List<StringSectionMatch>(datasheet.FlattenedSections.Count * datasheet.FlattenedSections.First().StringSections.Count);
            foreach(var section in datasheet.FlattenedSections)
            {
                Parallel.ForEach(section.StringSections, x =>
                    {
                        Parallel.ForEach(section.StringSections, y =>
                            {
                                if (x.Id != y.Id)
                                {
                                    if (x.StringHash == y.StringHash && x.StringLength == y.StringLength)
                                    {
                                        matches.Add(new StringSectionMatch
                                            {
                                                Section1 = x,
                                                Section2 = y
                                            });
                                    }
                                }
                            });
                    });
            }
            return matches; 
        }
    }
}
