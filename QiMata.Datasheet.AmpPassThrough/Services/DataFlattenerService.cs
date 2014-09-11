using QiMata.Datasheet.AmpPassThrough.Models;
using QiMata.Datasheet.Dal.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiMata.Datasheet.AmpPassThrough.Services
{
    public class DataFlattenerService
    {
        public FlattenedDatasheet FlattenDatasheet(Datasheet.Dal.Ef.Datasheet datasheet)
        {
            FlattenedDatasheet flatDatasheet = new FlattenedDatasheet
            {
                DataSheetId = datasheet.DatasheetId,
                FlattenedSections = new List<FlattenedSection>(datasheet.Sections.Count)
            };

            foreach(var section in datasheet.Sections)
            {
                flatDatasheet.FlattenedSections.Add(this.FlattenSection(section));
            }

            return flatDatasheet;
        }

        public FlattenedSection FlattenSection(Section section)
        {
            var words = section.SectionText.Split(' ');
            FlattenedSection flatSection = new FlattenedSection
            {
                SectionId = section.SectionId,
                DatasheetId = section.DatasheetId,
                StringSections = new List<StringSection>(words.Length * (words.Length -1))
            };

            for (int i = 0; i < words.Length; i++)
            {
                StringBuilder builder = new StringBuilder();
                //add all words before to before this string and save
                for (int j = i; j > -1; j--) //iterate backwards from current word to beginning
                {
                    builder.Insert(0,words[j]); //add the word at j
                    flatSection.StringSections.Add(FlattenWord(builder.ToString(),section.DatasheetId,flatSection.SectionId));
                    builder.Insert(0, ' ');
                }

                builder.Clear();
                //add all words to after this string and save
                for (int j = i; j < words.Length; j++)
                {
                    builder.Append(words[j]);
                    flatSection.StringSections.Add(FlattenWord(builder.ToString(),section.DatasheetId,section.SectionId));
                    builder.Append(' ');
                }
            }

            return flatSection;
        }

        private StringSection FlattenWord(string p,int datasheetId,int sectionId)
        {
            return new StringSection
            {
                String = p,
                Id = Guid.NewGuid(),
                StringHash = p.GetHashCode(),
                StringLength = p.Length,
                DatasheetId = datasheetId,
                SectionId = sectionId
            };
        }
    }
}
