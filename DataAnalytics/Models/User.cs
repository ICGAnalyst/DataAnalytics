using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAnalytics.Models
{
    public class User
    {
        private int _UserId;

        private string _UserName;

        private string _UserPass;

        public int UserId { get => _UserId; set => _UserId = value; }
        public string UserName { get => _UserName; set => _UserName = value; }
        public string UserPass { get => _UserPass; set => _UserPass = value; }
    }
}