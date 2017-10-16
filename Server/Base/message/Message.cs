using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Actor;
namespace Base.Message
{
    public class Message 
    {
        Base.Actor.Actor mActor;
        public  virtual Base.Actor.Actor actor
        {
            get
            {
                return mActor;
            }

            set
            {
                mActor = value;
            }
        }
    }
}
