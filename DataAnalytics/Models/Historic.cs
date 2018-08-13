using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAnalytics.Models
{
    public class Historic
    {
        private int _ID;

        private System.Nullable<int> _symbolID;

        private string _symbol;

        private System.Nullable<int> _Date;

        private System.Nullable<int> _Time;

        private System.Nullable<decimal> _Open;

        private System.Nullable<decimal> _High;

        private System.Nullable<decimal> _Low;

        private System.Nullable<decimal> _Close;

        private System.Nullable<decimal> _Volume;

        private System.Nullable<float> _SplitFactor;

        private System.Nullable<int> _Earnings;

        private System.Nullable<double> _Dividends;

        public int ID { get => _ID; set => _ID = value; }
        public int? SymbolID { get => _symbolID; set => _symbolID = value; }
        public string Symbol { get => _symbol; set => _symbol = value; }
        public int? Date { get => _Date; set => _Date = value; }
        public int? Time { get => _Time; set => _Time = value; }
        public decimal? Open { get => _Open; set => _Open = value; }
        public decimal? High { get => _High; set => _High = value; }
        public decimal? Low { get => _Low; set => _Low = value; }
        public decimal? Close { get => _Close; set => _Close = value; }
        public decimal? Volume { get => _Volume; set => _Volume = value; }
        public float? SplitFactor { get => _SplitFactor; set => _SplitFactor = value; }
        public int? Earnings { get => _Earnings; set => _Earnings = value; }
        public double? Dividends { get => _Dividends; set => _Dividends = value; }
    }
}