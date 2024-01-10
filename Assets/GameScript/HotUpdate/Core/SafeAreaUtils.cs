using FairyGUI;
using UnityEngine;

/// <summary>
/// 浏海屏 处理
/// Android 版本: 安卓操作系统版本也对 Screen.safeArea 的可用性有一些影响。具体来说，Android 9.0（API 级别 28）及以上版本对 Screen.safeArea 提供更好的支持。
/// 当今手机 应该不会有太低版本来玩了吧....
/// </summary>
public class SafeAreaUtils : MonoBehaviour
{
    // public static SafeAreaUtils Instance;//单例  但好像用不着哦

    private Rect _safeArea; // 根据 safeArea 调整 UI 元素的位置和大小   
    private ScreenOrientation _currOrient;
    private Vector2 _uiScreenSize;

    private void Awake()
    {
        // Instance = this;
        _safeArea = Screen.safeArea;
        _currOrient = Screen.orientation;
    }

    private float _widthScale;
    // private float _heightScale;

    void Start()
    {
        _uiScreenSize = GRoot.inst.size;
        _widthScale = _uiScreenSize.x / Screen.width;
        // _heightScale = _uiScreenSize.y / Screen.height;
        // Debug.LogError($"size:{_uiScreenSize}   Screen:{Screen.width}_{Screen.height}    value:{_widthScale}_{_heightScale}");
        CheckScreenOrientation();
    }

    //挖孔在左
    void SetLandscapeLeft()
    {
        var left = _safeArea.x * _widthScale;
        var width = _safeArea.width * _widthScale;
        var height = _uiScreenSize.y;
        GRoot.inst.SetSize(width, height);
        GRoot.inst.SetXY(left * GRoot.inst.scaleX, 0);
    }

    //挖孔在右
    void SetLandscapeRight()
    {
        var width = _safeArea.width * _widthScale;
        var height = _uiScreenSize.y;
        GRoot.inst.SetSize(width, height);
        GRoot.inst.SetXY(0, 0);
    }

    void CheckScreenOrientation()
    {
        if (_currOrient == ScreenOrientation.LandscapeLeft) { SetLandscapeLeft(); }
        else if (_currOrient == ScreenOrientation.LandscapeRight) { SetLandscapeRight(); }
    }

    private long _timeNums; //        Debug.Log(long.MaxValue/(86400*60));//1779199852788 天

    private void FixedUpdate()
    {
        _timeNums++;
        if (_timeNums % 10 == 0)
        {
            if (Screen.orientation != _currOrient)
            {
                _currOrient = Screen.orientation;
                CheckScreenOrientation();
            }
        }
    }
}