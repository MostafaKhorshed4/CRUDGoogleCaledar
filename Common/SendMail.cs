using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Common
{
   public interface SendMail
    {
        public Task<Boolean> Send(string ToMail);
        
    }
}
