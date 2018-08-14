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
        public List<WatchList> GetWatchlists(int fromDate, int toDate, int condition)
        {
            var res = new List<WatchList>();

            try
            {
                switch (condition)
                {
                    case 1:
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
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
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