using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace bknby.Modules
{
    public class ObjectsRefreshModule : IHttpModule
    {
        static Timer timer;
        const long Interval = 30000; //30 секунд
        static object _synclock = new object();
        static bool sent = false;

        public void Init(HttpApplication context)
        {
            timer = new Timer(RefreshObjects, null, 0, Interval);
        }

        private void RefreshObjects(object state)
        {
            lock (_synclock)
            {
                if (sent == false)
                {
                    string writePath = @"D:\\ath.txt";
                    string logs = @"D:\\logs.txt";
                    string text = DateTime.Now.ToShortTimeString();
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                        {
                            sw.WriteLine(text);
                        }
                    }
                    catch (Exception e)
                    {
                        using (StreamWriter sw = new StreamWriter(logs, false, System.Text.Encoding.Default))
                        {
                            sw.WriteLine(e.Message);
                        }
                        Console.WriteLine(e.Message);
                    }
                    sent = true;
                }
                else
                {
                    sent = false;
                }
            }
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}