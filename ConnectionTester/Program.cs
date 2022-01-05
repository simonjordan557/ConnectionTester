using System;
using System.Threading;
using System.Net.NetworkInformation;

namespace ConnectionTester
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("TESTING CONNECTION...");
            Ping p = new Ping();
            PingReply? reply;
            double success = 0;
            double fail = 0;
          
            
            
        

            while (true)
            {
                try
                {
                    reply = p.Send("143.204.68.45", 10000);
                }

                catch
                {
                    reply = null;
                }

                
                
                if (reply == null)
                {
                    Console.WriteLine($"{DateTime.Now.ToLongTimeString()}\t\tNULL");
                }
                else if (reply.Status == IPStatus.Success)
                {
                    success++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{DateTime.Now.ToLongTimeString()}\t\tY");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\t\t{SuccessRatio(success, fail)}% SUCCESS RATE ({fail} failures out of {fail + success} attempts)");
                }

                else
                {
                    fail++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{DateTime.Now.ToLongTimeString()}\t\tN: {reply.Status}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\t\t{SuccessRatio(success, fail)}% SUCCESS RATE ({fail} failures out of {fail + success} attempts)");
                    
                }

                Thread.Sleep(30000);
            }
        }

        private static string SuccessRatio(double s, double f)
        {
            return ((int)((s / (s + f)) * 100)).ToString();
        }
    
    }

}
