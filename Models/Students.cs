using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;


namespace Code_First_Jashim.Models
{
    public class Students
    {
        [Key]
        public int StudentID { get; set; }

        public string StudentName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }


        public int GroupID { get; set; }

        public virtual ICollection<FineRecords> FineRecords { get; set; }

        public virtual StudentGroup StudentGroup { get; set; }
    }
}