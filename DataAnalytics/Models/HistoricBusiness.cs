using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAnalytics.Models
{
    public class HistoricBusiness
    {
        public List<Historic> GetHisToricData(string symbolKey, int fromDate, int toDate)
        {
            List<Historic> historics = new List<Historic>();
            try
            {
                var db = new DBDataContext();

                var symbolIds = (from s in db.symbols
                                 where s.symbol == symbolKey
                                 select s.symbolID).ToList();
                int symbolId = symbolIds[0];
                var resHour = (from s in db.AggsByHour
                               where s.symbolID == symbolId
                                     && s.Date >= fromDate
                                     && s.Date <= toDate
                               select new { s.ID, s.Date, s.Open, s.High, s.Low, s.Close, s.Volume }).ToList();

                int count = 0;
                int len = resHour.Count();
                for (count = 0; count < len;)
                {
                    int curDate = (int)resHour[count].Date;
                    decimal open = 0, high = 0, low = 0, close = 0;
                    long volume = 0;
                    for (int i = 0; i < 7; i++, count++)
                    {
                        if (i == 0)
                        {
                            open = (decimal)resHour[count].Open;
                        }
                        if (i == 6)
                        {
                            close = (decimal)resHour[count].Close;
                        }

                        high = (decimal)resHour[count].High > high ? (decimal)resHour[count].High : high;
                        low = (decimal)resHour[count].Low > low ? (decimal)resHour[count].Low : low;
                        volume += (long)resHour[count].Volume;
                    }
                    Historic historic = new Historic();
                    historic.SymbolID = symbolId;
                    historic.Date = resHour[count - 7].Date;
                    historic.Symbol = symbolKey;
                    historic.Open = open;
                    historic.High = high;
                    historic.Low = low;
                    historic.Close = close;
                    historic.Volume = volume;

                    historics.Add(historic);
                }
                //System.Console.WriteLine(historics);
                return historics;
            }
            catch (Exception e)
            {
                return historics;
            }
        }
    }
}