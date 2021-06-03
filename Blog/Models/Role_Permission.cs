using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Role_Permission
    {
        [Key]
        public int Role_PermissionId { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        

    }
}
