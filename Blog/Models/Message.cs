using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }
        [Required]
        [MaxLength(50)]
        public string Contact { get; set; }
        public DateTime? Date { get; set; }
    }
}
