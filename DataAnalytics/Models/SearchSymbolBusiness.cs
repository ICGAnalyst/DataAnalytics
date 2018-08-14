using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAnalytics.Models
{
    public class SearchSymbolBusiness
    {
        private static DBDataContext db = new DBDataContext();

        public List<string> GetSearchSymbol(string searchKey)
        {
            List<string> searchSymbols = new List<string>();
            try
            {
                searchSymbols = (from s in db.symbols
                                 where s.symbol.StartsWith(searchKey)
                                 select s.symbol).ToList();
                return searchSymbols;
            }
            catch (Exception e)
            {
                //
                return searchSymbols;
            }
        }
    }
}