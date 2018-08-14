using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAnalytics.Models;

namespace DataAnalytics.Models
{
    public class WatchListsBusiness
    {
        private static DBDataContext db = new DBDataContext();
        // 1--most-active
        // 2--gainers
        // 3--lowers
        public List<WatchList> GetWatchlists(int fromDate, int toDate)
        {
            var res = new List<WatchList>();

            try
            {
                var watchlists = db.usp_getwatchlists(fromDate, toDate).ToList();
                //System.Console.WriteLine(watchlists);
                foreach (var item in watchlists)
                {
                    WatchList watchList = new WatchList();
                    watchList.Symbol = item.symbol;
                    watchList.Change = ((decimal)item.close - (decimal)item.open) / (decimal)item.open;
                    watchList.Change = Math.Round(watchList.Change, 4);
                    watchList.ChangePercent = watchList.Change * 100;
                    watchList.Volume = (double)item.sum;
                    watchList.Dividends = (double)item.dividends;
                    res.Add(watchList);
                }
                //res = watchlists;
                return res;
            }
            catch (Exception e)
            {
                //
                return res;
            }
        }

    }
}