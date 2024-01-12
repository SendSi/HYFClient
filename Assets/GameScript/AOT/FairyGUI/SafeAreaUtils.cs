using FairyGUI;
using UnityEngine;

/// <summary>
/// 浏海屏 处理
/// Android 版本: 安卓操作系统版本也对 Screen.safeArea 的可用性有一些影响。具体来说，Android 9.0（API 级别 28）及以上版本对 Screen.safeArea 提供更好的支持。
/// 当今手机 应该不会有太低版本来玩了吧....
/// </summary>
namespace FairyGUI
{
    public class SafeAreaUtils : MonoBehaviour
    {
        public static SafeAreaUtils Instance; //单例  但好像用不着哦
        public float OffsetLeftX { get; set; } //GComboBox弹出来的位置 不是很对  需要在GRoot.GetPoupPosition做处理

        private Rect _safeArea; // 根据 safeArea 调整 UI 元素的位置和大小   
        private ScreenOrientation _currOrient;
        private Vector2 _uiScreenSize;
        private bool _isHole; //是否 浏海屏

        private float _widthScale;
        // private float _heightScale;

        private void Awake()
        {
            Instance = this;
            _safeArea = Screen.safeArea;
            _currOrient = Screen.orientation;
            _isHole = (_safeArea.width != Screen.width || _safeArea.height != Screen.height); //true则是浏海屏
            Debug.LogWarning($"是否浏海屏:{_isHole}");
        }

        void Start()
        {
            _uiScreenSize = GRoot.inst.size;
            _widthScale = _uiScreenSize.x / Screen.width;

            // _heightScale = _uiScreenSize.y / Screen.height;
            //Debug.LogError($"_safeArea:{_safeArea}   size:{_uiScreenSize}   Screen:{Screen.width}_{Screen.height}    value:{_widthScale}");
            // Debug.LogError($"size:{_uiScreenSize}   Screen:{Screen.width}_{Screen.height}    value:{_widthScale}_{_heightScale}");
            CheckScreenOrientation();
        }


        //挖孔在左
        void SetLandscapeLeft()
        {
            OffsetLeftX = _safeArea.x * _widthScale;
            var width = _safeArea.width * _widthScale;
            var height = _uiScreenSize.y;
            GRoot.inst.SetSize(width, height);
            GRoot.inst.SetXY(OffsetLeftX * GRoot.inst.scaleX, 0);
        }

        //挖孔在右
        void SetLandscapeRight()
        {
            OffsetLeftX = 0;
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

        void FixedUpdate()
        {
            if (_isHole && Screen.orientation != _currOrient)
            {
                _currOrient = Screen.orientation;
                CheckScreenOrientation();
            }
        }
    }
}