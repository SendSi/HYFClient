#region << 脚 本 注 释 >>
//作  用:    ProxySpinePKGModule
//作  者:    曾思信
//创建时间:  #CREATETIME#
#endregion

using System;
using FairyGUI;
using Spine.Unity;
using UnityEngine;
using YooAsset;

namespace SpinePKG
{
    public partial class SpineMainView : GComponent
    {
        public override void OnInit()
        {
            base.OnInit();
            this._closeBtn.onClick.Set(() => { ProxySpinePKGModule.Instance.CloseSpineMainView(); });

            this._spineIcon.url="";
            this._spineIcon.url="ui://SpinePKG/bulianshi";

            // Load();
        }

        void Load()
        {
            LoadSpine("bulianshi_SkeletonData", delegate(AssetHandle ah)
            {
                var clip = ah.AssetObject as SkeletonDataAsset;
                this._spineIcon.SetSpine(clip,10,10,new Vector2(0,0));
            }); 
        }
        
        void LoadSpine(string name, Action<AssetHandle> clipAH)
        {
            var package = YooAssets.GetPackage(AppConfig.defaultYooAssetPKG);//"DefaultPackage");
            var handle = package.LoadAssetAsync<SkeletonDataAsset>(name);
            handle.Completed += clipAH;
        }

        public void SetData(string cfgId)
        {
            // this._spineIcon.url="ui://SpinePKG/bulianshi";
        }
    }
}