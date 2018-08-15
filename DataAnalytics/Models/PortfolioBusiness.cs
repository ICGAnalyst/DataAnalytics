using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAnalytics.Models
{
    public class PortfolioBusiness
    {
        private static DBDataContext db = new DBDataContext();

        //symbolId: 以“,” 分割
        public int SavePortfolio(int userid, string symbolId)
        {
            int res = 0;
            try
            {
                string[] ids = symbolId.Split(',');

                res = 1;
                return res;
            }
            catch (Exception e)
            {
                return res;
            }
        }
    }
}