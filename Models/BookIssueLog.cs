using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_First_Jashim.Models
{
    public class BookIssueLog
    {
        public int ID { get; set; }
        public DateTime IssuedTime { get; set; }
        public DateTime ReturnTime { get; set; }


        public int? MemberID { get; set; }
        public int IssueID { get; set; }
        public virtual Members Members { get; set; }
        public virtual BookIssue BookIssue { get; set; }


    }
}