using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Common
{
   public static class PingHost
    {
     
        public static bool getPingSatuts(string HostIp)
        {
            Ping pingSender = new Ping();
            PingReply r;
            r = pingSender.Send(HostIp);

            if (r.Status == IPStatus.Success)
            {
                return true;
            }
            else
                return false;
           
        }
    }
}
