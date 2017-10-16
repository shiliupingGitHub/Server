using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.common
{
  public  class SingleTon<T> where T:new()
     {
         static T mInstance;
        public static T Instance
        {
            get
            {
                if (null == mInstance)
                    mInstance = new T();
                return mInstance;
            }
        }
    }
}
