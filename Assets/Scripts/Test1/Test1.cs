using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class Test1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaEnv luaenv = new LuaEnv();
        luaenv.DoString("print('Hello World By print!')");
        luaenv.DoString("CS.UnityEngine.Debug.Log('Hello World By Debug.Log')");
        luaenv.Dispose();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
