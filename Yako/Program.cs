using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Yako
{
    class Program
    {
        //curl https://pixiv.net/
        //curl: (35) schannel: failed to receive handshake, SSL/TLS connection failed

        //curl "http://www.example.com/?name=www.twitter.com
        //curl: (56) Recv failure: Connection was reset

        static void Main()
        {
            //try
            //{
            //    new WebClient().DownloadString("http://www.example.com/?name=www.twitter.com");
            //    Console.WriteLine("OK");
            //}
            //catch (WebException e)
            //{
            //    if (e.Status == WebExceptionStatus.ReceiveFailure || e.Status == WebExceptionStatus.RequestCanceled)
            //    {
            //        Console.WriteLine("RST");
            //    }
            //}

            try
            {
                var o = new HttpClient().GetStringAsync("https://pixiv.net/").Result;
                Console.WriteLine("OK");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }
    }
}
