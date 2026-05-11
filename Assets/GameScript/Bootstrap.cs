using Obfuz;
using Obfuz.EncryptionVM;
using UnityEngine;


public class Bootstrap : MonoBehaviour
{
    // 初始化EncryptionService后被混淆的代码才能正常运行，
    // 因此尽可能地早地初始化它。
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    private static void SetUpStaticSecretKey()
    {
        EncryptionService<DefaultStaticEncryptionScope>.Encryptor = new GeneratedEncryptionVirtualMachine(Resources.Load<TextAsset>("Obfuz/defaultStaticSecretKey").bytes);
    }

    void Start()
    {
        Debug.Log($"初始化了Obfuz混淆了 ");
    }
}
