using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Code_First_Jashim.Custom_Validation
{
    public class CustomAddedDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);


            return dateTime <= DateTime.Now;
        }
    }
}