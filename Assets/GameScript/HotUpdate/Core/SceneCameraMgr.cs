﻿using BitBenderGames;
using UnityEngine;
using UnityEngine.Events;

public class SceneCameraMgr : Singleton<SceneCameraMgr>
{
    private Camera mainCamera;
    private GameObject mainCameraGo;
    private MobileTouchCamera _mobileTouchCam;
    private Vector4 cameraBounds = new Vector4(0, 0, 100, 100);

    protected override void OnInit()
    {
        base.OnInit();
        mainCamera = Camera.main;
        mainCameraGo = mainCamera.gameObject;
        GameObject.DontDestroyOnLoad(mainCameraGo);
    }

    public MobileTouchCamera mobileTouchCam
    {
        set { _mobileTouchCam = value; }
        get
        {
            if (_mobileTouchCam)
            {
                return _mobileTouchCam;
            }
            _mobileTouchCam = mainCameraGo.GetOrAddComponent<MobileTouchCamera>();
            return _mobileTouchCam;
        }
    }

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

        bounds[0] = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        bounds[1] = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, mainCamera.nearClipPlane));
        bounds[2] = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));
        bounds[3] = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, mainCamera.nearClipPlane));

        center = (bounds[0] + bounds[1] + bounds[2] + bounds[3]) / 4;
        center.z = 0;
        
        Vector3 size = bounds[2] - bounds[0];
        size.z = 1;
    
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
        mobileTouchCam.OnCameraRenderChangeEvent += cb;
    }
    
    public void RemoveCameraRenderChangeEvent(UnityAction cb)
    {
        mobileTouchCam.OnCameraRenderChangeEvent -= cb;
    }

    public bool IsUsingUI()
    {
        return FairyGUI.Stage.isTouchOnUI;
    }
}