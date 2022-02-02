using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;


namespace Code_First_Jashim.Models
{
    public class BookCategories
    {
        [Key]
        public int CategoryID { get; set; }
        public string Category { get; set; }

        public virtual ICollection<Books> Books { get; set; }

    }
}