using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAnalytics.Models
{
    public class WatchList
    {
        private string symbol;

        private decimal change;

        private decimal changePercent;

        private double volume;

        private double dividends;

        public string Symbol { get => symbol; set => symbol = value; }
        public decimal Change { get => change; set => change = value; }
        public decimal ChangePercent { get => changePercent; set => changePercent = value; }
        public double Volume { get => volume; set => volume = value; }
        public double Dividends { get => dividends; set => dividends = value; }
    }
}