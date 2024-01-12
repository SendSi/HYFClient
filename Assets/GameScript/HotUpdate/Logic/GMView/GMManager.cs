using System.Collections.Generic;
using Login;
using UnityEngine;

public class GMManager : Singleton<GMManager>
{
    private List<GMConfig> _typeListDto;
    private Dictionary<int, List<GMConfig>> _centerListDto;


    protected override void OnInit()
    {
        base.OnInit();
        _typeListDto = new List<GMConfig>();
        _centerListDto = new Dictionary<int, List<GMConfig>>();
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
    }

    public void ListenGM()
    {
        Debug.LogError("ListenGM");
        FairyGUI.Timers.inst.Add(1f, -1, (a) =>
        {
            if (Input.GetKey(KeyCode.F1))
            {
                Debug.LogError("F1");
                ProxyGMModule.Instance.OpenGMMainView();
            }
        });
    }

    public List<GMConfig> GetTypeList()
    {
        return _typeListDto;
    }

    public List<GMConfig> GetCenterList(int pType)
    {
        return _centerListDto[pType];
    }

    protected override void OnDispose()
    {
        base.OnDispose();
    }
}