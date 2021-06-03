using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        [MaxLength(100)]
        public string CoverImg { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Abstract { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        public string Content { get; set; }
        public int LikeNum { get; set; }

        public int ViewNum { get; set; }
        public int Top { get; set; }
        //外键
        [Required]
        public int SortId { get; set; }
        [JsonIgnore]
        public Sort Sort { get; set; }
    }
}
