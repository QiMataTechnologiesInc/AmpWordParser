namespace QiMata.Datasheet.Dal.Ef
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Datasheet.Datasheet")]
    public partial class Datasheet
    {
        public Datasheet()
        {
            Sections = new HashSet<Section>();
        }

        public int DatasheetId { get; set; }

        [Required]
        public byte[] Pdf { get; set; }

        public DateTimeOffset DateSaved { get; set; }

        [Required]
        [StringLength(128)]
        public string PdfProvider { get; set; }

        [Required]
        [StringLength(256)]
        public string FilePath { get; set; }

        public virtual ICollection<Section> Sections { get; set; }
    }
}
