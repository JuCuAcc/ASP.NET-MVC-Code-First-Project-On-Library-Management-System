using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Code_First_Jashim.Models
{
    public class BookIssue
    {
        [Key]
        public int IssueID { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date), DefaultValue("2021-11-04")]
        [Display(Name = "Issued Time")]
        public DateTime IssuedTime { get; set; }

        public virtual ICollection<BookIssueLog> BookIssueLog { get; set; }
        public virtual Books Books { get; set; }
        public virtual Members Members { get; set; }
        public virtual Books Liberian { get; set; }
    }
}