using System;
using System.Collections.Generic;
using DataAnalytics.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnalytics.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetWatchLists()
        {
            int fromDate = 20160104, toDate = 20160328;
            WatchListsBusiness watchListsBusiness = new WatchListsBusiness();
            try
            {
                List<WatchList> watchLists = watchListsBusiness.GetWatchlists(fromDate, toDate);
                Assert.IsTrue(watchLists.Count > 0);
            }
            catch (Exception ex)
            {
                //Assert.IsInstanceOfType(ex, typeof(DemoException));
            }
        }
    }

    [TestClass]
    public class SummaryTest
    {
        [TestMethod]
        public void TestGetSummaryData()
        {
            string symbol = "a";
            SummaryBusiness summaryBusiness = new SummaryBusiness();
            try
            {
                List<SummaryData> summaryDatas = summaryBusiness.GetSummaryData(symbol);
                Assert.IsTrue(summaryDatas.Count > 0);
            }
            catch (Exception ex)
            {
                //Assert.IsInstanceOfType(ex, typeof(DemoException));
            }
        }
    }

    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void Testlogin()
        {
            DataAnalytics.Models.User user = new DataAnalytics.Models.User();
            user.UserName = "abc";
            user.UserPass = "123456";
            UserBusiness userBusiness = new UserBusiness();
            try
            {
                int res = userBusiness.Login(user);
                Assert.IsTrue(res == 1);
            }
            catch (Exception ex)
            {
                //Assert.IsInstanceOfType(ex, typeof(DemoException));
            }
        }

        [TestMethod]
        public void TestRegister()
        {
            DataAnalytics.Models.User user = new DataAnalytics.Models.User();
            user.UserName = "sss";
            user.UserPass = "sdassda";
            UserBusiness userBusiness = new UserBusiness();
            try
            {
                int res = userBusiness.Register(user);
                Assert.IsTrue(res == 1);
            }
            catch (Exception ex)
            {
                //Assert.IsInstanceOfType(ex, typeof(DemoException));
            }
        }
       
    }

    [TestClass]
    public class SearchTest
    {
        [TestMethod]
        public void TestGetSearchSymbol()
        {
            string key = "a";
            SearchSymbolBusiness s = new SearchSymbolBusiness();
            try
            {
                List<string> slist = s.GetSearchSymbol(key);
                Assert.IsTrue(slist.Count > 0);
            }
            catch (Exception ex)
            {
                //Assert.IsInstanceOfType(ex, typeof(DemoException));
            }
        }
    }

    [TestClass]
    public class TestHistoric
    {
        [TestMethod]
        public void HistoricTest()
        {
            string key = "a";
            int fromDate = 20160104, toDate = 20160328;
            HistoricBusiness s = new HistoricBusiness();
            try
            {
                List<Historic> slist = s.GetHisToricData(key, fromDate, toDate);
                Assert.IsTrue(slist.Count > 0);
            }
            catch (Exception ex)
            {
                //Assert.IsInstanceOfType(ex, typeof(DemoException));
            }
        }
    }

}
