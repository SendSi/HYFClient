using Cysharp.Threading.Tasks;

/// <summary>
/// 使用UniTask 对事件 缓几帧 Fire  写成部分类 当项目没有引用UniTask时,直接丢弃此脚本即可
/// </summary>
public partial class EventCenter : Singleton<EventCenter>
{
    public async void Fire_Wait(int name, int frame = 1)
    {
        await UniTask.DelayFrame(frame);
        Fire(name);
    }


    public async void Fire_Wait<T1>(int name, T1 obj, int frame = 1)
    {
        await UniTask.DelayFrame(frame);
        Fire<T1>(name, obj);
    }


    public async void Fire_Wait<T1, T2>(int name, T1 obj1, T2 obj2, int frame = 1)
    {
        await UniTask.DelayFrame(frame);
        Fire<T1, T2>(name, obj1, obj2);
    }


    public async void Fire_Wait<T1, T2, T3>(int name, T1 obj1, T2 obj2, T3 obj3, int frame = 1)
    {
        await UniTask.DelayFrame(frame);
        Fire<T1, T2, T3>(name, obj1, obj2, obj3);
    }

    public async void Fire_Wait<T1, T2, T3, T4>(int name, T1 obj1, T2 obj2, T3 obj3, T4 obj4, int frame = 1)
    {
        await UniTask.DelayFrame(frame);
        Fire<T1, T2, T3, T4>(name, obj1, obj2, obj3, obj4);
    }








}