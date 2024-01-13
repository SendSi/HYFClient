using System.Collections.Generic;
using Login;
using UnityEngine;

public class GMManager : Singleton<GMManager>
{
    private List<GMConfig> _typeListDto;
    private Dictionary<int, List<GMConfig>> _centerListDto;
    private List<string> _oldReListDto;
    private const string prefsKey = "oldReKey";
    private string _oldReStrValue;

    protected override void OnInit()
    {
        base.OnInit();
        _typeListDto = new List<GMConfig>();
        _centerListDto = new Dictionary<int, List<GMConfig>>();
        _oldReListDto = new List<string>();
        var dicCfg = ConfigMgr.Instance.LoadConfigDics<GMConfig>();
        foreach (var item in dicCfg)
        {
            if (_centerListDto.ContainsKey(item.Value.tType) == false)
            {
                _centerListDto[item.Value.tType] = new List<GMConfig>();
                _typeListDto.Add(item.Value);
            }

            _centerListDto[item.Value.tType].Add(item.Value);
        }

        _oldReStrValue = PlayerPrefs.GetString(prefsKey, ""); //;; 两个分号切割
        var list = _oldReStrValue.Split(";;");
        foreach (var item in list)
        {
            if (string.IsNullOrEmpty(item) == false)
            {
                _oldReListDto.Add(item);
            }
        }
    }

    public void ListenGM()
    {
        FairyGUI.Timers.inst.Add(1.5f, -1, (a) =>
        {
            if (Input.GetKey(KeyCode.F1))
            {
                ProxyGMModule.Instance.OpenGMMainView();
            }
        });
    }

    public List<GMConfig> GetTypeList() { return _typeListDto; }

    public List<GMConfig> GetCenterList(int pType) { return _centerListDto[pType]; }

    public List<string> GetOldReList() { return _oldReListDto; }

    public void SetOldReValue(string str)
    {
        if (_oldReListDto.Contains(str) == false)
        {
            if (_oldReListDto.Count >= 30)
            {
                _oldReListDto.RemoveAt(_oldReListDto.Count - 1);
            }

            _oldReListDto.Insert(0, str);
            _oldReStrValue = "";
            foreach (var item in _oldReListDto)
            {
                _oldReStrValue += (item + ";;");
            }

            PlayerPrefs.SetString(prefsKey, _oldReStrValue); //;; 两个分号切割
        }
    }

    protected override void OnDispose() { base.OnDispose(); }

    public void LocalMethodGM(string inputTxtText)
    {
        var values = inputTxtText.Split(" ");
        var target = values[1]; //还有values[???]
        if (target != null)
        {
            if (target == "playSound")
            {
                PlaySound(values);
            } else if (target == "playVolume")
            {
                PlayVolume(values);
            } else if (target == "playEffect")
            {
                EffectLoader.Instance.LoadEffect_Id(values[2]);
            }
        }
    }

    private void PlayVolume(string[] values)
    {
        if (values[2] == "1")
        {
            var value = int.Parse(values[3]) * 0.01f;
            AudioMgr.Instance.SetBGMVolume(value);
        } else
        {
            var value = int.Parse(values[3]) * 0.01f;
            AudioMgr.Instance.SetMusicVolume(value);
        }
    }

    private void PlaySound(string[] values)
    {
        if (values[2] == "1")
        {
            AudioMgr.Instance.PlayBGM_Id(values[3]);
        } else
        {
            AudioMgr.Instance.PlayMusic_Id(values[3]);
        }
    }

    public void ServerMethodGM(string inputTxtText) { Debug.LogError("直接发送后端定义的"); }
}