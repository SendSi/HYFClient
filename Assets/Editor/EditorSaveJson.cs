using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

[InfoBox("有时需要保存在本地的Json文件...使用EditorPrefs或PlayerPrefs 总有自己的局限性\r\n此处已做示例啦")]
public class EditorSaveJson : OdinEditorWindow
{
    [MenuItem("Tools/测试/保存_读取_自定义的json")]
    private static void OpenWindow()
    {
        var window = GetWindow<EditorSaveJson>();
        window.position = GUIHelper.GetEditorWindowRect().AlignCenter(550, 300);
    }

    [Header("prefab预制物")] public GameObject prefabFather;
    [Header("保存的文件名称")] public string saveName = "Save_";

    [Button("存为_列表", 30), HorizontalGroup("list1", Width = 0.5f)]
    private void GenJsonConfigList()
    {
        List<GoTransPos> saveList = new List<GoTransPos>();
        var childs = prefabFather.GetComponentsInChildren<Transform>();
        foreach (var trans in childs)
        {
            saveList.Add(new GoTransPos(trans.gameObject.name, trans.localPosition));
        }

        string jsonFilePath = $"Assets\\GameScript\\HotUpdate\\Config\\json\\{saveName}.json";
        string jsonString = JsonConvert.SerializeObject(saveList);
        File.WriteAllText(jsonFilePath, jsonString);

        AssetDatabase.Refresh();
    }

    [Button("读取_列表", 30), HorizontalGroup("list1", Width = 0.5f)]
    private void ReadJsonList()
    {
        var list = CfgJsonMgr.Instance.LoadConfigList<GoTransPos>(saveName);

        foreach (var item in list)
        {
            Debug.LogError($"{item.name}  {item.posX}  {item.posY} {item.posZ}");
        }
    }

    [Button("存为_字典", 30), HorizontalGroup("dic1", Width = 0.5f)]
    private void GenJsonConfigDic()
    {
        Dictionary<string, GoTransPos> saveDic = new Dictionary<string, GoTransPos>();
        var childs = prefabFather.GetComponentsInChildren<Transform>();
        foreach (var trans in childs)
        {
            saveDic[trans.gameObject.name] = (new GoTransPos(trans.gameObject.name, trans.localPosition));
        }

        string jsonFilePath = $"Assets\\GameScript\\HotUpdate\\Config\\json\\{saveName}.json";
        string jsonString = JsonConvert.SerializeObject(saveDic);
        File.WriteAllText(jsonFilePath, jsonString);

        AssetDatabase.Refresh();
    }

    [Button("读取_字典", 30), HorizontalGroup("dic1", Width = 0.5f)]
    private void ReadJsonDic()
    {
        Debug.LogError("字典所有");
        var list = CfgJsonMgr.Instance.LoadConfigDics<GoTransPos>(saveName);
        foreach (var item in list)
        {
            Debug.Log($"{item.Value.name}  {item.Value.posX}  {item.Value.posY} {item.Value.posZ}");
        }
        
        Debug.LogError("字典取key");
        
        var oneItem = CfgJsonMgr.Instance.LoadConfigOne<GoTransPos>("tilePre", saveName);
        Debug.Log($"{oneItem.name}  {oneItem.posX}");
    }
}

[HideInEditorMode]
public class GoTransPos
{
    public float posX { get; set; }
    public float posY { get; set; }
    public float posZ { get; set; }
    public string name { get; set; }

    public GoTransPos(string pName, Vector3 v3Pos)
    {
        this.posX = v3Pos.x;
        this.posY = v3Pos.y;
        this.posZ = v3Pos.z;
        this.name = pName;
    }
}