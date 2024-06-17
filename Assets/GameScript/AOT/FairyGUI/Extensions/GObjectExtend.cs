using System.Reflection;
using UnityEngine;
namespace FairyGUI
{
    //扩展类的调用法
    public static class GObjectExtend
    {
        public static void GetGlobalXY(this GObject gObject, out float retX, out float retY)
        {
            Vector2 ret = gObject.LocalToGlobal(Vector2.zero);
            retX = ret.x;
            retY = ret.y;
        }

        public static void GetGlobalXY(this GObject gObject, float x, float y, out float retX, out float retY)
        {
            Vector2 ret = gObject.LocalToGlobal(new Vector2(x, y));
            retX = ret.x;
            retY = ret.y;
        }

        public static GTweener TweenMoveXY(this GObject gObject, float endValueX,float endValueY, float duration)
        {
            return gObject.TweenMove(new Vector2(endValueX,endValueY),duration);
        }

        public static void GetPositonXY(this GObject gObject, out float x, out float y)
        {
            var v3 = gObject.position;
            x = v3.x;
            y = v3.y;
        }

        public static void GetLocalXY(this GObject gObject, GObject target, float x, float y, out float retX, out float retY)
        {
            Vector2 ret = target.LocalToGlobal(new Vector2(x, y));
            ret = gObject.GlobalToLocal(ret);
            retX = ret.x;
            retY = ret.y;
        }

        public static void GetLocalXY(this GObject gObject, float x, float y, out float retX, out float retY)
        {
            var ret = gObject.GlobalToLocal(new Vector2(x, y));
            retX = ret.x;
            retY = ret.y;
        }

        public static void GetGameObjectLocalXY(this GObject gObject, GameObject go, Camera cam, out float x, out float y)
        {
            var pos = cam.WorldToScreenPoint(go.transform.position);
            pos.y = Stage.inst.height - pos.y;
            var localPos = gObject.GlobalToLocal(new Vector2(pos.x, pos.y));
            x = localPos.x;
            y = localPos.y;
        }

        public static void WorldToLocalUnpacked(this GObject gObject, Camera cam, float x, float y, float z, out float retX, out float retY)
        {
            Vector2 ret = gObject.WorldToLocal(new Vector3(x, y, z), cam);
            retX = ret.x;
            retY = ret.y;
        }

        public static void GetWorldPosUnpacked(this GObject gObject, float x, float y, out float retX, out float retY, out float retZ)
        {
            Vector2 pos = gObject.displayObject.LocalToWorld(new Vector2(x, y));
            retX = pos.x;
            retY = pos.y;
            retZ = 0;
        }

        public static void TransformRectUnpacked(this GObject gObject, GObject targetSpace, out float x, out float y, out float w, out float h)
        {
            float posX = 0, posY = 0;

            if (gObject.pivotAsAnchor)
            {
                posX = -gObject.pivotX * gObject.width;
                posY = -gObject.pivotY * gObject.height;
            }

            var rect = gObject.TransformRect(new Rect(posX, posY, gObject.width, gObject.height), targetSpace);
            x = rect.xMin;
            y = rect.yMin;
            w = rect.width;
            h = rect.height;
        }

        public static bool IsChildOf(this GObject gObject, GObject parent)
        {
            if (!(parent is GComponent))
                return false;
            while (gObject != null)
            {
                if (gObject == parent)
                    return true;
                gObject = gObject.parent;
            }
            return false;
        }

        public static bool IsWindowTweening(this GObject gObject)
        {
            while (gObject != null)
            {
                if (gObject is Window window)
                    return GTween.IsTweening(window);
                gObject = gObject.parent;
            }
            return false;
        }

        public static bool IsAnyParentTweening(this GObject gObject)
        {
            while (gObject != null)
            {
                if (GTween.IsTweening(gObject))
                    return true;
                gObject = gObject.parent;
            }
            return false;
        }

        public static void DrawRoundedRect(this GObject gObject, float w, float h, Color color, float lt, float rt, float lb, float rb)
        {
            var gGraph = gObject as GGraph;
            if (gGraph != null)
            {
                gGraph.DrawRoundRect(w, h, color, new[] { lt, rt, lb, rb });
            }
        }

        public static int GetWindowSortingOrder(this GObject gObject)
        {
            Window w;
            while (gObject != null)
            {
                if (gObject.sortingOrder > 0)
                    return gObject.sortingOrder;

                w = gObject as Window;
                if (w != null)
                    return w.sortingOrder;
                gObject = gObject.parent;
            }
            return 0;
        }

        public static bool GetInternalVisible3(this GObject gObject)
        {
#if UNITY_EDITOR
            return (bool)gObject.GetType().GetProperty("internalVisible3", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(gObject);
#else
        return gObject.internalVisible3;
#endif
        }

        public static bool GetInternalVisible2(this GObject gObject)
        {
#if UNITY_EDITOR
            return (bool)gObject.GetType().GetProperty("internalVisible2", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(gObject);
#else
        return gObject.internalVisible2;
#endif
        }

        public static bool GetInternalVisible(this GObject gObject)
        {
#if UNITY_EDITOR
            return (bool)gObject.GetType().GetProperty("internalVisible", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(gObject);
#else
        return gObject.internalVisible;
#endif
        }

        public static bool IsActive(this GObject gObject)
        {
            var displayObject = gObject.displayObject;
            if (displayObject == null || displayObject.gameObject == null)
                return false;
            return displayObject.gameObject.activeInHierarchy;
        }

        public static void EnableScroll(this GObject go, bool isEnable)
        {
            GComponent component;
            while (go != null)
            {
                component = go as GComponent;
                if (component != null && component.scrollPane != null)
                    component.scrollPane.touchEffect = isEnable;
                go = go.parent;
            }
        }

        public static bool GetSpineSize(this GObject go, out float x, out float y, out float width, out float height)
        {
            width = height = 0;
            x = y = 0;

            var loader = go as GLoader3D;
            if (loader == null)
                return false;

            var displayObject = go.displayObject;
            if (displayObject == null)
                return false;

            if (displayObject.gameObject == null)
                return false;

            var meshRenderer = displayObject.gameObject.GetComponentInChildren<MeshRenderer>();
            if (meshRenderer == null)
                return false;

            var min = meshRenderer.bounds.min;
            var max = meshRenderer.bounds.max;

            min = go.parent.WorldToLocal(min, StageCamera.main);
            max = go.parent.WorldToLocal(max, StageCamera.main);
            x = min.x;
            y = max.y;
            width = max.x - min.x;
            height = min.y - max.y;
            return true;
        }

        public static GTweener TweenRotationY(this GObject gObject, float endValue, float duration)
        {
            return GTween.To(gObject.rotationY, endValue, duration).SetTarget(gObject, TweenPropType.RotationY);
        }

        public static GTweener TweenScaleXY(this GObject gObject, float endValue, float duration)
        {
           return gObject.TweenScale(new Vector2(endValue,endValue),duration);
        }

    }
}