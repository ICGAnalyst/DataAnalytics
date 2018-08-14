using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAnalytics.Models
{
    public class WatchRow
    {
        private int symbolId;

        private string symbol;

        private double open;

        private double close;

        private long volume;

        private int dividends;

        public int SymbolId { get => symbolId; set => symbolId = value; }
        public string Symbol { get => symbol; set => symbol = value; }
        public double Close { get => close; set => close = value; }
        public long Volume { get => volume; set => volume = value; }
        public int Dividends { get => dividends; set => dividends = value; }
        public double Open { get => open; set => open = value; }
    }
}