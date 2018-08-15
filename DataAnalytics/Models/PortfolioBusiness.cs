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
                // 插入PId-UserId, 返回PID
                DataAnalytics.Portfolio portfolio = new DataAnalytics.Portfolio();
                portfolio.UserId = userid;
                db.Portfolio.InsertOnSubmit(portfolio);
                db.SubmitChanges();
                int portfolioId = portfolio.PId;

                foreach(string id in ids)
                {
                    DataAnalytics.Relation relation = new DataAnalytics.Relation();
                    relation.PId = portfolioId;
                    relation.symbolID = int.Parse(id);
                    db.Relation.InsertOnSubmit(relation);
                    db.SubmitChanges();
                }
                res = 1;
                return res;
            }
            catch (Exception e)
            {
                return res;
            }
        }

        public Dictionary<int, List<Symbol>> GetPortfolio(int userid)
        {
            Dictionary<int, List<Symbol>> portfolios = new Dictionary<int, List<Symbol>>();
            try
            {
                var pids = (from s in db.Portfolio
                           where s.UserId == userid
                           select s.PId).ToList();

                if (pids == null || pids.Count() == 0)
                {
                    foreach (var pid in pids)
                    {
                        List<Symbol> symbols = new List<Symbol>();
                        var res = (from r in db.Relation
                                   join s in db.symbols
                                   on new { pid = r.PId, symbol = r.symbolID }
                                   equals new { pid = pid, symbol = s.symbolID }
                                   select new { s.symbolID, s.symbol }).ToList();
                        if (res == null || res.Count() == 0)
                        {
                            foreach (var item in res)
                            {
                                Symbol symbol = new Symbol();
                                symbol.SymbolName = item.symbol;
                                symbol.SymbolName = item.symbol;
                                symbols.Add(symbol);
                            }
                        }
                        portfolios.Add(pid, symbols);
                    }
                }
                return portfolios;
            }
            catch (Exception e)
            {
                return portfolios;
            }
        }
    }
}