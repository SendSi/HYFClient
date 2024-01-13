using FairyGUI;
using UnityEngine;

namespace MainCenter
{
    public partial class TopEles : GComponent
    {
        public override void OnInit()
        {
            base.OnInit();
            _mainPlayerBtn.onClick.Set(OnClickMainPlayerBtn);
            _settingBtn.onClick.Set(OnClickSettingBtn);

            EventCenter.Instance.Bind<string>(EventEnum.EE_test, OnEventTest);
        }

        private void OnClickSettingBtn(EventContext context)
        {
            ProxySettingPKGModule.Instance.OpenSettingPKGViewWin();
        }

        private void OnEventTest(string arg0)
        {
            Debug.LogError("TopEles 监听了 EN_test_"+arg0);
        }

        private void OnEventTest1(string text)
        {
            Debug.LogError("TopEles 监听了 EN_test:" + text);
        }

        private void OnClickMainPlayerBtn()
        {
            ProxyMainRoleModule.Instance.OpenRoleMainViewWin();
        }

        public override void Dispose()
        {
            base.Dispose();
            EventCenter.Instance.UnBind<string>(EventEnum.EE_test, OnEventTest);
        }
    }
}
