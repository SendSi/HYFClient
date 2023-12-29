using Bag;
using DialogTip;
using Login;
using MainCenter;
using MainRole;
using CommonPKG;
using UnityEngine;

public class UIGenBinder

{
    /// <summary> FairyGUI-Editor编辑器发布出的  要先绑定哦 </summary>
    public static void BindAll()
    {
        Debug.LogWarning("--开始绑定自动生成的脚本--");
        LoginBinder.BindAll();
        MainCenterBinder.BindAll();
        DialogTipBinder.BindAll();
        BagBinder.BindAll();
        MainRoleBinder.BindAll();
        CommonPKGBinder.BindAll();
    }
}
