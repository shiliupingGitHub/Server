using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.common;
using Base.Message;
namespace Base.Actor
{
   
    public class ActorDispacher : SingleTon<ActorDispacher>
    {
        Dictionary<Type, IActorHandler> mHandler = new Dictionary<Type, IActorHandler>();
        List<Actor> mActors = new List<Actor>();
        public  void  ReadyToHandle(Actor a)
        {
            if (!mActors.Contains(a))
                mActors.Add(a);
            List<Actor> r = new List<Actor>();
            foreach(var t in mActors)
            {
                if(t.Status == Actor.STATUS.NONE)
                {
                    r.Add(t);
                    t.OnMessage();
                }
            }
            foreach(var t in r)
            {
                mActors.Remove(t);
            }
        }
        public void Clear()
        {
            mHandler.Clear();
        }
        public void AddHandler(Type msgType,Type handlerType)
        {
            IActorHandler handler = (IActorHandler) System.Activator.CreateInstance(handlerType);
            mHandler[msgType] = handler;
        }
       public IActorHandler GetHandler(Base.Message.Message msg)
        {
            Type type =  msg.GetType();
            IActorHandler ret = null;
            mHandler.TryGetValue(type, out ret);    
            return ret;
        }
    }
}
