using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.HotFix;
using Server.Actor;
using Base.Message;
namespace Server
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Base.HotFix.HotFix.Reload();
            TestActor ta = new TestActor();
            TestMessage tm = new TestMessage();
            tm.mMsg = "start success";
            ta.SendMsg(tm);    
            while(true)
            {
               string test =  System.Console.ReadLine();
                if(test == "reload")
                {
                    Base.HotFix.HotFix.Reload();
                    tm.mMsg = "reaload sucess";
                    ta.SendMsg(tm);
                }
            }
        }
    }
}
