using System.Reflection;
using UnityEngine;
//https://blog.csdn.net/SendSI/article/details/84038522
/// <summary>
/// 反射 测试类   使用方法:把此类放在非Editor使用  也别使用namespace
/// </summary>

public class ClassMethodTool_Test
{
    public ClassMethodTool_Test()
    {
        if (PlayerPrefs.HasKey(GetType().Name) == false)
            Debuger.Log("此程序集=" + Assembly.GetExecutingAssembly().FullName);
        PlayerPrefs.SetString(GetType().Name, GetType().Name);
    }
    public void GetPerson()
    {
        Debuger.Log("此程序集=" + Assembly.GetExecutingAssembly().FullName + ",类名=MyTestNotify");
    }
    private void GetPersonPrivate()
    {
        Debuger.Log("私有的");
    }

    public void SetPersonName(string str)
    {
        Debuger.Log("传入的str=" + str);
    }
    public void SetPersonNameAndAge(int num, string str, TestDto dto, TestDto dto2)
    {
        Debuger.Log("传入的num=" + num + ",str=" + str + ",dto.mid=" + dto.mId + ",mName=" + dto.mName);
    }

    public void SetPerson(int age, bool isMan, string name)
    {
        Debuger.Log(name + "," + age + (isMan ? "岁,男" : "岁,女"));
    }

    public void SendTestNotify(TestDto dto, TestDto dto2)
    {
        Debuger.Log(dto.mId + "," + dto2.mName);//+","+dto.mName);
    }
}
public class TestDto
{
    //火id
    public long mId;
    //火名
    public string mName;
    //大小
    public int mRange;
    //全局否
    public bool mGlobal;
}
