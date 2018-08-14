using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAnalytics.Models
{
    public class SummaryBusiness
    {
        private static DBDataContext db = new DBDataContext();

        public List<SummaryData> GetSummaryData(string symbol)
        {
            List<SummaryData> summaryDatas = new List<SummaryData>();
            try { 
                var resultSet = (from a in db.AggsByHour
                                 join s in db.symbols
                                 on a.symbolID equals s.symbolID
                                 where s.symbol == symbol
                                 select new { a.Date, a.Time, a.Open, a.High, a.Low, a.Close, a.Volume }).ToList();
                foreach (var item in resultSet)
                {
                    SummaryData summaryData = new SummaryData();
                    summaryData.DateTime = (int) (item.Date * 100 + item.Time);
                    summaryData.Open = (decimal)item.Open;
                    summaryData.High = (decimal)item.High;
                    summaryData.Low = (decimal)item.Low;
                    summaryData.Close = (decimal)item.Close;
                    summaryData.Volume = (float)item.Volume;
                    summaryDatas.Add(summaryData);
                }
                return summaryDatas;
            }
            catch (Exception e)
            {
                return summaryDatas;
            }
        }
    }
}