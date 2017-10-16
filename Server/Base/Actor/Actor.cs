using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Message;
namespace Base.Actor
{
    
    public class Actor
    {
        Queue<Base.Message.Message> mMails = new Queue<Base.Message.Message>();
        public enum STATUS
        {
            NONE,
            WAITING,
            PROCESSING,
            
        }
        public STATUS Status { get; set; }
        public virtual void  SendMsg(Base.Message.Message msg)
        {
            msg.actor = this;
            mMails.Enqueue(msg);
            ActorDispacher.Instance.ReadyToHandle(this);
        }
        public virtual async void  OnMessage()
        {
            while(true)
            {
                if (mMails.Count > 0)
                {
                    Base.Message.Message m = mMails.Dequeue();
                    await Task.Run(() =>
                    {
                        Status = STATUS.PROCESSING;
                        IActorHandler handler = ActorDispacher.Instance.GetHandler(m);
                        if (null != handler)
                            handler.Handle(m);
                    });
                }
                else
                    break;
            }
        }
    }

 
}
