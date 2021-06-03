using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }
        [MaxLength(50)]
        public string PermissionName { get; set; }
    }
}
