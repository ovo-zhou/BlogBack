using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ApiModel
{
    public class UserWithApi
    {
        public int UserId { get; set; }
        public string NickName { get; set; }//昵称
        public string UserAvatar { get; set; }//头像
        public string Introduction { get; set; }//简介
        public string Motto { get; set; }//座右铭
    }
}
