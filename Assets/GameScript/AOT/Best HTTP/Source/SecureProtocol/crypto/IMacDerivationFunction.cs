#if !BESTHTTP_DISABLE_ALTERNATE_SSL && (!UNITY_WEBGL || UNITY_EDITOR)
#pragma warning disable
namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto
{
    public interface IMacDerivationFunction
        : IDerivationFunction
    {
        IMac Mac { get; }
    }
}
#pragma warning restore
#endif
