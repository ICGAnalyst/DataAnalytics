using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAnalytics.Models
{
    public class Symbol
    {
        private int symbolId;

        private string symbolName;

        public int SymbolId { get => symbolId; set => symbolId = value; }
        public string SymbolName { get => symbolName; set => symbolName = value; }
    }
}