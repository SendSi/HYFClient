using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

// GObjectExtend.GetLocalXY(target, 0, 0, out tx, out ty);

namespace GuidePKG
{
    public partial class GuideMainView : GComponent
    {
        private GuideStepConfig mStepCfgs;

        private Dictionary<string, Transition> mTransDic;

        public override void OnInit()
        {
            base.OnInit();
            sortingOrder = 2000;

            mTransDic = new Dictionary<string, Transition>()
            {
                { "move1", this._fingerCom._move1 },
                { "move2", this._fingerCom._move2 },
                { "move3", this._fingerCom._move3 },
                { "move4", this._fingerCom._move4 }
            };

            EventCenter.Instance.Bind<string>(EventEnum.EE_Guide_UIPath, OnEventGuideUIPath);
        }

        private void OnEventGuideUIPath(string uiPath)
        {
            if (mStepCfgs.uiPath == uiPath)
            {
                Debug.LogWarning($"完成一步了{mStepCfgs.id},{mStepCfgs.uiPath}---yes");
                EventCenter.Instance.Fire(EventEnum.EE_Guide_NextStep);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            EventCenter.Instance.UnBind<string>(EventEnum.EE_Guide_UIPath, OnEventGuideUIPath);
        }

        public void SetData(GuideStepConfig stepCfgs)
        {
            mStepCfgs = stepCfgs;
            mTransDic[stepCfgs.moveEffect].Play(1000);
            Debug.LogWarning($"---->需执行{mStepCfgs.id},{mStepCfgs.uiPath}");

            if (mStepCfgs.uiPath.Contains("path:"))
            {
                var path = mStepCfgs.uiPath.Replace("path:", "");
                var target = GRoot.inst.GetChildByPath(path);
                if (target == null)
                {
                    Debug.LogError($"路径错误:{path}");
                    return;
                }

                Vector2 ret = target.LocalToGlobal(new Vector2(x, y));
                ret = GRoot.inst.GlobalToLocal(ret);
                Debug.LogError($"{ret.x}   {ret.y}");
                this._fingerCom.SetXY(ret.x, ret.y);

                this._maskLoader.url = mStepCfgs.maskLoader;
                this._maskLoader.SetXY(ret.x , ret.y);

                GComponent gc = this._maskLoader.component;
                if (gc != null)
                {
                    var mask = gc.GetChild("mask");
                    var window = gc.GetChild("window");

                    window.size = new Vector2(target.width, target.height);
                    mask.size = new Vector2(1334, 750);

                    var glo = mask.LocalToGlobal(Vector2.zero);
                    Debug.LogError($"{glo.x}  {glo.y}");
                    mask.SetXY(-glo.x, -glo.y);
                }
            }
        }
    }
}