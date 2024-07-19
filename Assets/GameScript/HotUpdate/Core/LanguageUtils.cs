using UnityEngine;
using YooAsset;

// 多语言   简体 繁体  英语 ...
// 一.简体玩家只能与简体玩家一起玩. 简体.apk        繁体.apk
// 二.出apk默认 指定出 简体.apk   游戏内可切换,多种语言玩家一起玩  切换了语言,得重启apk
// 三.出apk默认指定出  简体.apk   游戏内可切换,多种语言玩家一起玩  切换了语言,可以不用重启,继续玩

//这里使用 第二种方案

/// <summary>
/// 多语言
/// 一.导表映射
///      1.1策划导表配了id,映射到Cfg_Language....  -->CfgLubanMgr.Instance.GetCurrLangCfgTxt()
///      1.2程序平时写代码 可以收集到中文 Script_Language....  -->CfgLubanMgr.Instance.GetCurrLangScriptTxt()
/// 二.fgui内置字  语言文件要在创建UI前载入，不支持实时切换语言文件。如果要在游戏中切换语言，那只能先销毁所有UI，卸载所有包。https://www.fairygui.com/docs/editor/i18n
/// https://github.com/SendSi/DataTable2Excel
/// </summary>
public class LanguageUtils : Singleton<LanguageUtils>
{
    private const string prefsKey = "currLang1";

    protected override void OnInit()
    {
        base.OnInit();
        var initLang = PlayerPrefs.GetString(prefsKey, "SimChinese");
        if (initLang != AppConfig.currLang)
        {
            AppConfig.currLang = initLang;
        }

        LoadFGUIPreContent(AppConfig.currLang);
    }

    //fgui内置字  语言文件要在创建UI前载入，不支持实时切换语言文件。如果要在游戏中切换语言，那只能先销毁所有UI，卸载所有包。  
    private void LoadFGUIPreContent(string language)
    {
        var assetPackage = YooAssets.TryGetPackage(AppConfig.defaultYooAssetPKG);//"DefaultPackage");
        var handle = assetPackage.LoadAssetAsync<TextAsset>(language);
        handle.Completed += (assetHandle =>
        {
            var fileContent = handle.AssetObject.ToString();
            FairyGUI.Utils.XML xml = new FairyGUI.Utils.XML(fileContent);
            FairyGUI.UIPackage.SetStringsSource(xml);
        });
    }

    public void ChangeLanguage(string pLang)
    {
        AppConfig.currLang = pLang;
        PlayerPrefs.SetString(prefsKey, AppConfig.currLang);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExecuteMenuItem("Edit/Play"); //停止运行
#else
        UnityEngine.Application.Quit();//若想不退出,打开着的fgui页面 需 卸了_重load一次
#endif
    }
}

// public void ModifyLanguage(LanguType pLT)
// {
//     EventCenter.Instance.Fire<LanguType>((int)EventEnum.EE_LanguageModify, pLT);
//     AppConfig.currLang = pLT.ToString();
//     PlayerPrefs.SetString(prefsKey, AppConfig.currLang);
// }

// public enum LanguType {
//     SimChinese, //简体中文SimChinese 
//     TraChinese, //繁体中文TraChinese
//     English, //英文English
// }