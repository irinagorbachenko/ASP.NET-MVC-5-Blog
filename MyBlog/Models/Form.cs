using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{    //Represent a Questionnaire entity
    public class Form
    {
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Ваша почта")]
        public string Email { get; set; }
        
        [Display(Name = "Давно ли вы на нашем сайте?")]
        public string Answer1{get; set;}
        [Display(Name = "Полезны ли были наши статьи?")]
        public string Answer2 { get; set; }
    }
}