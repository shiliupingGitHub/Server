using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Base.Actor;
using System.IO;
namespace Base.HotFix
{
    public static class HotFix
    {
        public static void Reload()
        {
            Base.HotFix.HotFix.LoadHotFix("HotFix.dll", "HotFix.pdb");
        }
        public static void LoadHotFix(string dllPath,string pdbPath)
        {
          byte[] dlls =  File.ReadAllBytes(dllPath);
            byte[] pdbs = File.ReadAllBytes(pdbPath);
            Assembly assem = Assembly.Load(dlls,pdbs);
           Type[] ts =   assem.GetTypes();
            ActorDispacher.Instance.Clear();
            foreach (var t in ts)
            {
                ActorHandlerAttribute aa =t.GetCustomAttribute<ActorHandlerAttribute>();
                if(null != aa)
                {
                    ActorDispacher.Instance.AddHandler(aa.MsgType, t);
                }
            }
        }
    }
}
