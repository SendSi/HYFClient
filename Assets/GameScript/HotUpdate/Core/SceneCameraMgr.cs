
using BitBenderGames;
using UnityEngine;
using UnityEngine.Events;

public class SceneCameraMgr : Singleton<SceneCameraMgr>
{
    private MobileTouchCamera _mobileTouchCam;

    public MobileTouchCamera mobileTouchCam
    {
        set { _mobileTouchCam = value; }
        get
        {
            if (_mobileTouchCam)
            {
                return _mobileTouchCam;
            }
            _mobileTouchCam = Camera.main.gameObject.GetOrAddComponent<MobileTouchCamera>();
            return _mobileTouchCam;
        }
    }

    public Vector4 cameraBounds = new Vector4(0, 0, 100, 100);

    public void SetBounds(float minX, float maxX, float minY, float maxY)
    {
        cameraBounds.x = minX;
        cameraBounds.y = minY;
        cameraBounds.z = maxX;
        cameraBounds.w = maxY;
        mobileTouchCam.BoundaryMin = new Vector2(minX, minY);
        mobileTouchCam.BoundaryMax = new Vector2(maxX, maxY);
        mobileTouchCam.ResetCameraBoundaries();
    }
    
    public Vector3 GetScreenBoundsInWorld(out Vector3 center)
    {
        Vector3[] bounds = new Vector3[4];
        Camera sceneCamera = Camera.main;
        bounds[0] = sceneCamera.ViewportToWorldPoint(new Vector3(0, 0, sceneCamera.nearClipPlane));
        bounds[1] = sceneCamera.ViewportToWorldPoint(new Vector3(1, 0, sceneCamera.nearClipPlane));
        bounds[2] = sceneCamera.ViewportToWorldPoint(new Vector3(1, 1, sceneCamera.nearClipPlane));
        bounds[3] = sceneCamera.ViewportToWorldPoint(new Vector3(0, 1, sceneCamera.nearClipPlane));

        center = (bounds[0] + bounds[1] + bounds[2] + bounds[3]) / 4;
        Vector3 size = bounds[2] - bounds[0];
        size.z = 1;
        center.z = 0;
        return size;
    }
    
    
    /// <summary> 判断两个矩形是否相交 </summary>
    public bool IsRectanglesIntersect(Vector3 world1, Vector2 size1, Vector3 world2, Vector2 size2)
    {
        Vector2 newPos1 = new Vector3(world1.x - size1.x / 2, world1.y - size1.y / 2);
        Vector2 newPos2 = new Vector3(world2.x - size2.x / 2, world2.y - size2.y / 2);
        if (newPos1.x + size1.x < newPos2.x ||
            newPos2.x + size2.x < newPos1.x ||
            newPos1.y + size1.y < newPos2.y ||
            newPos2.y + size2.y < newPos1.y)
        {
            return false;
        }

        return true;
    }


    public void AddCameraRenderChangeEvent(UnityAction cb)
    {
        mobileTouchCam.OnCameraRenderChangeEvent+=cb;
    }


}