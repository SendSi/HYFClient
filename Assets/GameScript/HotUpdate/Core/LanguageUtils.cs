using UnityEngine;
using YooAsset;

/// <summary>
/// 多语言
/// 一.导表映射
///      1.1策划导表配了id,映射到Cfg_SimChinese....  -->ConfigMgr.Instance.GetCurrLangCfgTxt("1001")
///      1.2程序平时写代码 可以收集到中文 Script_SimChinese....  -->ConfigMgr.Instance.GetCurrLangScriptTxt("1001")
/// 二.fgui内置字  语言文件要在创建UI前载入，不支持实时切换语言文件。如果要在游戏中切换语言，那只能先销毁所有UI，卸载所有包。https://www.fairygui.com/docs/editor/i18n
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

    private void LoadFGUIPreContent(string language)
    {
        var assetPackage = YooAssets.TryGetPackage("DefaultPackage");
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
      UnityEditor.EditorApplication.ExecuteMenuItem("Edit/Play");//停止运行
#else
        UnityEngine.Application.Quit();
#endif
    }
}

// public void ModifyLanguage(LanguType pLT)
// {
//     EventCenter.Instance.Fire<LanguType>(EventEnum.EE_LanguageModify, pLT);
//     AppConfig.currLang = pLT.ToString();
//     PlayerPrefs.SetString(prefsKey, AppConfig.currLang);
// }

// public enum LanguType {
//     SimChinese, //简体中文SimChinese 
//     TraChinese, //繁体中文TraChinese
//     English, //英文English
// }