using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Sort
    {
        public int SortId { get; set; }
        [Required]
        [MaxLength(50)]
        public string SortName { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
