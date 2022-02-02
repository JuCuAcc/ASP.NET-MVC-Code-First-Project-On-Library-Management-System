using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_First_Jashim.Models
{
    public class ReservedBook
    {
        public int ID { get; set; }
        public DateTime AddedTime { get; set; }
        public int NumberOfBooks { get; set; }

        public int CategoryID { get; set; }

        public virtual BookCategories BookCategories { get; set; }

    }
}