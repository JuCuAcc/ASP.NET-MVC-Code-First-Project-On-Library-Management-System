using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Code_First_Jashim.Custom_Validation;

namespace Code_First_Jashim.Models
{
    public class Books
    {
        [Key]
        [Required(ErrorMessage = "BookID is Required.")]
        public int BooksID { get; set; }

        [Required(ErrorMessage = "Book Name must be supplied.")]

        public string Title { get; set; }

        [Required(ErrorMessage = "Author Name is Necessary.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Short Description is necessary.")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Description must be in between 4 to 15 charecters.")]

        public string Description { get; set; }


        [Required]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date),DefaultValue("2021-11-04")] 
        [Display(Name = "Added Time ")]

        public DateTime AddedTime { get; set; }
        public int CategoryID { get; set; }

        [DisplayName("Availability Status"), DefaultValue("Available")]
        public Nullable<bool> Availability
        {
            get;
            set;
        }

        public string IsAvailability
        {
            get
            {
                return (bool)this.Availability ? "Available" : "Unavailable";
            }
        }

        [DisplayName("Image")]
        public string ImagePath { get; set; }

        public virtual ICollection<BookIssue> BookIssue { get; set; }

        public virtual BookCategories BookCategories { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }


        public Books()
        {
            ImagePath = "~/Images/default.png";
        }
    }
}