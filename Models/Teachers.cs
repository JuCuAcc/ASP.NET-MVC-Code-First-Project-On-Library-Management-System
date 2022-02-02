using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First_Jashim.Models
{
    public class Teachers
    {
        [Key]
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }


        public virtual ICollection<FineRecords> FineRecords { get; set; }


    }
}