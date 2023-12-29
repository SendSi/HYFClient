using FairyGUI;
// using Framework;
using UnityEngine;

namespace MainCenter
{
    public partial class TopEles : GComponent
    {
        public override void OnInit()
        {
            base.OnInit();
            _mainPlayerBtn.onClick.Set(OnClickMainPlayerBtn);

            EventCenter.GetInstance().Bind<string>(EventEnum.EE_test, OnEventTest);
            // EventSystem.Instance.Add<string>(MainCenterEvents.Test1, OnEventTest1);
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
            ProxyMainRoleModule.GetInstance().OpenRoleMainViewWin();
        }

        public override void Dispose()
        {
            base.Dispose();
            EventCenter.GetInstance().UnBind<string>(EventEnum.EE_test, OnEventTest);
            // EventSystem.Instance.Remove<string>(MainCenterEvents.Test1, OnEventTest1);
        }
    }
}
