using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Operation
    {
        [Key]
        public int OperationId { get; set; }
        [MaxLength(50)]
        public string OperationName { get; set; }//操作名称
        [MaxLength(10)]
        public string Code { get; set; }//操作代码
    }
}
