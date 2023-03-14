using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Common
{
    public static class GlobalVariables
    {
        public static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1);
        public static Boolean isTaken = false;
    }
}
