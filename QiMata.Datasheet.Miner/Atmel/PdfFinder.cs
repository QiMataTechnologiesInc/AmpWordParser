using HtmlAgilityPack;
using QiMata.Datasheet.Miner.I;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QiMata.Datasheet.Miner.Atmel
{
    public class PdfFinder : IPdfFinder
    {
        private const string Atmel = "http://www.atmel.com/";

        public async Task<IEnumerable<string>> GetPdfLinksAsync()
        {
            List<string> links = new List<string>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Atmel);
                client.DefaultRequestHeaders.Accept.Clear();


                HttpResponseMessage response = await client.GetAsync("search.aspx?filter=p&btnG=Search&site=en_collection&client=support_frontend&proxystylesheet=support_frontend&output=xml_no_dtd&getfields=*&oe=UTF-8&ie=UTF-8&ud=1&exclude_apps=1&num=1000&access=p&sort=date:D:L:d1&entqr=3&entqrm=0&lr=lang_en&q=+inmeta:asset_type~Datasheets");
                string resp = await response.Content.ReadAsStringAsync();

                HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

                // There are various options, set as needed
                htmlDoc.OptionFixNestedTags = true;

                htmlDoc.LoadHtml(resp);

                foreach(var item in htmlDoc.DocumentNode.SelectNodes("//a"))
                {
                    var firstHref = item.ChildAttributes("href").FirstOrDefault();
                    if (firstHref != null)
                    {
                        var link = firstHref.Value;
                        if (link.EndsWith(".pdf"))
                        {
                            if (link.StartsWith(Atmel))
                            {
                                links.Add(link);
                            }
                            else
                            {
                                links.Add(Atmel + link);
                            }
                        }
                    }
                }

            }
            return links;
        }

        public Models.Category Category
        {
            get
            {
                return new Models.Category
                    {
                        Name = "AtMegas",
                        ParentCategory = new Models.Category
                        {
                            Name = "Atmel"
                        }
                    };
            }
        }

    }
}
