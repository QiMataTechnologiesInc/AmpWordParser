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
        public IEnumerable<StringSectionMatch> ComapreStringSections(FlattenedDatasheet datasheet1, FlattenedDatasheet datasheet2)
        {
            List<StringSectionMatch> matches = new List<StringSectionMatch>(datasheet1.FlattenedSections.Count * datasheet2.FlattenedSections.Count);
            Parallel.ForEach(datasheet1.FlattenedSections, x =>
                {
                    Parallel.ForEach(datasheet2.FlattenedSections, y =>
                        {
                            foreach(var section1 in x.StringSections)
                            {
                                foreach(var section2 in y.StringSections)
                                {
                                    if (section1.Id != section2.Id)
                                    {
                                        if (section1.StringHash == section2.StringHash && section1.StringLength == section2.StringLength)
                                        {
                                            matches.Add(new StringSectionMatch
                                            {
                                                Section1 = section1,
                                                Section2 = section2
                                            });
                                        }
                                    }
                                }
                            }
                        });
                });
            return matches; 
        }
    }
}
