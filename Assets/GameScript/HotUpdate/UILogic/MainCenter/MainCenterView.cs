using FairyGUI;
using UnityEngine;

namespace MainCenter
{
    public partial class MainCenterView : GComponent
    {
        public override void OnInit()
        {
            base.OnInit();

            _backBtn.onClick.Set(OnClickQuit);
            _outBtn.onClick.Set(OnClickQuit);

            InitEles();

            EventCenter.GetInstance().Bind<string>(EventEnum.EE_test,OnEventTest);
            EventCenter.GetInstance().Bind<int>(EventEnum.EE_loginIn,OnEventLoginIn);
       }

        private void OnEventLoginIn(int arg0)
        {
            Debug.LogError("OnEventGameOver 值 "+arg0);
        }


        private void OnEventTest(string arg0)
        {
            Debug.LogError("MainCenterView 监听了  EN_test_"+arg0);
        }

        private void OnEventTest1(string text)
        {
            Debug.LogError("MainCenterView 监听    EN_test:" + text);
        }

        private void OnClickQuit()
        {
            ProxyLoginModule.GetInstance().OpenLoginMainView();
            ProxyMainCenterModule.GetInstance().CloseMainCenterView();
        }

        public override void Dispose()
        {
            base.Dispose();
            DisposeEles();
            Debug.LogWarning("调用 Dispose MainCenterView");
            EventCenter.GetInstance().UnBind<string>(EventEnum.EE_test,OnEventTest);
            EventCenter.GetInstance().UnBind<int>(EventEnum.EE_loginIn,OnEventLoginIn);

        }


        public void SetData()
        {
        }


        #region UI 各方面的元素

        private main_team_right rightTeam;
        private TopEles topEles;
        private FuncListEles funcListEles;

        private void InitEles()
        {
            rightTeam = (main_team_right)_rightTeam; //推荐使用这种吧
            rightTeam.OnInit();

            topEles = (TopEles)_topEles;
            topEles.OnInit();

            funcListEles = (FuncListEles)_funcListEles;
            funcListEles.OnInit();
        }

        private void DisposeEles()
        {
            topEles.Dispose();
            funcListEles.Dispose();
            rightTeam.Dispose();
        }

        #endregion
    }
}
