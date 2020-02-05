﻿using System;
using System.Text;
using CurlSharp;

namespace Yako
{
    class Program
    {
        //curl https://pixiv.net/
        //curl: (35) schannel: failed to receive handshake, SSL/TLS connection failed

        //curl http://www.example.com/?name=www.twitter.com
        //curl: (56) Recv failure: Connection was reset

        static void Main()
        {
            try
            {
                Curl.GlobalInit(CurlInitFlag.All);
                using (var easy = new CurlEasy())
                {
                    easy.DnsUseGlobalCache = false;
                    easy.DnsCacheTimeout = 0;
                    //easy.SetOpt(CurlOption.DnsLocalIp4, "1.1.1.1");
                    easy.Url = "https://pixiv.net/";
                    easy.ConnectTimeout = 5;
                    easy.Timeout = 5;
                    easy.HeaderFunction = (buf, size, nmemb, data) => {
                        Console.Write(Encoding.UTF8.GetString(buf));
                        return size * nmemb;
                    };
                    easy.WriteFunction = (buf, size, nmemb, data) => {
                        Console.Write(Encoding.UTF8.GetString(buf));
                        return size * nmemb;
                    };
                    easy.Filetime = true;

                    var c = easy.Perform();
                    Console.WriteLine(c);
                    Console.WriteLine("Connect Time: {0}", easy.ConnectTime);
                    Console.WriteLine("Content Type: {0}", easy.ContentType);
                    Console.WriteLine("HTTP Connect Code: {0}", easy.HttpConnectCode);
                    Console.WriteLine("Name Lookup Time: {0}", easy.NameLookupTime);
                    Console.WriteLine("OS Errno: {0}", easy.OsErrno);
                    Console.WriteLine("Pretransfer time: {0}", easy.PreTransferTime);
                    Console.WriteLine("Redirect time: {0}", easy.RedirectTime);
                    Console.WriteLine("Response code: {0}", easy.ResponseCode);
                    Console.WriteLine("Ssl verification result: {0}", easy.SslVerifyResult);
                    Console.WriteLine("Start transfer time: {0}", easy.StartTransferTime);
                    Console.WriteLine("Total time: {0}", easy.TotalTime);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Curl.GlobalCleanup();
            }

            Console.ReadKey();
        }

    }
}
