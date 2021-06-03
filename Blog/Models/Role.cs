using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [MaxLength(50)]
        public string RoleName { get; set; }
        [MaxLength(200)]
        public string RoleDesc { get; set; }
    }
}
