using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Link
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string LinkIcon { get; set; }
        [Required]
        [MaxLength(50)]
        public string LinkName { get; set; }
        [Required]
        [MaxLength(150)]
        public string Url { get; set; }
    }
}
