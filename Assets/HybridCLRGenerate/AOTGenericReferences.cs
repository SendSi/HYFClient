using System.Collections.Generic;
public class AOTGenericReferences : UnityEngine.MonoBehaviour
{

	// {{ AOT assemblies
	public static readonly IReadOnlyList<string> PatchedAOTAssemblyList = new List<string>
	{
		"AOT.dll",
		"Luban.Runtime.dll",
		"Newtonsoft.Json.dll",
		"System.Core.dll",
		"UnityEngine.CoreModule.dll",
		"UnityEngine.JSONSerializeModule.dll",
		"YooAsset.dll",
		"mscorlib.dll",
	};
	// }}

	// {{ constraint implement type
	// }} 

	// {{ AOT generic types
	// EventOne<int>
	// EventOne<object>
	// Singleton<object>
	// System.Action<int,byte,int>
	// System.Action<int>
	// System.Action<object>
	// System.ArraySegment.Enumerator<ushort>
	// System.ArraySegment<ushort>
	// System.ByReference<ushort>
	// System.Collections.Generic.ArraySortHelper<int>
	// System.Collections.Generic.ArraySortHelper<object>
	// System.Collections.Generic.Comparer<int>
	// System.Collections.Generic.Comparer<object>
	// System.Collections.Generic.Dictionary.Enumerator<float,object>
	// System.Collections.Generic.Dictionary.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.Enumerator<uint,UnityEngine.Vector3>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<float,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<uint,UnityEngine.Vector3>
	// System.Collections.Generic.Dictionary.KeyCollection<float,object>
	// System.Collections.Generic.Dictionary.KeyCollection<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection<uint,UnityEngine.Vector3>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<float,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<uint,UnityEngine.Vector3>
	// System.Collections.Generic.Dictionary.ValueCollection<float,object>
	// System.Collections.Generic.Dictionary.ValueCollection<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection<uint,UnityEngine.Vector3>
	// System.Collections.Generic.Dictionary<float,object>
	// System.Collections.Generic.Dictionary<int,object>
	// System.Collections.Generic.Dictionary<object,object>
	// System.Collections.Generic.Dictionary<uint,UnityEngine.Vector3>
	// System.Collections.Generic.EqualityComparer<UnityEngine.Vector3>
	// System.Collections.Generic.EqualityComparer<float>
	// System.Collections.Generic.EqualityComparer<int>
	// System.Collections.Generic.EqualityComparer<object>
	// System.Collections.Generic.EqualityComparer<uint>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<float,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<uint,UnityEngine.Vector3>>
	// System.Collections.Generic.ICollection<int>
	// System.Collections.Generic.ICollection<object>
	// System.Collections.Generic.IComparer<int>
	// System.Collections.Generic.IComparer<object>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<float,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<uint,UnityEngine.Vector3>>
	// System.Collections.Generic.IEnumerable<int>
	// System.Collections.Generic.IEnumerable<object>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<float,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<uint,UnityEngine.Vector3>>
	// System.Collections.Generic.IEnumerator<int>
	// System.Collections.Generic.IEnumerator<object>
	// System.Collections.Generic.IEqualityComparer<float>
	// System.Collections.Generic.IEqualityComparer<int>
	// System.Collections.Generic.IEqualityComparer<object>
	// System.Collections.Generic.IEqualityComparer<uint>
	// System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<float,object>>
	// System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IList<int>
	// System.Collections.Generic.IList<object>
	// System.Collections.Generic.KeyValuePair<float,object>
	// System.Collections.Generic.KeyValuePair<int,object>
	// System.Collections.Generic.KeyValuePair<object,object>
	// System.Collections.Generic.KeyValuePair<uint,UnityEngine.Vector3>
	// System.Collections.Generic.List.Enumerator<int>
	// System.Collections.Generic.List.Enumerator<object>
	// System.Collections.Generic.List<int>
	// System.Collections.Generic.List<object>
	// System.Collections.Generic.ObjectComparer<int>
	// System.Collections.Generic.ObjectComparer<object>
	// System.Collections.Generic.ObjectEqualityComparer<UnityEngine.Vector3>
	// System.Collections.Generic.ObjectEqualityComparer<float>
	// System.Collections.Generic.ObjectEqualityComparer<int>
	// System.Collections.Generic.ObjectEqualityComparer<object>
	// System.Collections.Generic.ObjectEqualityComparer<uint>
	// System.Collections.Generic.Queue.Enumerator<object>
	// System.Collections.Generic.Queue<object>
	// System.Collections.ObjectModel.ReadOnlyCollection<int>
	// System.Collections.ObjectModel.ReadOnlyCollection<object>
	// System.Comparison<int>
	// System.Comparison<object>
	// System.Func<object,object>
	// System.IEquatable<ushort>
	// System.Nullable<System.DateTime>
	// System.Nullable<long>
	// System.Numerics.Vector<ulong>
	// System.Numerics.Vector<ushort>
	// System.Predicate<int>
	// System.Predicate<object>
	// System.ReadOnlySpan.Enumerator<ushort>
	// System.ReadOnlySpan<ushort>
	// System.Span<ushort>
	// UnityEngine.Events.UnityAction<int>
	// UnityEngine.Events.UnityAction<object>
	// }}

