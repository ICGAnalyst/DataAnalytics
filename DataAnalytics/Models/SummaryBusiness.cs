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
                                 orderby  a.Date, a.Time
                                 select new { a.Date, a.Time, a.Open, a.High, a.Low, a.Close, a.Volume }).ToList();
                foreach (var item in resultSet)
                {
                    SummaryData summaryData = new SummaryData();
                    string str = item.Date.ToString();
                    DateTime dtime = DateTime.ParseExact(str, "yyyyMMdd", null);
                    long totalSeconds = (long) (dtime - new DateTime(1970, 1, 1)).TotalMilliseconds;
                    summaryData.DateTime = totalSeconds + (long)item.Time * 3600 * 1000;
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

        public List<SummaryData> GetSummaryData2(string symbol)
        {
            List<SummaryData> summaryDatas = new List<SummaryData>();
            try
            {
                var resultSet = (from a in db.AggsByDay
                                 join s in db.symbols
                                 on a.symbolID equals s.symbolID
                                 where s.symbol == symbol
                                 orderby a.Date
                                 select new { a.Date, a.Open, a.High, a.Low, a.Close, a.Volume }).ToList();
                foreach (var item in resultSet)
                {
                    SummaryData summaryData = new SummaryData();
                    string str = item.Date.ToString();
                    DateTime dtime = DateTime.ParseExact(str, "yyyyMMdd", null);
                    long totalSeconds = (long)(dtime - new DateTime(1970, 1, 1)).TotalMilliseconds;
                    summaryData.DateTime = totalSeconds;
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