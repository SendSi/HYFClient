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

            EventCenter.Instance.Bind<string>(EventEnum.EE_test,OnEventTest);
            EventCenter.Instance.Bind<int>(EventEnum.EE_loginIn,OnEventLoginIn);
       }

        private void OnEventLoginIn(int arg0)
        {
            Debuger.LogError("OnEventGameOver 值 "+arg0);
        }


        private void OnEventTest(string arg0)
        {
            Debuger.LogError("MainCenterView 监听了  EN_test_"+arg0);
        }

        private void OnEventTest1(string text)
        {
            Debuger.LogError("MainCenterView 监听    EN_test:" + text);
        }

        private void OnClickQuit()
        {

        }

        public override void Dispose()
        {
            base.Dispose();
            DisposeEles();
            Debuger.LogWarning("调用 Dispose MainCenterView");
            EventCenter.Instance.UnBind<string>(EventEnum.EE_test,OnEventTest);
            EventCenter.Instance.UnBind<int>(EventEnum.EE_loginIn,OnEventLoginIn);
        }


        public void SetData()
        {
        }


        #region UI 各方面的元素

        private main_team_right rightTeam;
        private MainTopEles topEles;
        private FuncListEles funcListEles;

        private void InitEles()
        {
            rightTeam = (main_team_right)_rightTeam; //推荐使用这种吧
            rightTeam.OnInit();

            topEles = (MainTopEles)_topEles;
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
