using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Service
{
    public interface IVerificationCode
    {
        public string GetVerificationCode(string UUID);
        public bool CheckCode(string UUID, string code);
    }
}
