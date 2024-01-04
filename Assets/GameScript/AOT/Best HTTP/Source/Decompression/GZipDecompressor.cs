using System;

using BestHTTP.Extensions;
using BestHTTP.PlatformSupport.Memory;

namespace BestHTTP.Decompression
{
    public sealed class GZipDecompressor : IDecompressor
    {
        private BufferPoolMemoryStream decompressorInputStream;
        private BufferPoolMemoryStream decompressorOutputStream;
        private Zlib.GZipStream decompressorStream;

        private int MinLengthToDecompress = 256;

        public GZipDecompressor(int minLengthToDecompress)
        {
            this.MinLengthToDecompress = minLengthToDecompress;
        }

        private void CloseDecompressors()
        {
            if (decompressorStream != null)
                decompressorStream.Dispose();
            decompressorStream = null;

            if (decompressorInputStream != null)
                decompressorInputStream.Dispose();
            decompressorInputStream = null;

            if (decompressorOutputStream != null)
                decompressorOutputStream.Dispose();
            decompressorOutputStream = null;
        }

        public DecompressedData Decompress(byte[] data, int offset, int count, bool forceDecompress = false, bool dataCanBeLarger = false)
        {
            if (decompressorInputStream == null)
                decompressorInputStream = new BufferPoolMemoryStream(count);

            if (data != null)
                decompressorInputStream.Write(data, offset, count);

            if (!forceDecompress && decompressorInputStream.Length < MinLengthToDecompress)
                return new DecompressedData(null, 0);

            decompressorInputStream.Position = 0;

            if (decompressorStream == null)
            {
                decompressorStream = new Zlib.GZipStream(decompressorInputStream,
                                                             Zlib.CompressionMode.Decompress,
                                                             Zlib.CompressionLevel.Default,
                                                             true);
                decompressorStream.FlushMode = Zlib.FlushType.Sync;
            }

            if (decompressorOutputStream == null)
                decompressorOutputStream = new BufferPoolMemoryStream();
            decompressorOutputStream.SetLength(0);

            byte[] copyBuffer = BufferPool.Get(1024, true);

            int readCount;
            int sumReadCount = 0;
            while ((readCount = decompressorStream.Read(copyBuffer, 0, copyBuffer.Length)) != 0)
            {
                decompressorOutputStream.Write(copyBuffer, 0, readCount);
                sumReadCount += readCount;
            }

            BufferPool.Release(copyBuffer);

            // If no read is done (returned with any data) don't zero out the input stream, as it would delete any not yet used data.
            if (sumReadCount > 0)
                decompressorStream.SetLength(0);

            byte[] result = decompressorOutputStream.ToArray(dataCanBeLarger);

            return new DecompressedData(result, dataCanBeLarger ? (int)decompressorOutputStream.Length : result.Length);
        }

        ~GZipDecompressor()
        {
            Dispose();
        }

        public void Dispose()
        {
            CloseDecompressors();
            GC.SuppressFinalize(this);
        }
    }
}
