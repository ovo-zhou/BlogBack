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
        [Key]
        public int UserId { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string UserName { get; set; }//用户名
        [Column(TypeName = "varchar(20)")]
        public string NickName { get; set; }//昵称
        [EmailAddress]
        public string Email { get; set; }//邮箱
        [Phone]
        public string Phone { get; set; }//手机
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Password { get; set; }//密码
        public bool Status { get; set; }//状态
        [Required]
        public DateTime RegTime { get; set; }//注册时间
        [Required]
        public DateTime LoginTime { get; set; }//登陆时间
        [MaxLength(20)]
        public string Ip { get; set; }//登录IP
        [MaxLength(200)]
        public string UserAvatar { get; set; }//头像
        [MaxLength(2048)]
        public string Introduction { get; set; }//简介
        [MaxLength(100)]
        public string Motto { get; set; }//座右铭
    }
}