	public void RefMethods()
	{
		// System.Void EventCenter.Bind<int>(int,UnityEngine.Events.UnityAction<int>)
		// System.Void EventCenter.Bind<object>(int,UnityEngine.Events.UnityAction<object>)
		// System.Void EventCenter.Fire<object>(int,object)
		// System.Void EventCenter.UnBind<int>(int,UnityEngine.Events.UnityAction<int>)
		// System.Void EventCenter.UnBind<object>(int,UnityEngine.Events.UnityAction<object>)
		// string Luban.StringUtil.CollectionToString<object>(System.Collections.Generic.IEnumerable<object>)
		// object Newtonsoft.Json.JsonConvert.DeserializeObject<object>(string)
		// object Newtonsoft.Json.JsonConvert.DeserializeObject<object>(string,Newtonsoft.Json.JsonSerializerSettings)
		// object System.Activator.CreateInstance<object>()
		// System.Collections.Generic.KeyValuePair<float,object> System.Linq.Enumerable.ElementAt<System.Collections.Generic.KeyValuePair<float,object>>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<float,object>>,int)
		// System.Collections.Generic.KeyValuePair<object,object> System.Linq.Enumerable.ElementAt<System.Collections.Generic.KeyValuePair<object,object>>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>,int)
		// int System.MemoryExtensions.IndexOf<ushort>(System.ReadOnlySpan<ushort>,ushort)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<Bag.BagMainView.<OnClickUsing>d__12>(Bag.BagMainView.<OnClickUsing>d__12&)
		// System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<Login.LoginMainView.<LoginMySql>d__11>(Login.LoginMainView.<LoginMySql>d__11&)
		// ushort& System.Runtime.CompilerServices.Unsafe.Add<ushort>(ushort&,System.IntPtr)
		// byte& System.Runtime.CompilerServices.Unsafe.As<ushort,byte>(ushort&)
		// ushort& System.Runtime.CompilerServices.Unsafe.As<ushort,ushort>(ushort&)
		// ushort& System.Runtime.InteropServices.MemoryMarshal.GetReference<ushort>(System.ReadOnlySpan<ushort>)
		// int System.SpanHelpers.IndexOf<ushort>(ushort&,ushort,int)
		// object UnityEngine.GameObject.AddComponent<object>()
		// object[] UnityEngine.GameObject.GetComponentsInChildren<object>(bool)
		// object UnityEngine.JsonUtility.FromJson<object>(string)
		// YooAsset.AssetHandle YooAsset.ResourcePackage.LoadAssetAsync<object>(string,uint)
		// YooAsset.AssetHandle YooAsset.YooAssets.LoadAssetAsync<object>(string,uint)
		// string string.Join<object>(string,System.Collections.Generic.IEnumerable<object>)
		// string string.JoinCore<object>(System.Char*,int,System.Collections.Generic.IEnumerable<object>)
	}
}