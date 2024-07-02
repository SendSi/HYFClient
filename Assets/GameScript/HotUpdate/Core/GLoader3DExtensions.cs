using FairyGUI;
using UnityEngine;

public static class GLoader3DExtensions
{
    public static void SetSpine_YooAsset(this GLoader3D gLoader3D, string name,bool isLoop = true, string aninName = "idle")
    {
        gLoader3D.Dispose_YooAsset();//先dispose下
        
        gLoader3D.displayObject.name = name;
        GameMain.Instance.StartCoroutine(FGUILoader.Instance.YooLoadSpineAsset(name, (obj) =>
        {
            gLoader3D.SetSpine(obj, 0, 0, new Vector2(gLoader3D.width * 0.5f, gLoader3D.height));
            gLoader3D.spineAnimation.loop = isLoop;
            gLoader3D.spineAnimation.AnimationName = aninName;
        }));
    }

    public static void Dispose_YooAsset(this GLoader3D gLoader3D)
    {
        if (string.IsNullOrEmpty(gLoader3D.displayObject.name)==false)
        {
            gLoader3D.ClearContent();
            FGUILoader.Instance.RemoveSpine(gLoader3D.displayObject.name);
            gLoader3D.displayObject.name = string.Empty;
        }
    }
}