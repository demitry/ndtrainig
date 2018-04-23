using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            localhost.MathServiceClient obj = new DemoClient.localhost.MathServiceClient();
            localhost.Math mathobj = new DemoClient.localhost.Math();
            mathobj.Number1 = 10;
            mathobj.Number2 = 5;
            Console.WriteLine("Addition continues..");
            Console.WriteLine(obj.Addition(mathobj));
            Console.WriteLine("Subtraction continues..");
            Console.WriteLine(obj.Subtraction(mathobj));
            Console.ReadLine();
        }
    }
}
