﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XfsGateServer
{
    class Program
    {
        static void Main(string[] args)
        {
            new XfsGateInit().Start();

            Console.ReadLine();


        }
    }
}