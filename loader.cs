using System;
using UnityEngine;

namespace YourMenuName
{
    public class Loader // you can change this whatever you want its my default name on my menus
    {
        public static void Init() //this can be changed too 
        {
            Loader.Load = new UnityEngine.GameObject();
            Loader.Load.AddComponent<Mod>(); // the <Mod> thing can be changed too its linked to mod.cs file (if you want to change you need to change mod.cs name)
            UnityEngine.Object.DontDestroyOnLoad(Loader.Load);
        }
        public static void Unload() //this is optional for unloading the menu but if you want its there
        {
            GameObject.Destroy(Load);
        }

        private static GameObject Load;
    }
}
