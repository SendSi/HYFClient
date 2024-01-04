#if !BESTHTTP_DISABLE_ALTERNATE_SSL && (!UNITY_WEBGL || UNITY_EDITOR)
#pragma warning disable
using System;
using System.IO;

using BestHTTP.SecureProtocol.Org.BouncyCastle.Math.EC.Rfc8032;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Security;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
    public sealed class Ed448PrivateKeyParameters
        : AsymmetricKeyParameter
    {
        public static readonly int KeySize = Ed448.SecretKeySize;
        public static readonly int SignatureSize = Ed448.SignatureSize;

        private readonly byte[] data = new byte[KeySize];

        private Ed448PublicKeyParameters cachedPublicKey;

        public Ed448PrivateKeyParameters(SecureRandom random)
            : base(true)
        {
            Ed448.GeneratePrivateKey(random, data);
        }

        public Ed448PrivateKeyParameters(byte[] buf)
            : this(Validate(buf), 0)
        {
        }

        public Ed448PrivateKeyParameters(byte[] buf, int off)
            : base(true)
        {
            Array.Copy(buf, off, data, 0, KeySize);
        }

#if NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER || _UNITY_2021_2_OR_NEWER_
        public Ed448PrivateKeyParameters(ReadOnlySpan<byte> buf)
            : base(true)
        {
            if (buf.Length != KeySize)
                throw new ArgumentException("must have length " + KeySize, nameof(buf));

            buf.CopyTo(data);
        }
#endif

        public Ed448PrivateKeyParameters(Stream input)
            : base(true)
        {
            if (KeySize != Streams.ReadFully(input, data))
                throw new EndOfStreamException("EOF encountered in middle of Ed448 private key");
        }

        public void Encode(byte[] buf, int off)
        {
            Array.Copy(data, 0, buf, off, KeySize);
        }

#if NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER || _UNITY_2021_2_OR_NEWER_
        public void Encode(Span<byte> buf)
        {
            data.CopyTo(buf);
        }
#endif

        public byte[] GetEncoded()
        {
            return Arrays.Clone(data);
        }

        public Ed448PublicKeyParameters GeneratePublicKey()
        {
            lock (data)
            {
                if (null == cachedPublicKey)
                {
#if NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER || _UNITY_2021_2_OR_NEWER_
                    Span<byte> publicKey = stackalloc byte[Ed448.PublicKeySize];
                    Ed448.GeneratePublicKey(data, publicKey);
                    cachedPublicKey = new Ed448PublicKeyParameters(publicKey);
#else
                    byte[] publicKey = new byte[Ed448.PublicKeySize];
                    Ed448.GeneratePublicKey(data, 0, publicKey, 0);
                    cachedPublicKey = new Ed448PublicKeyParameters(publicKey, 0);
#endif
                }

                return cachedPublicKey;
            }
        }

        public void Sign(Ed448.Algorithm algorithm, byte[] ctx, byte[] msg, int msgOff, int msgLen,
            byte[] sig, int sigOff)
        {
            Ed448PublicKeyParameters publicKey = GeneratePublicKey();

            byte[] pk = new byte[Ed448.PublicKeySize];
            publicKey.Encode(pk, 0);

            switch (algorithm)
            {
            case Ed448.Algorithm.Ed448:
            {
                Ed448.Sign(data, 0, pk, 0, ctx, msg, msgOff, msgLen, sig, sigOff);
                break;
            }
            case Ed448.Algorithm.Ed448ph:
            {
                if (Ed448.PrehashSize != msgLen)
                    throw new ArgumentException("msgLen");

                Ed448.SignPrehash(data, 0, pk, 0, ctx, msg, msgOff, sig, sigOff);
                break;
            }
            default:
            {
                throw new ArgumentException("algorithm");
            }
            }
        }

        private static byte[] Validate(byte[] buf)
        {
            if (buf.Length != KeySize)
                throw new ArgumentException("must have length " + KeySize, nameof(buf));

            return buf;
        }
    }
}
#pragma warning restore
#endif
