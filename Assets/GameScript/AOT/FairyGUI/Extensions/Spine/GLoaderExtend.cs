using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

namespace FairyGUI
{
    public class GLoaderExtend : GLoader
    {
        public delegate void SetUrlDelegate(GLoaderExtend gloader, string rul);

        public static SetUrlDelegate SetUrlFunc;
        
        public static Dictionary<string, NTexture> url2nTex = new Dictionary<string, NTexture>();
        public static Dictionary<NTexture, string> nTex2url = new Dictionary<NTexture, string>();

        public string internalUrl { set { base.url = value; } }

        public bool fitTextureSize = true;

        public new string url
        {
            get
            {
                return base.url;
            }
            set
            {
                SetUrlFunc?.Invoke(this, value);
            }
        }

        protected override void LoadExternal()
        {
            //禁用自动大小
            if (fitTextureSize)
            {
                autoSize = false;
            }
            

            // NTexture texture = HttpImageDownloader.GetTexture(url);
            // if (texture != null)
            // {
            //     onExternalLoadSuccess(texture);
            //     if (fitTextureSize)
            //     {
            //         minWidth = maxWidth = sourceWidth;
            //         minHeight = maxHeight = sourceHeight;
            //         SetSize(sourceWidth, sourceHeight);
            //     }
            // }
            // else
            // {
            //     onExternalLoadFailed();
            // }
        }

        protected override void FreeExternal(NTexture texture)
        {
            // 已移交给 Lua 部分管理
        }
    }


    public class GLoader3DExtend : GLoader3D
    {
        public delegate void SetUrlDelegate(GLoader3DExtend gloader, string rul);
        public delegate void CreateEffectDelegate(GLoader3DExtend gLoader);
        public delegate void BindEffectDelegate(GLoader3DExtend gLoader);
        public delegate void DeleteEffectDelegate(GLoader3DExtend gLoader);

        public GComponent effectUpNode;
        public GComponent effectDownNode;

        public static SetUrlDelegate SetUrlFunc;
        public static CreateEffectDelegate CreateEffectFunc;
        public static BindEffectDelegate BindEffectFunc;
        public static DeleteEffectDelegate DeleteEffectFunc;

        public string internalUrl { set { base.url = value; } }

        public new string url
        {
            get
            {
                return base.url;
            }
            set
            {
                SetUrlFunc?.Invoke(this, value);
            }
        }

        protected override void CreateDisplayObject()
        {
            displayObject = new Container("GLoader3D");
            displayObject.gOwner = this;
            _content = new GoWrapper();
            _content.onUpdate += OnUpdateContent;

            effectUpNode = new GComponent();
            effectUpNode.name = "EffectNode";
            ((Container)displayObject).AddChild(effectUpNode.displayObject);

            ((Container)displayObject).AddChild(_content);
            ((Container)displayObject).opaque = true;

            effectDownNode = new GComponent();
            effectDownNode.name = "EffectNode";
            ((Container)displayObject).AddChild(effectDownNode.displayObject);
        }

        public override void SetSpine(SkeletonDataAsset asset, int width, int height, Vector2 anchor, bool cloneMaterial)
        {
            if (_spineAnimation != null)
                FreeSpine();
            _spineAnimation = SkeletonRenderer.NewSpineGameObject<SkeletonAnimation>(asset);
            _spineAnimation.gameObject.name = asset.name;
            Spine.SkeletonData dat = asset.GetSkeletonData(false);
            _spineAnimation.gameObject.transform.localScale = new Vector3(1 / asset.scale, 1 / asset.scale, 1);
            _spineAnimation.gameObject.transform.localPosition = new Vector3(anchor.x, -anchor.y, 0);
            SetWrapTarget(_spineAnimation.gameObject, cloneMaterial, width, height);

            _spineAnimation.skeleton.R = _color.r;
            _spineAnimation.skeleton.G = _color.g;
            _spineAnimation.skeleton.B = _color.b;

            OnChangeSpine(null);
            BindEffectFunc(this);
        }

        protected override void FreeSpine()
        {
            base.FreeSpine();
            DeleteEffectFunc(this);
        }

        public override void Dispose()
        {
            base.Dispose();
            DeleteEffectFunc(this);
        }
    }

}
