namespace QiMata.Datasheet.Dal.Ef
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Datasheet.Category")]
    public partial class Category
    {
        public Category()
        {
            Category1 = new HashSet<Category>();
        }

        public int CategoryId { get; set; }

        public int? ParentCategoryId { get; set; }

        [StringLength(128)]
        public string CategoryName { get; set; }

        public virtual ICollection<Category> Category1 { get; set; }

        public virtual Category Category2 { get; set; }
    }
}
