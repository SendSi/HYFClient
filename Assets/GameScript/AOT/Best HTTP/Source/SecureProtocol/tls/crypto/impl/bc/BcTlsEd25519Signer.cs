#if !BESTHTTP_DISABLE_ALTERNATE_SSL && (!UNITY_WEBGL || UNITY_EDITOR)
#pragma warning disable
using System;

using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Signers;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Tls.Crypto.Impl.BC
{
    public class BcTlsEd25519Signer
        : BcTlsSigner
    {
        public BcTlsEd25519Signer(BcTlsCrypto crypto, Ed25519PrivateKeyParameters privateKey)
            : base(crypto, privateKey)
        {
        }

        public override TlsStreamSigner GetStreamSigner(SignatureAndHashAlgorithm algorithm)
        {
            if (algorithm == null || SignatureScheme.From(algorithm) != SignatureScheme.ed25519)
                throw new InvalidOperationException("Invalid algorithm: " + algorithm);

            Ed25519Signer signer = new Ed25519Signer();
            signer.Init(true, m_privateKey);

            return new BcTlsStreamSigner(signer);
        }
    }
}
#pragma warning restore
#endif
