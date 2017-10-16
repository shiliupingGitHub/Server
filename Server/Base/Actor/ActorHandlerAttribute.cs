using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Actor
{
  public  class ActorHandlerAttribute : Attribute
    {

        public Type MsgType
        {
            get
            {
                return mMsgType;
            }
        }
        Type mMsgType;

        public ActorHandlerAttribute( Type msgType)
        { 
            mMsgType = msgType;
        }
    }
}
