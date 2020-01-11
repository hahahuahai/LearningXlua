using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace Test
{
    public class CSharpClass
    {
        public CSharpClass()
        {
            s = "Init";
        }
        public string s { get; set; }

        public string CalledByLuaFunction()
        {
            s = "Hello World!";
            return s;
        }
    }

}


public class Test5 : MonoBehaviour
{
    LuaEnv luaEnv = null;
    // Start is called before the first frame update
    void Start()
    {
        luaEnv = new LuaEnv();
        luaEnv.DoString("require('Test5/Test5Lua')");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
