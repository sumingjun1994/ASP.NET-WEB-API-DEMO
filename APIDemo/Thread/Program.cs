using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessAndThread
{
    class Program
    {
        //static void Test(int i)
        //{
        //    Console.WriteLine("TEST"+i);
        //}
        static int Test(int i)
        {
            Console.WriteLine("TEST"+i);
            //Thread.Sleep(500);
            return 100;
        }
        static void Main(string[] args)
        {
            ////通过委托开启一个线程
            //Action<int> a = Test;
            ////开启新线程执行a所引用的方法
            //a.BeginInvoke(6,null, null);
            //Console.WriteLine("Main Thread");

            //Func<int, int> a = Test;
            //IAsyncResult ar = a.BeginInvoke(58, null, null);
            //Console.WriteLine("Main Thread");
            //while (ar.IsCompleted==false)
            //{
            //    Console.Write(".");
            //}

            //int res = a.EndInvoke(ar);
            //Console.WriteLine(res);

            //bool isEnd= ar.AsyncWaitHandle.WaitOne(1000);
            //if (isEnd)
            //{
            //    int res = a.EndInvoke(ar);
            //    Console.WriteLine(res);
            //}
            Func<int, int> a = Test;
            IAsyncResult ar = a.BeginInvoke(58, OnCallback, a);
            Console.ReadKey();
        }

        static void OnCallback(IAsyncResult ar)
        {
            Func<int, int>  a=ar.AsyncState as Func<int, int>;
            int res = a.EndInvoke(ar);
            Console.WriteLine(res);
        }
    }
}
