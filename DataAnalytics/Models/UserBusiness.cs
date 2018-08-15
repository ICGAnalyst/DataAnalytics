using DataAnalytics.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAnalytics.Models
{
    public class UserBusiness
    {
        private static DBDataContext db = new DBDataContext();
        //验证user是否存在
        // 0--user不存在
        // 1--user已存在
        public int Verify(User user)
        {
            var res = (from s in db.User
                       where s.UserName == user.UserName
                       select s.UserId).Count();
            return res;
        }

        // -1--未知错误
        // 0--user已存在
        // id--操作成功
        public int Register(User user)
        {
            try { 
                int IsExist = Verify(user);
                if (IsExist >= 1)
                {
                    return 0;
                }
                DataAnalytics.User dbUser = new DataAnalytics.User();
                dbUser.UserName = user.UserName;
                dbUser.UserPass = MD5Util.GetMD5(user.UserPass);
                db.User.InsertOnSubmit(dbUser);
                db.SubmitChanges();
                return dbUser.UserId;
            }
            catch (Exception e)
            {
                //
                return -1;
            }
        }

        // -1--未知错误
        //  0--密码错误
        //  1--操作成功
        public int Login(User user)
        {
            try { 
                string encryptPass = MD5Util.GetMD5(user.UserPass);
                var res = (from s in db.User
                           where s.UserName == user.UserName
                            && s.UserPass == encryptPass
                           select s.UserId).Count();
                return res;
            }
            catch (Exception e)
            {
                //
                return -1;
            }
        }

        public int FindUserId(string username)
        {
            try
            {
                var res = (from s in db.User
                          where s.UserName == username
                          select s.UserId).ToList();
                if(res == null || res.Count() == 0)
                {
                    return -1;
                }
                return res[0];
            }
            catch (Exception e)
            {
                //
                return -1;
            }
        }
    }
}