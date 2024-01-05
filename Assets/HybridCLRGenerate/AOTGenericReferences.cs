using System.Collections.Generic;
public class AOTGenericReferences : UnityEngine.MonoBehaviour
{

	// {{ AOT assemblies
	public static readonly IReadOnlyList<string> PatchedAOTAssemblyList = new List<string>
	{
		"AOT.dll",
		"Google.Protobuf.dll",
		"Grpc.Core.Api.dll",
		"Newtonsoft.Json.dll",
		"System.Core.dll",
		"UniFramework.Event.dll",
		"UnityEngine.CoreModule.dll",
		"YooAsset.dll",
		"mscorlib.dll",
	};
	// }}

	// {{ constraint implement type
	// }} 

	// {{ AOT generic types
	// Google.Protobuf.Collections.RepeatedField.<GetEnumerator>d__28<object>
	// Google.Protobuf.Collections.RepeatedField<object>
	// Google.Protobuf.FieldCodec.<>c<object>
	// Google.Protobuf.FieldCodec.<>c__32<object>
	// Google.Protobuf.FieldCodec.<>c__DisplayClass32_0<object>
	// Google.Protobuf.FieldCodec.<>c__DisplayClass38_0<object>
	// Google.Protobuf.FieldCodec.<>c__DisplayClass39_0<object>
	// Google.Protobuf.FieldCodec.InputMerger<object>
	// Google.Protobuf.FieldCodec.ValuesMerger<object>
	// Google.Protobuf.FieldCodec<object>
	// Google.Protobuf.IDeepCloneable<object>
	// Google.Protobuf.IMessage<object>
	// Google.Protobuf.MessageParser.<>c__DisplayClass2_0<object>
	// Google.Protobuf.MessageParser<object>
	// Google.Protobuf.ValueReader<object>
	// Google.Protobuf.ValueWriter<object>
	// Grpc.Core.AsyncDuplexStreamingCall<object,object>
	// Grpc.Core.AsyncServerStreamingCall<object>
	// Grpc.Core.AsyncUnaryCall<object>
	// Grpc.Core.ClientBase<object>
	// Grpc.Core.DuplexStreamingServerMethod<object,object>
	// Grpc.Core.IAsyncStreamReader<object>
	// Grpc.Core.IClientStreamWriter<object>
	// Grpc.Core.Marshaller.<>c<object>
	// Grpc.Core.Marshaller<object>
	// Grpc.Core.Method<object,object>
	// Grpc.Core.ServerServiceDefinition.Builder.<>c__DisplayClass3_0<object,object>
	// Grpc.Core.ServerServiceDefinition.Builder.<>c__DisplayClass5_0<object,object>
	// Grpc.Core.ServerServiceDefinition.Builder.<>c__DisplayClass6_0<object,object>
	// Grpc.Core.ServerStreamingServerMethod<object,object>
	// Grpc.Core.UnaryServerMethod<object,object>
	// Singleton<object>
	// System.Action<int>
	// System.Action<object,object>
	// System.Action<object>
	// System.Collections.Generic.ArraySortHelper<int>
	// System.Collections.Generic.ArraySortHelper<object>
	// System.Collections.Generic.Comparer<int>
	// System.Collections.Generic.Comparer<object>
	// System.Collections.Generic.Dictionary.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection<object,object>
	// System.Collections.Generic.Dictionary<int,object>
	// System.Collections.Generic.Dictionary<object,object>
	// System.Collections.Generic.EqualityComparer<int>
	// System.Collections.Generic.EqualityComparer<object>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ICollection<int>
	// System.Collections.Generic.ICollection<object>
	// System.Collections.Generic.IComparer<int>
	// System.Collections.Generic.IComparer<object>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerable<int>
	// System.Collections.Generic.IEnumerable<object>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerator<int>
	// System.Collections.Generic.IEnumerator<object>
	// System.Collections.Generic.IEqualityComparer<int>
	// System.Collections.Generic.IEqualityComparer<object>
	// System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IList<int>
	// System.Collections.Generic.IList<object>
	// System.Collections.Generic.KeyValuePair<int,object>
	// System.Collections.Generic.KeyValuePair<object,object>
	// System.Collections.Generic.List.Enumerator<int>
	// System.Collections.Generic.List.Enumerator<object>
	// System.Collections.Generic.List<int>
	// System.Collections.Generic.List<object>
	// System.Collections.Generic.ObjectComparer<int>
	// System.Collections.Generic.ObjectComparer<object>
	// System.Collections.Generic.ObjectEqualityComparer<int>
	// System.Collections.Generic.ObjectEqualityComparer<object>
	// System.Collections.Generic.Queue.Enumerator<object>
	// System.Collections.Generic.Queue<object>
	// System.Collections.ObjectModel.ReadOnlyCollection<int>
	// System.Collections.ObjectModel.ReadOnlyCollection<object>
	// System.Comparison<int>
	// System.Comparison<object>
	// System.Func<System.Threading.Tasks.VoidTaskResult>
	// System.Func<byte>
	// System.Func<int>
	// System.Func<object,System.Threading.Tasks.VoidTaskResult>
	// System.Func<object,byte>
	// System.Func<object,int>
	// System.Func<object,object,object>
	// System.Func<object,object>
	// System.Func<object>
	// System.IEquatable<object>
	// System.Nullable<System.DateTime>
	// System.Predicate<int>
	// System.Predicate<object>
	// System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>
	// System.Runtime.CompilerServices.AsyncTaskMethodBuilder<int>
	// System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>
	// System.Runtime.CompilerServices.ConditionalWeakTable.CreateValueCallback<object,object>
	// System.Runtime.CompilerServices.ConditionalWeakTable.Enumerator<object,object>
	// System.Runtime.CompilerServices.ConditionalWeakTable<object,object>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<System.Threading.Tasks.VoidTaskResult>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<byte>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<int>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<object>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable<System.Threading.Tasks.VoidTaskResult>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable<byte>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable<int>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable<object>
	// System.Runtime.CompilerServices.TaskAwaiter<System.Threading.Tasks.VoidTaskResult>
	// System.Runtime.CompilerServices.TaskAwaiter<byte>
	// System.Runtime.CompilerServices.TaskAwaiter<int>
	// System.Runtime.CompilerServices.TaskAwaiter<object>
	// System.Threading.Tasks.ContinuationTaskFromResultTask<System.Threading.Tasks.VoidTaskResult>
	// System.Threading.Tasks.ContinuationTaskFromResultTask<byte>
	// System.Threading.Tasks.ContinuationTaskFromResultTask<int>
	// System.Threading.Tasks.ContinuationTaskFromResultTask<object>
	// System.Threading.Tasks.Task<System.Threading.Tasks.VoidTaskResult>
	// System.Threading.Tasks.Task<byte>
	// System.Threading.Tasks.Task<int>
	// System.Threading.Tasks.Task<object>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass35_0<System.Threading.Tasks.VoidTaskResult>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass35_0<byte>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass35_0<int>
	// System.Threading.Tasks.TaskFactory.<>c__DisplayClass35_0<object>
	// System.Threading.Tasks.TaskFactory<System.Threading.Tasks.VoidTaskResult>
	// System.Threading.Tasks.TaskFactory<byte>
	// System.Threading.Tasks.TaskFactory<int>
	// System.Threading.Tasks.TaskFactory<object>
	// UnityEngine.Events.UnityAction<int>
	// UnityEngine.Events.UnityAction<object,object,object>
	// UnityEngine.Events.UnityAction<object,object>
	// UnityEngine.Events.UnityAction<object>
	// }}

