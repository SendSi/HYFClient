#if FAIRYGUI_SPINE
using FairyGUI;
using UnityEngine;

/// <summary>
///  扩展方法，用于提供GLoader3D 新的功能
/// </summary>
public static class GLoader3DExtensions
{
    /// <summary> GLoder3D 设置Spine    ,可仅传入spineName </summary>
    public static void SetLoadSpine(this GLoader3D gLoader3D, string spineName, bool isLoop = true, string aninName = "idle")
    {
        gLoader3D.DisposeSpine(); //先disposeSpine下

        gLoader3D.displayObject.name = spineName; //记录了spine的名字
        GameMain.Instance.StartCoroutine(FGUILoader.Instance.YooLoadSpineAsset(spineName, (obj) =>
        {
            gLoader3D.SetSpine(obj, 0, 0, new Vector2(gLoader3D.width * 0.5f, gLoader3D.height));
            gLoader3D.spineAnimation.loop = isLoop;
            gLoader3D.spineAnimation.AnimationName = aninName;
        }));
    }

    
    /// <summary> GLoder3D 清空spine,,,,页面dispose时,记得调用下 </summary>
    public static void DisposeSpine(this GLoader3D gLoader3D)
    {
        if (string.IsNullOrEmpty(gLoader3D.displayObject.name) == false)
        {
            gLoader3D.ClearContent();
            FGUILoader.Instance.RemoveSpine(gLoader3D.displayObject.name);
            gLoader3D.displayObject.name = string.Empty;
        }
    }
}
#endif