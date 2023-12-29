using UnityEngine;

public class CoreUtil : MonoBehaviour
{
    public static CoreUtil Instance;
    void Awake()
    {
        Instance = this;
    }


}
