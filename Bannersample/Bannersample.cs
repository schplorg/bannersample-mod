using System;
using System.Reflection;
using TaleWorlds.Library;
using HarmonyLib;
namespace Bannersample
{
    public class Bannersample
    {
        private static Harmony harmony = new Harmony("de.schplorg.bannerfix");
        public static Exception Catch(Exception __exception){
          Bannersample.Log(__exception.Message + " " + __exception.StackTrace);
          return null;
        }
        
        public static void Rethrow(Exception __exception){
          Bannersample.Log(__exception.Message + " " + __exception.StackTrace);
          throw __exception;
        }
        public static void Finalize(string tOriginal, string mOriginal, string tFinalizer, string mFinalizer)
        {
            Type to = AccessTools.TypeByName(tOriginal);
            Type tp = AccessTools.TypeByName(tFinalizer);
            MethodInfo o = AccessTools.Method(to, mOriginal);
            MethodInfo p = AccessTools.Method(tp, mFinalizer);
            if(o == null){
                Log(to + "." +mOriginal+" null!");
                return;
            }
            if(p == null){
                Log(tp+ "." +mFinalizer+" null!");
                return;
            }
            harmony.Patch(o, null,null,null,new HarmonyMethod(p));
        }
        public static void Prefix(string tOriginal, string mOriginal, string tPrefix, string mPrefix)
        {
            Type to = AccessTools.TypeByName(tOriginal);
            Type tp = AccessTools.TypeByName(tPrefix);
            MethodInfo o = AccessTools.Method(to, mOriginal);
            MethodInfo p = AccessTools.Method(tp, mPrefix);
            
            if(o == null){
                Log(to + "." +mOriginal+" null!");
                return;
            }
            if(p == null){
                Log(tp+ "." +mPrefix+" null!");
                return;
            }
            harmony.Patch(o, new HarmonyMethod(p));
        }
        public static void Prefix(string tParent, string tOriginal, string mOriginal, string tPrefix, string mPrefix)
        {
            Type parent = AccessTools.TypeByName(tParent);
            Type to = AccessTools.Inner(parent,tOriginal);
            Type tp = AccessTools.TypeByName(tPrefix);
            MethodInfo o = AccessTools.Method(to, mOriginal);
            MethodInfo p = AccessTools.Method(tp, mPrefix);
            
            if(o == null){
                Log(to + "." +mOriginal+" null!");
                return;
            }
            if(p == null){
                Log(tp+ "." +mPrefix+" null!");
                return;
            }
            harmony.Patch(o, new HarmonyMethod(p));
        }
        public static void Log(string s){
            Debug.Print(s, 0, Debug.DebugColor.White, 17592186044416UL);
        }
    }
}