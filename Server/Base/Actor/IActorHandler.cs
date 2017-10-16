using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Message;
namespace Base.Actor
{
   public interface IActorHandler
    {
        void  Handle(Base.Message.Message msg);
    }
}
