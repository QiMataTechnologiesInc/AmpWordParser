namespace QiMata.Datasheet.Dal.Ef
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Datasheet.Section")]
    public partial class Section
    {
        public Section()
        {
            Section1 = new HashSet<Section>();
        }

        public int SectionId { get; set; }

        public string SectionText { get; set; }

        public byte[] SectionImage { get; set; }

        public int? ParentSectionId { get; set; }

        public int DatasheetId { get; set; }

        public virtual Datasheet Datasheet { get; set; }

        public virtual ICollection<Section> Section1 { get; set; }

        public virtual Section Section2 { get; set; }
    }
}
