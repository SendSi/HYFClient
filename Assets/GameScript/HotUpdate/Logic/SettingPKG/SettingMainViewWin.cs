using FairyGUI;
using SettingPKG;
using UnityEngine;

public class SettingMainViewWin : Window
{
    private SettingMainView mView;

    protected override void OnInit()
    {
        base.OnInit();
        this.contentPane = SettingMainView.CreateInstance();
        this.Center();
        this.modal = true;

        mView = this.contentPane as SettingMainView;
        mView._bgmSbr.onChanged.Set(OnChangeBgmValue);
        mView._musicSbr.onChanged.Set(OnChangeMusicValue);
        // Debug.LogError($"{AppConfig.bgmVolume}      {AppConfig.musicVolume}");
        mView._bgmSbr.value = (int)(AppConfig.bgmVolume * 100);
        mView._musicSbr.value = (int)(AppConfig.musicVolume * 100);

        mView._switchSccountsBtn.onClick.Set(OnClickLogOut);
    }

    private void OnClickLogOut()
    {
        ProxyCommonPKGModule.Instance.AddToastStr("登出操作 成功");
        ProxyLoginModule.Instance.OpenLoginMainView();
        ProxyMainCenterModule.Instance.CloseMainCenterView();
    }

    private void OnChangeMusicValue()
    {
        var value = (float)(mView._musicSbr.value * 0.01f);
        AudioMgr.Instance.SetMusicVolume(value);
    }

    private void OnChangeBgmValue()
    {
        var value = (float)(mView._bgmSbr.value * 0.01f);
        AudioMgr.Instance.SetBGMVolume(value);
    }

    protected override void closeEventHandler(EventContext context)
    {
        base.closeEventHandler(context);
        AudioMgr.Instance.SaveSoundPrefsKey();//关闭页面 保存下咯
    }
}