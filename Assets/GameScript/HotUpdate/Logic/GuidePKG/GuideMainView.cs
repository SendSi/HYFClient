using System.Collections.Generic;
using FairyGUI;

namespace GuidePKG
{
    public partial class GuideMainView : GComponent
    {
        private List<GuideStepConfig> mStepCfgs;

        private Dictionary<string, Transition> mTransDic;

        public override void OnInit()
        {
            base.OnInit();
            sortingOrder = 2000;

            mTransDic = new Dictionary<string, Transition>()
            {
                {"move1",this._fingerCom._move1},
                {"move2",this._fingerCom._move2},
                {"move3",this._fingerCom._move3},
                {"move4",this._fingerCom._move4}
              };
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        public void SetData(string uiPath)
        {
            //todo
        }
        
        public void SetData(List<GuideStepConfig> stepCfgs)
        {
            mStepCfgs = stepCfgs;
            mTransDic[stepCfgs[0].moveEffect].Play(1000);
        }
    }
}

