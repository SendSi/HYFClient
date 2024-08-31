public enum EAStarNodeType
{
    Walk,
    Stop
}

public class AStarNode
{
    public int x;
    public int y;
    public EAStarNodeType type;
    public float f = 0;
    public float g = 0;
    public float h = 0;

    public AStarNode father;

    public AStarNode(int xx, int yy, EAStarNodeType tType)
    {
        this.x = xx;
        this.y = yy;
        this.type = tType;
    }

    public void SetFGH(float f, float g, float h)
    {
        this.f = f;
        this.g = g;
        this.h = h;
    }

    public void ClearNode()
    {
        this.f = 0;
        this.g = 0;
        this.h = 0;
        this.father = null;
    }
}