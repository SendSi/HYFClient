using UnityEngine;

public class MapBlockUnit : MonoBehaviour
{
    private MapResBlockData _mapResBlockData;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider2D;
    private Sprite _sprite;

    public void SetData(MapResBlockData blockData)
    {
        if (_mapResBlockData == null)
        {
            _mapResBlockData = blockData;
            RefreshShow();
        }
        else
        {
            if (_mapResBlockData.X == blockData.X && _mapResBlockData.Y == blockData.Y)
            {
                RefreshPos();
            }
            else
            {
                _mapResBlockData = blockData;
                RefreshShow();
            }
        }
        SetActive(true);
    }

    public void SetActive(bool b)
    {
        gameObject.SetActive(b);
    }

    private void RefreshPos()
    {
        if (_mapResBlockData != null)
        {
            transform.position = new Vector3(_mapResBlockData.PosX, _mapResBlockData.PosY, 0);
        }
    }

    private void RefreshShow()
    {
        RefreshPos();
        RefreshTexture();
        RefreshBoxCollliderSize();
    }

    private void RefreshBoxCollliderSize()
    {
        if (_mapResBlockData != null)
        {
            boxCollider2D.size = new Vector2(_mapResBlockData.Width * 0.01f, _mapResBlockData.Height * 0.01f);
            boxCollider2D.offset = Vector2.zero;
        }
    }

    private void RefreshTexture()
    {
        if (_mapResBlockData != null)
        {
            SceneMapManager.Instance.GetSprite(this,_mapResBlockData.BlockName);
        } 
    }

    public void SetSpriteRes(Sprite sprite, string res)
    {
        if (_mapResBlockData.BlockName.Equals(res) == false)
        {
            return;
        }
        _sprite = sprite;
        spriteRenderer.sprite = _sprite;
    }

    public void Reset()
    {
        _mapResBlockData = null;
    }

    public bool Equal(MapResBlockData blockData)
    {
        if (_mapResBlockData != null)
        {
            return (_mapResBlockData.X==blockData.X && _mapResBlockData.Y==blockData.Y);
        }
        return false;
    }
    
    
}