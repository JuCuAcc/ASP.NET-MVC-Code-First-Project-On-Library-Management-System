using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;


namespace Code_First_Jashim.Models
{
    public class StudentGroup
    {
        [Key]
        public int GroupID { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<Students> Students { get; set; }

    }
}