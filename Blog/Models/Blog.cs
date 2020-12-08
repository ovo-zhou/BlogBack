using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Blog
    {
        public int BlogId { get; set; }


        [Required]
        public DateTime? ReleaseDate { get; set; }


        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Title { get; set; }


        [Required]
        [MaxLength(5000)]
        public string Content { get; set; }


        public int LikeNum { get; set; }


        public int ViewNum { get; set; }

        //外键
        [Required]
        public int? SortId { get; set; }
        public Sort Sort { get; set; }
    }
}
