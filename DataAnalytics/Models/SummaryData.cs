using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAnalytics.Models
{
    public class SummaryData
    {
        private int dateTime;

        private decimal open;

        private decimal high;

        private decimal low;

        private decimal close;

        private float volume;

        public int DateTime { get => dateTime; set => dateTime = value; }
        public decimal Open { get => open; set => open = value; }
        public decimal High { get => high; set => high = value; }
        public decimal Low { get => low; set => low = value; }
        public decimal Close { get => close; set => close = value; }
        public float Volume { get => volume; set => volume = value; }
    }
}