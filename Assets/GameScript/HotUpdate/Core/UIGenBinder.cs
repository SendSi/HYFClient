﻿using AStarPKG;
using Bag;
using DialogTip;
using Login;
using MainCenter;
using MainRole;
using CommonPKG;
using GMView;
using GuidePKG;
using HeroPKG;
using HitHamsterPKG;
using PokerPKG;
using PuzzlePKG;
using SettingPKG;
using ShopGift;
using SpinePackage;
using Welfare;

public class UIGenBinder
{
    /// <summary> FairyGUI-Editor编辑器发布出的  要先绑定哦 </summary>
    public static void BindAll()
    {
        Debuger.LogWarning("--开始绑定自动生成的脚本--若没有执行OnInit(),看看此有无绑定---");
        LoginBinder.BindAll();
        MainCenterBinder.BindAll();
        DialogTipBinder.BindAll();
        BagBinder.BindAll();
        MainRoleBinder.BindAll();
        CommonPKGBinder.BindAll();
        GMViewBinder.BindAll();
        SettingPKGBinder.BindAll();
        WelfareBinder.BindAll();
        GuidePKGBinder.BindAll();
        PokerPKGBinder.BindAll();
        ShopGiftBinder.BindAll();
        SpinePackageBinder.BindAll();
        HeroPKGBinder.BindAll();
        HitHamsterPKGBinder.BindAll();
        AStarPKGBinder.BindAll();
        PuzzlePKGBinder.BindAll();
    }
}