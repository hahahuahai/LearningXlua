using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;


public class Test2 : MonoBehaviour
{
    LuaEnv luaEnv = null;
    // Start is called before the first frame update
    void Start()
    {
        luaEnv = new LuaEnv();
        luaEnv.DoString("require 'Test2/main'");
    }

    // Update is called once per frame
    void Update()
    {
        if (luaEnv != null)
        {
            luaEnv.Tick();
        }
    }
}
