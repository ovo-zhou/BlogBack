using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string UserName { get; set; }


        [Column(TypeName = "varchar(20)")]
        public string NickName { get; set; }


        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Password { get; set; }

        [MaxLength(100)]
        public string UserAvatar { get; set; }
    }
}
