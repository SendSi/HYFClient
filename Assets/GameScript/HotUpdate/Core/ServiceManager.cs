using System;
using System.Collections.Generic;
using Grpc.Core;



public class ServiceManager : Singleton<ServiceManager>
{
    static Type[] constructorTypes = new Type[1] { typeof(ChannelBase) };
    static object[] constructorParams = new object[1] { typeof(ChannelBase) };

    Dictionary<Type, ClientBase> clientDic;

    protected override void OnInit()
    {
        clientDic = new Dictionary<Type, ClientBase>();
    }

    protected override void OnDispose()
    {
        clientDic = null;

        GrpcChannelManager.Instance.Dispose();
    }

    public T InitAndGetMainClient<T>(string address) where T : ClientBase
    {
        GrpcChannelManager.Instance.InitMainChannel(address);
        return GetClient<T>();
    }

    public T GetClient<T>() where T : ClientBase
    {
        var mainChannel = GrpcChannelManager.Instance.MainChannel;
        if (mainChannel == null)
            return default;

        var type = typeof(T);
        if (!clientDic.TryGetValue(type, out var client))
        {
            var constructor = typeof(T).GetConstructor(constructorTypes);
            if (constructor == null)
                throw new Exception($"找不到构造方法. type:{typeof(T).FullName}");

            constructorParams[0] = mainChannel;
            client = (ClientBase)constructor.Invoke(constructorParams);
            clientDic.Add(type, client);
        }

        return (T)client;
    }

    public PooledClient<T> GetClient<T>(out T client) where T : ClientBase
    {
        client = GetClient<T>();
        return new PooledClient<T>(client);
    }

    public void RemoveClient(ClientBase client)
    {
        var type = client?.GetType();
        if (type != null)
            clientDic.Remove(type);
    }

    public void ClearClients()
    {
        clientDic.Clear();
    }


    public struct PooledClient<T> : IDisposable where T : ClientBase
    {
        private readonly T client;

        internal PooledClient(T value)
        {
            client = value;
        }

        void IDisposable.Dispose()
        {
            Instance?.RemoveClient(client);
        }
    }
    
    private Metadata _metaData;

    //登录时 存好元数据
    public void SetMetaData(string metaNickName, int roleId)
    {
        _metaData = new Metadata {{ "roleId", roleId.ToString() }, { "nickName", metaNickName }  };
    }

    public Metadata GetMetaData()
    {
        return _metaData;
    }
    
}