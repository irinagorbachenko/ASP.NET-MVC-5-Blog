using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Models
{
   // Represent a Comments entity

    public class Comment
    {
        [Key]
        public int CommentId { get; set; }


        [Display(Name = "Enter post id ")]
        public int PostID { get; set; }
        
        

        [Required]
        [Display(Name = " Name ")]
        public string CommentAuthorName { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Please enter a proper date.")]       
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name = " Date ")]
        public DateTime CommentDate { get; set; }

        [Required]
        [Display(Name = "Text ")]
        public string CommentBody { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}