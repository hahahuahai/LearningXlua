using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class Test3 : MonoBehaviour
{
    LuaEnv luaEnv = new LuaEnv();
    // Start is called before the first frame update
    void Start()
    {
        luaEnv = new LuaEnv();
        luaEnv.AddLoader(loader);
        luaEnv.DoString("require 'Test3/Test3Main'");
    }

    // Update is called once per frame
    void Update()
    {

    }

    byte[] loader(ref string filename)
    {
        Debug.Log("filename:" + filename);
        if (filename == "Test3")
        {
            string script = "return {test3 = 'test3 Hello World!'}";
            return System.Text.Encoding.UTF8.GetBytes(script);
        }
        return null;
    }
}
