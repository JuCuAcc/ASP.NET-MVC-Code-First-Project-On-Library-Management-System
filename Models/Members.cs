using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;


namespace Code_First_Jashim.Models
{
    public class Members
    {
        [Key]
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string MemberStatus { get; set; }

        public virtual ICollection<Students> Students { get; set; }

        public virtual ICollection<Teachers> Teachers { get; set; }
        public virtual ICollection<BookIssue> BookIssue { get; set; }
        public virtual ICollection<BookIssueLog> BookIssueLog { get; set; }
        public virtual ICollection<FineRecords> FineRecords { get; set; }

    }
}