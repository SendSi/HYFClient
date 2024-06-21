using System.Collections.Generic;
using FairyGUI;
using UnityEngine;

// GObjectExtend.GetLocalXY(target, 0, 0, out tx, out ty);

namespace GuidePKG
{
    public partial class GuideMainView : GComponent
    {
        private GuideStepConfig mStepCfg;

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
                { "move4", this._fingerCom._move4 },
                { "move5", this._fingerCom._move5 }
            };

            EventCenter.Instance.Bind<string>(EventEnum.EE_Guide_UIPath, OnEventGuideUIPath);
        }

        private void OnEventGuideUIPath(string content)
        {
            var isFinish = false;
            if (string.IsNullOrEmpty(mStepCfg.uiPath) && content.Equals("true"))
            {
                isFinish = true; //无具体路径的
            }

            if (mStepCfg.uiPath == content)
            {
                if (string.IsNullOrEmpty(mStepCfg.moveEffect) == false)
                {
                    mTransDic[mStepCfg.moveEffect].Stop();
                }

                if (mStepCfg.closeMain == 0)
                {
                    this.visible = false;
                }

                isFinish = true; //有具体路径的
            }

            if (isFinish == false)
            {
                Debug.LogError("无匹配的完成事件类型");
                return;
            }

            if (mStepCfg.finishTime > 0.01f)
            {
                Timers.inst.Add(mStepCfg.finishTime, 1, obj =>
                {
                    Debug.LogWarning($"完成一步了{mStepCfg.id},{mStepCfg.uiPath}---yes");
                    EventCenter.Instance.Fire(EventEnum.EE_Guide_NextStep);
                });
            }
            else
            {
                Debug.LogWarning($"完成一步了{mStepCfg.id},{mStepCfg.uiPath}---yes");
                EventCenter.Instance.Fire(EventEnum.EE_Guide_NextStep);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            EventCenter.Instance.UnBind<string>(EventEnum.EE_Guide_UIPath, OnEventGuideUIPath);
        }

        public void SetData(GuideStepConfig stepCfg)
        {
            mStepCfg = stepCfg;
            if (mStepCfg.uiPath.Contains("path:"))
            {
                //有具体位置的
                var path = mStepCfg.uiPath.Replace("path:", "");
                var target = GRoot.inst.GetChildByPath(path);
                if (target == null)
                {
                    Debug.LogError($"路径错误:{path}，此guideType={mStepCfg.gType}终止");
                    GuidePKGManager.Instance.StopGuide();
                    return;
                }

                var tagetV2 = target.LocalToGlobal(new Vector2(x, y));
                tagetV2 = GRoot.inst.GlobalToLocal(tagetV2);

                if (string.IsNullOrEmpty(mStepCfg.moveEffect) == false)
                {
                    mTransDic[mStepCfg.moveEffect].Play(1000);
                    _fingerCom.visible = true;
                    this._fingerCom.SetXY(tagetV2.x, tagetV2.y);
                }
                else
                {
                    _fingerCom.visible = false; //不显示手指
                }

                if (string.IsNullOrEmpty(mStepCfg.maskLoader) == false)
                {
                    this._maskLoader.visible = true;
                    this._maskLoader.url = mStepCfg.maskLoader;
                    GComponent gc = this._maskLoader.component;
                    if (gc != null)
                    {
                        var window = gc.GetChild("window");
                        window.size = new Vector2(target.width, target.height);
                        window.SetXY(tagetV2.x, tagetV2.y);
                    }
                }
                else
                {
                    this._maskLoader.visible = false;
                }
            }
            else
            {
                this._maskLoader.visible = false;
                this._fingerCom.visible = false;
            }

            if (mStepCfg.descId > 0)
            {
                //有描述
                this._descLoader.visible = true;
                var descCfg = ConfigMgr.Instance.LoadConfigOne<GuideDescConfig>(mStepCfg.descId.ToString());
                if (descCfg != null)
                {
                    this._descLoader.url = descCfg.urlPath;
                    this._descLoader.SetXY(descCfg.conX, descCfg.conY);
                    this._descLoader.text = descCfg.txtContent;
                }
            }
            else
            {
                this._descLoader.visible = false;
            }
        }
    }
}