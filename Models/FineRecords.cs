using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_First_Jashim.Models
{
    public class FineRecords
    {

        public int ID { get; set; }
        public decimal FineAmount { get; set; }
        public int MemberID { get; set; }
        public int StudentID { get; set; }
        public int TeacherID { get; set; }

        public  virtual Members Members { get; set; }
        public  virtual Students Students { get; set; }
        public virtual Teachers Teachers { get; set; }

    }
}