using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace showmethecard.Models
{
    public class Member
    {
        public String mId { get; set; }
        public String password { get; set; }
        public String mName { get; set; }
        public String email { get; set; }
        public String phone { get; set; }
        public int mCount { get; set; }
        public int mPoint { get; set; }
        public String userType { get; set; }
        public bool deleted { get; set; }
        public DateTime regDate { get; set; }
        public int mLevel { get; set; }


    }
}