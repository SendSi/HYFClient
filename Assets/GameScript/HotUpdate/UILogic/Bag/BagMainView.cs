using FairyGUI;
using UnityEngine;

namespace Bag
{
    public partial class BagMainView : GComponent
    {
        public override void OnInit()
        {
            base.OnInit();

            _closeButton.onClick.Set(OnClickCloseMainView);
            EventCenter.GetInstance().Bind<string>(EventEnum.EE_test, OnEventTest);
        }

        private void OnEventTest(string arg0)
        {
            Debug.LogError("BagMainView 监听    EN_test_"+arg0);
        }

        private void OnClickCloseMainView()
        {
            ProxyBagModule.GetInstance().CloseBagMainView();
        }

        public void SetData()
        {
        }

        public override void Dispose()
        {
            base.Dispose();
            EventCenter.GetInstance().UnBind<string>(EventEnum.EE_test, OnEventTest);
        }
    }
}
