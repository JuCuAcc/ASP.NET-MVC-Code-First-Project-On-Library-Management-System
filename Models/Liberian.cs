using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First_Jashim.Models
{
    public class Liberian
    {
        [Key]
        public int LiberianID { get; set; }
        public string LiberianName { get; set; }


        [Required(ErrorMessage = "Pleasee enter you Age")]
        [Range(20, 40, ErrorMessage = "Enter Age between 20 to 40")]
        public int Age { get; set; }


        [Required(ErrorMessage = "Pleasee enter your email address")]

        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; }

        [NotMapped]
        [Display(Name = "Confirme Email")]
        //[Compare("Email")]
        public string ConfirmedEmail { get; set; }
        public string Address { get; set; }
        public virtual ICollection<BookIssue> BookIssue { get; set; }

    }
}