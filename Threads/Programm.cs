﻿using System;
using System.Threading;
using static Threads.SimpleThread;
using static Threads.ThreadPools;

namespace Tutorial
{
    public static class Tutorial
    {
       
        public static void Main()
         {
             //Threads.SimpleThread.CallExample();
            //  Threads.SimpleThread.CallExampleThreadLocal();
             Threads.ThreadPools.Example();
             //CallExampleBackGroundProcess
         }

    }
}
