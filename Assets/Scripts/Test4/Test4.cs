using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class LuaClass
{
    public int f1;
    public int f2;
}

[CSharpCallLua]
public interface LuaInterface
{
    int f1 { get; set; }
    int f2 { get; set; }

    int add(int a, int b);
}

public class Test4 : MonoBehaviour
{
    LuaEnv luaEnv = null;
    [CSharpCallLua]
    public delegate int AddDelegate(int a, int b);

    // Start is called before the first frame update
    void Start()
    {
        luaEnv = new LuaEnv();
        luaEnv.DoString("require 'Test4/Test4Lua'");

        Debug.Log("lua a:" + luaEnv.Global.Get<int>("a"));
        Debug.Log("lua b:" + luaEnv.Global.Get<string>("b"));
        Debug.Log("lua c:" + luaEnv.Global.Get<bool>("c"));

        Debug.Log("lua t1.f1 by class:" + luaEnv.Global.Get<LuaClass>("t1").f1); //映射到普通class或struct,值拷贝
        Debug.Log("lua t1.f2 by class:" + luaEnv.Global.Get<LuaClass>("t1").f2); //映射到普通class或struct,值拷贝

        Debug.Log("lua t2.f1 by interface:" + luaEnv.Global.Get<LuaInterface>("t2").f1); //映射到一个interface,引用拷贝
        Debug.Log("lua t2.f2 by interface:" + luaEnv.Global.Get<LuaInterface>("t2").f2); //映射到一个interface,引用拷贝

        Debug.Log("lua t2.add by interface:" + luaEnv.Global.Get<LuaInterface>("t2").add(1, 2));//映射到一个interface,引用拷贝

        Debug.Log("lua t2.f1 by Dictionary:" + luaEnv.Global.Get<Dictionary<string, float>>("t2")["f1"]);  //更轻量级的by value方式：映射到Dictionary<>
        Debug.Log("lua t2.f2 by Dictionary:" + luaEnv.Global.Get<Dictionary<string, float>>("t2")["f2"]);  //更轻量级的by value方式：映射到Dictionary<>
        Debug.Log("lua t2 Count by Dictionary:" + luaEnv.Global.Get<Dictionary<string, float>>("t2").Count);  //更轻量级的by value方式：映射到Dictionary<>

        Debug.Log("lua t3 Count by List:" + luaEnv.Global.Get<List<double>>("t3").Count);  //更轻量级的by value方式：List<>

        Debug.Log("lua t2.f1 by LuaTable:" + luaEnv.Global.Get<LuaTable>("t2").Get<int>("f1")); //另外一种by ref方式：映射到LuaTable类
        Debug.Log("lua t2.f2 by LuaTable:" + luaEnv.Global.Get<LuaTable>("t2").Get<int>("f2")); //另外一种by ref方式：映射到LuaTable类

        Debug.Log("lua addLua by delegate:" + luaEnv.Global.Get<AddDelegate>("addLua")(10,20)); //访问一个全局的function,映射到delegate

        Debug.Log("lua addLua by LuaFunction:" + luaEnv.Global.Get<LuaFunction>("addLua").Call(12,22)[0]);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
