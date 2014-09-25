using QiMata.Datasheet.Miner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiMata.Datasheet.Miner.I
{
    interface IPdfFinder
    {
        Task<IEnumerable<string>> GetPdfLinksAsync();

        Category Category { get; }
    }
}
