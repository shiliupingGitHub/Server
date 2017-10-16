using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Component
{
   public class Component
    {
        public  virtual Base.Actor.Actor mActor { get; set; }
        public virtual void Awake() { }
        public virtual void OnEnable() { }
        public virtual void OnDisable() { }
        public virtual void OnDestory() { }
        bool mEnable = true;
        public virtual  bool Enable
        {
            set
            {
                if(mEnable != value)
                {
                    mEnable = value;
                    if (mEnable)
                        OnEnable();
                    else
                        OnDisable();
                }
            }
        }
    }
}
