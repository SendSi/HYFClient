using UnityEngine;
using Grpc.Net.Client;
using Grpc.Net.Extensions;


    public class GrpcChannelManager : Singleton<GrpcChannelManager>
    {
        public GrpcChannel MainChannel { get; private set; }
        public string MainAddress { get; private set; }

        protected override void OnInit()
        {
        }

        protected override void OnDispose()
        {
            base.OnDispose();

            MainAddress = string.Empty;
            MainChannel?.Dispose();
            MainChannel = null;
        }

        public GrpcChannel InitMainChannel(string address)
        {
            if (string.IsNullOrEmpty(address))
                return default;

            if (MainAddress == address)
                return MainChannel;


            MainAddress = address;
            MainChannel?.Dispose();
            ServiceManager.Instance.ClearClients();

            MainChannel = CreateChannel(address);

            Debuger.LogWarning($" -->尝试连接服务器<--  " );
            return MainChannel;
        }

        public  GrpcChannel CreateChannel(string address, GrpcChannelOptions options = null)
        {
            if (options == null)
                options = new GrpcChannelOptions();

            if (options.HttpHandler == null)
                options.HttpHandler = new GRPCBestHttpHandler();

            return GrpcChannel.ForAddress(address, options);
        }
    }
