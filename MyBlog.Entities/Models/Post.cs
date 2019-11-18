using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities.Models
{
    //Represent a Post entity

    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        [Display(Name = " Name ")]
        public string AuthorName { get; set; }

        [Required]
        [DisplayName("Date")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a proper date.")]                
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PostDate { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Post Title ")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Post Text ")]
        public string PostBody { get; set; }


        [Display(Name = "Tags ")]
        public string PostTag { get; set; }

        public ICollection<Comment> Comments { get; set; }
       

    }
}

