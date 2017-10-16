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
        List<Base.Component.Component> mComponets = new List<Component.Component>();
        public STATUS Status { get; set; }
        public virtual void  SendMsg(Base.Message.Message msg)
        {
            msg.actor = this;
            mMails.Enqueue(msg);
            ActorDispacher.Instance.ReadyToHandle(this);
        }
        public virtual void AddComponent(Base.Component.Component cn)
        {
            if (!mComponets.Contains(cn))
            {
                mComponets.Add(cn);
                cn.mActor = this;
                cn.Awake();
            }
        }
        public virtual void RemoveComponent(Base.Component.Component cn)
        {
            if(mComponets.Contains(cn))
            {
                mComponets.Remove(cn);
                cn.OnDestory();
            }
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
