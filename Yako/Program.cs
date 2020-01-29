using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Yako
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new WebClient().DownloadString("http://www.example.com/?name=www.twitter.com");
                Console.WriteLine("OK");
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ReceiveFailure || e.Status == WebExceptionStatus.RequestCanceled)
                {
                    Console.WriteLine("RST");
                }
            }

            Console.ReadKey();
        }
    }
}
