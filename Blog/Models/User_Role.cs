using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class User_Role
    {
        [Key]
        public int User_RoleId { get; set; }
        
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