	public void RefMethods()
	{
		// Google.Protobuf.FieldCodec<object> Google.Protobuf.FieldCodec.ForMessage<object>(uint,Google.Protobuf.MessageParser<object>)
		// object Google.Protobuf.ProtoPreconditions.CheckNotNull<object>(object,string)
		// Grpc.Core.AsyncDuplexStreamingCall<object,object> Grpc.Core.CallInvoker.AsyncDuplexStreamingCall<object,object>(Grpc.Core.Method<object,object>,string,Grpc.Core.CallOptions)
		// Grpc.Core.AsyncServerStreamingCall<object> Grpc.Core.CallInvoker.AsyncServerStreamingCall<object,object>(Grpc.Core.Method<object,object>,string,Grpc.Core.CallOptions,object)
		// Grpc.Core.AsyncUnaryCall<object> Grpc.Core.CallInvoker.AsyncUnaryCall<object,object>(Grpc.Core.Method<object,object>,string,Grpc.Core.CallOptions,object)
		// object Grpc.Core.CallInvoker.BlockingUnaryCall<object,object>(Grpc.Core.Method<object,object>,string,Grpc.Core.CallOptions,object)
		// Grpc.Core.Marshaller<object> Grpc.Core.Marshallers.Create<object>(System.Action<object,Grpc.Core.SerializationContext>,System.Func<Grpc.Core.DeserializationContext,object>)
		// Grpc.Core.ServerServiceDefinition.Builder Grpc.Core.ServerServiceDefinition.Builder.AddMethod<object,object>(Grpc.Core.Method<object,object>,Grpc.Core.DuplexStreamingServerMethod<object,object>)
		// Grpc.Core.ServerServiceDefinition.Builder Grpc.Core.ServerServiceDefinition.Builder.AddMethod<object,object>(Grpc.Core.Method<object,object>,Grpc.Core.ServerStreamingServerMethod<object,object>)
		// Grpc.Core.ServerServiceDefinition.Builder Grpc.Core.ServerServiceDefinition.Builder.AddMethod<object,object>(Grpc.Core.Method<object,object>,Grpc.Core.UnaryServerMethod<object,object>)
		// System.Void Grpc.Core.ServiceBinderBase.AddMethod<object,object>(Grpc.Core.Method<object,object>,Grpc.Core.DuplexStreamingServerMethod<object,object>)
		// System.Void Grpc.Core.ServiceBinderBase.AddMethod<object,object>(Grpc.Core.Method<object,object>,Grpc.Core.ServerStreamingServerMethod<object,object>)
		// System.Void Grpc.Core.ServiceBinderBase.AddMethod<object,object>(Grpc.Core.Method<object,object>,Grpc.Core.UnaryServerMethod<object,object>)
		// object Newtonsoft.Json.JsonConvert.DeserializeObject<object>(string)
		// object Newtonsoft.Json.JsonConvert.DeserializeObject<object>(string,Newtonsoft.Json.JsonSerializerSettings)
		// object System.Activator.CreateInstance<object>()
		// System.Collections.Generic.KeyValuePair<object,object> System.Linq.Enumerable.ElementAt<System.Collections.Generic.KeyValuePair<object,object>>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>,int)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,ProtocalBag.<OpenBag>d__5>(System.Runtime.CompilerServices.TaskAwaiter&,ProtocalBag.<OpenBag>d__5&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<byte>,ProtocalBag.<>c__DisplayClass5_0.<<OpenBag>b__0>d>(System.Runtime.CompilerServices.TaskAwaiter<byte>&,ProtocalBag.<>c__DisplayClass5_0.<<OpenBag>b__0>d&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter,ProtocalBag.<OpenBag>d__5>(System.Runtime.CompilerServices.TaskAwaiter&,ProtocalBag.<OpenBag>d__5&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<byte>,ProtocalBag.<>c__DisplayClass5_0.<<OpenBag>b__0>d>(System.Runtime.CompilerServices.TaskAwaiter<byte>&,ProtocalBag.<>c__DisplayClass5_0.<<OpenBag>b__0>d&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,ProtocalLogin.<LoginIn>d__4>(System.Runtime.CompilerServices.TaskAwaiter<object>&,ProtocalLogin.<LoginIn>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,ProtocalRole.<RoleAddVipRequest>d__5>(System.Runtime.CompilerServices.TaskAwaiter<object>&,ProtocalRole.<RoleAddVipRequest>d__5&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,ProtocalRole.<RoleUpLvRequest>d__4>(System.Runtime.CompilerServices.TaskAwaiter<object>&,ProtocalRole.<RoleUpLvRequest>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<ProtocalBag.<>c__DisplayClass5_0.<<OpenBag>b__0>d>(ProtocalBag.<>c__DisplayClass5_0.<<OpenBag>b__0>d&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder.Start<ProtocalBag.<OpenBag>d__5>(ProtocalBag.<OpenBag>d__5&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<int>.Start<ProtocalLogin.<LoginIn>d__4>(ProtocalLogin.<LoginIn>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<ProtocalRole.<RoleAddVipRequest>d__5>(ProtocalRole.<RoleAddVipRequest>d__5&)
		// System.Void System.Runtime.CompilerServices.AsyncTaskMethodBuilder<object>.Start<ProtocalRole.<RoleUpLvRequest>d__4>(ProtocalRole.<RoleUpLvRequest>d__4&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<byte>,ProtocalBag.<ListenBag>d__2>(System.Runtime.CompilerServices.TaskAwaiter<byte>&,ProtocalBag.<ListenBag>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<byte>,ProtocalLogin.<ListenLogin>d__2>(System.Runtime.CompilerServices.TaskAwaiter<byte>&,ProtocalLogin.<ListenLogin>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<byte>,ProtocalRole.<ListenRole>d__2>(System.Runtime.CompilerServices.TaskAwaiter<byte>&,ProtocalRole.<ListenRole>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<byte>,ProtocalShop.<ListenShop>d__2>(System.Runtime.CompilerServices.TaskAwaiter<byte>&,ProtocalShop.<ListenShop>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<int>,Login.LoginMainView.<LoginMySql>d__20>(System.Runtime.CompilerServices.TaskAwaiter<int>&,Login.LoginMainView.<LoginMySql>d__20&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,RoleMainViewWin.<SetData>d__3>(System.Runtime.CompilerServices.TaskAwaiter<object>&,RoleMainViewWin.<SetData>d__3&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<Login.LoginMainView.<LoginMySql>d__20>(Login.LoginMainView.<LoginMySql>d__20&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<ProtocalBag.<ListenBag>d__2>(ProtocalBag.<ListenBag>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<ProtocalLogin.<ListenLogin>d__2>(ProtocalLogin.<ListenLogin>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<ProtocalRole.<ListenRole>d__2>(ProtocalRole.<ListenRole>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<ProtocalShop.<ListenShop>d__2>(ProtocalShop.<ListenShop>d__2&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<RoleMainViewWin.<SetData>d__3>(RoleMainViewWin.<SetData>d__3&)
		// System.Void UniFramework.Event.EventGroup.AddListener<object>(System.Action<UniFramework.Event.IEventMessage>)
		// object UnityEngine.Component.GetComponent<object>()
		// object UnityEngine.GameObject.AddComponent<object>()
		// object UnityEngine.GameObject.GetComponent<object>()
		// YooAsset.AssetHandle YooAsset.ResourcePackage.LoadAssetAsync<object>(string,uint)
		// YooAsset.AssetHandle YooAsset.YooAssets.LoadAssetAsync<object>(string,uint)
	}
}