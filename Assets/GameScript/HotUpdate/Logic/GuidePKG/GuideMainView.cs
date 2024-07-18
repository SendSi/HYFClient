using System.Collections.Generic;
using FairyGUI;
using UnityEngine;
using cfg;
// GObjectExtend.GetLocalXY(target, 0, 0, out tx, out ty);
namespace GuidePKG
{
    public partial class GuideMainView : GComponent
    {
        private Dictionary<string, GComponent> mMaskGComDic = new Dictionary<string, GComponent>();

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

            EventCenter.Instance.Bind<string>((int)EventEnum.EE_Guide_UIPath, OnEventGuideUIPath);//监听指引 事件
        }

        GComponent CheckGetTryMask(string maskName)
        {
            if (mMaskGComDic.TryGetValue(maskName, out var maskView))
            {
                return maskView;
            }
            else
            {
                var maskCom = UIPackage.CreateObject("GuidePKG", maskName).asCom;
                this.AddChildAt(maskCom, 0);
                mMaskGComDic[maskName] = maskCom;
                return maskCom;
            }
        }

        private void OnEventGuideUIPath(string content)
        {
            var isFinish = false;
            if (string.IsNullOrEmpty(mStepCfg.UiPath) && content.Equals("true"))
            {
                isFinish = true; //无具体路径的
            }

            if (mStepCfg.UiPath == content)
            {
                if (string.IsNullOrEmpty(mStepCfg.MoveEffect) == false)
                {
                    mTransDic[mStepCfg.MoveEffect].Stop();
                }
                if (string.IsNullOrEmpty(mStepCfg.MaskLoader) == false)
                {
                    var maskCom = CheckGetTryMask(mStepCfg.MaskLoader);
                    maskCom.visible = false;//需要隐藏起来
                }

                if (mStepCfg.CloseMain == 0)
                {
                    this.visible = false;
                }

                isFinish = true; //有具体路径的
            }

            if (isFinish==false &&  string.IsNullOrEmpty(mStepCfg.MaskLoader) )
            {
                GuidePKGManager.Instance.StopGuide();
                Debuger.Log("没mask 与 点击又没点中目标,则直接结束");
                return;//没mask 与 点击又没点中目标,则直接结束
            }

            if (isFinish == false)
            {
                Debuger.Log("无匹配的完成事件类型 或 没点中目标");
                return;
            }

            if (mStepCfg.FinishTime > 0.01f)
            {
                Timers.inst.Add(mStepCfg.FinishTime, 1, obj =>
                {
                    Debuger.LogWarning($"完成一步了{mStepCfg.Id},{mStepCfg.UiPath}---yes");
                    EventCenter.Instance.Fire((int)EventEnum.EE_Guide_NextStep);
                });
            }
            else
            {
                Debuger.LogWarning($"完成一步了{mStepCfg.Id},{mStepCfg.UiPath}---yes");
                EventCenter.Instance.Fire((int)EventEnum.EE_Guide_NextStep);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            EventCenter.Instance.UnBind<string>((int)EventEnum.EE_Guide_UIPath, OnEventGuideUIPath);
        }

        public void SetData(GuideStepConfig stepCfg)
        {
            mStepCfg = stepCfg;
            if (mStepCfg.UiPath.Contains("path:"))
            {
                //有具体位置的
                var path = mStepCfg.UiPath.Replace("path:", "");
                var target = GRoot.inst.GetChildByPath(path);
                if (target == null)
                {
                    Debuger.LogError($"路径错误:{path}，此guideType={mStepCfg.GType}终止");
                    GuidePKGManager.Instance.StopGuide();
                    return;
                }

                var tagetV2 = target.LocalToGlobal(new Vector2(x, y));
                tagetV2 = GRoot.inst.GlobalToLocal(tagetV2);

                if (string.IsNullOrEmpty(mStepCfg.MoveEffect) == false)
                {
                    mTransDic[mStepCfg.MoveEffect].Play(1000);
                    _fingerCom.visible = true;
                    this._fingerCom.SetXY(tagetV2.x, tagetV2.y);
                }
                else
                {
                    _fingerCom.visible = false; //不显示手指
                }

                if (string.IsNullOrEmpty(mStepCfg.MaskLoader) == false)
                {
                    var maskCom = CheckGetTryMask(mStepCfg.MaskLoader);
                    if (maskCom != null)
                    {
                        maskCom.visible = true;
                        var window = maskCom.GetChild("window");
                        window.size = new Vector2(target.width, target.height);
                        window.SetXY(tagetV2.x, tagetV2.y);
                    }
                }
            }
            else
            {
                this._fingerCom.visible = false;
            }

            if (mStepCfg.DescId > 0)
            {
                //有描述
                this._descLoader.visible = true;
                var descCfg = CfgLubanMgr.Instance.globalTab.TbGuideDescConfig.Get(mStepCfg.DescId);//ConfigMgr.Instance.LoadConfigOne<GuideDescConfig>(mStepCfg.DescId.ToString());
                if (descCfg != null)
                {
                    this._descLoader.url = descCfg.UrlPath;
                    this._descLoader.SetXY(descCfg.ConX, descCfg.ConY);
                    this._descLoader.text = descCfg.TxtContent;
                }
            }
            else
            {
                this._descLoader.visible = false;
            }
        }
    }
}