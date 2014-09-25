using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiMata.Datasheet.Miner.Models
{
    public class Category
    {
        public string Name { get; set; }

        public Category ParentCategory { get; set; }
    }
}
