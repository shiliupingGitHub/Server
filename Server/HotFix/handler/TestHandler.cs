using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Actor;
using Base.Message;
namespace HotFix.handler
{
    [ActorHandler(typeof(TestMessage))]
    public class TestHandler : IActorHandler
    {
        public void  Handle(Message msg)
        {
            TestMessage tm = msg as TestMessage;
            System.Console.WriteLine(tm.mMsg+"1");
            tm.actor.Status = Actor.STATUS.NONE;
        }
    }
}
