using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting;
/// <summary>
/// 可以跳过 Unity 的启动画面-->BeforeSplashScreen
/// </summary>
[Preserve]
public class SkipSplahImage
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    // [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    // [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    // [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    // [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void Run()
    {
        Task.Run(() =>
        {
            SplashScreen.Stop(SplashScreen.StopBehavior.StopImmediate);
            // SplashScreen.Stop(SplashScreen.StopBehavior.FadeOut);
        });
    }
}