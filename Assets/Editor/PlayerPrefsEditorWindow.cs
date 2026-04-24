#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace PlayerPrefsEditorTool
{
    public class PlayerPrefsEditorWindow : EditorWindow
    {
        [MenuItem("Tools/PlayerPrefs Editor")]
        public static void ShowWindow()
        {
            GetWindow<PlayerPrefsEditorWindow>("PlayerPrefs Editor");
        }

        private List<PrefEntry> prefEntries = new List<PrefEntry>();
        private Vector2 scrollPosition;
        private bool showSystemPrefs = false;
        private string searchFilter = "";
        private string newKey = "";
        private string newValue = "";
        private PrefType newType = PrefType.String;
        private float refreshInterval = 5f;
        private double lastRefreshTime = 0;
        private bool autoRefresh = false;
        
        private enum PrefType
        {
            String,
            Int,
            Float
        }
        
        [System.Serializable]
        private class PrefEntry
        {
            public string key;
            public string stringValue;
            public int intValue;
            public float floatValue;
            public PrefType type;
            public bool isEditing = false;
            public string editValue = "";
            
            public object GetValue()
            {
                switch (type)
                {
                    case PrefType.String: return stringValue;
                    case PrefType.Int: return intValue;
                    case PrefType.Float: return floatValue;
                    default: return stringValue;
                }
            }
            
            public string GetValueString()
            {
                switch (type)
                {
                    case PrefType.String: return stringValue;
                    case PrefType.Int: return intValue.ToString();
                    case PrefType.Float: return floatValue.ToString("F4");
                }
                return "";
            }
            
            public void UpdateValue(string newVal)
            {
                switch (type)
                {
                    case PrefType.String:
                        stringValue = newVal;
                        PlayerPrefs.SetString(key, newVal);
                        break;
                    case PrefType.Int:
                        if (int.TryParse(newVal, out int intResult))
                        {
                            intValue = intResult;
                            PlayerPrefs.SetInt(key, intResult);
                        }
                        break;
                    case PrefType.Float:
                        if (float.TryParse(newVal, out float floatResult))
                        {
                            floatValue = floatResult;
                            PlayerPrefs.SetFloat(key, floatResult);
                        }
                        break;
                }
                PlayerPrefs.Save();
            }
        }

        private void OnEnable()
        {
            RefreshPrefs();
            lastRefreshTime = EditorApplication.timeSinceStartup;
        }

        private void Update()
        {
            if (autoRefresh && EditorApplication.timeSinceStartup - lastRefreshTime > refreshInterval)
            {
                RefreshPrefs();
                lastRefreshTime = EditorApplication.timeSinceStartup;
                Repaint();
            }
        }

        private void OnGUI()
        {
            DrawToolbar();
            
            EditorGUILayout.Space();
            DrawAddNewPref();
            
            EditorGUILayout.Space();
            DrawPrefsList();
        }

        private void DrawToolbar()
        {
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
            
            if (GUILayout.Button("刷新", EditorStyles.toolbarButton, GUILayout.Width(50)))
            {
                RefreshPrefs();
            }
            
            if (GUILayout.Button("保存", EditorStyles.toolbarButton, GUILayout.Width(50)))
            {
                PlayerPrefs.Save();
                EditorUtility.DisplayDialog("保存成功", "PlayerPrefs 已保存", "确定");
            }
            
            GUILayout.FlexibleSpace();
            
            autoRefresh = GUILayout.Toggle(autoRefresh, "自动刷新", EditorStyles.toolbarButton);
            if (autoRefresh)
            {
                refreshInterval = EditorGUILayout.Slider(refreshInterval, 1f, 30f, GUILayout.Width(100));
            }
            
            showSystemPrefs = GUILayout.Toggle(showSystemPrefs, "显示系统键", EditorStyles.toolbarButton);
            
            if (GUILayout.Button("删除所有", EditorStyles.toolbarButton, GUILayout.Width(70)))
            {
                if (EditorUtility.DisplayDialog("警告", "确定要删除所有 PlayerPrefs 数据吗？此操作不可恢复！", "删除", "取消"))
                {
                    PlayerPrefs.DeleteAll();
                    PlayerPrefs.Save();
                    RefreshPrefs();
                }
            }
            
            if (GUILayout.Button("导出JSON", EditorStyles.toolbarButton, GUILayout.Width(70)))
            {
                ExportToJson();
            }
            
            if (GUILayout.Button("导入JSON", EditorStyles.toolbarButton, GUILayout.Width(70)))
            {
                ImportFromJson();
            }
            
            EditorGUILayout.EndHorizontal();
            
            // 搜索栏
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
            GUILayout.Label("搜索:", GUILayout.Width(40));
            searchFilter = EditorGUILayout.TextField(searchFilter, EditorStyles.toolbarSearchField);
            EditorGUILayout.EndHorizontal();
        }

        private void DrawAddNewPref()
        {
            EditorGUILayout.LabelField("添加新的 PlayerPref", EditorStyles.boldLabel);
            EditorGUILayout.BeginVertical("box");
            
            EditorGUILayout.BeginHorizontal();
            newKey = EditorGUILayout.TextField("键名", newKey);
            newType = (PrefType)EditorGUILayout.EnumPopup(newType, GUILayout.Width(100));
            EditorGUILayout.EndHorizontal();
            
            newValue = EditorGUILayout.TextField("值", newValue);
            
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            
            if (GUILayout.Button("添加", GUILayout.Width(60)))
            {
                if (!string.IsNullOrEmpty(newKey))
                {
                    switch (newType)
                    {
                        case PrefType.String:
                            PlayerPrefs.SetString(newKey, newValue);
                            break;
                        case PrefType.Int:
                            if (int.TryParse(newValue, out int intVal))
                                PlayerPrefs.SetInt(newKey, intVal);
                            break;
                        case PrefType.Float:
                            if (float.TryParse(newValue, out float floatVal))
                                PlayerPrefs.SetFloat(newKey, floatVal);
                            break;
                    }
                    PlayerPrefs.Save();
                    RefreshPrefs();
                    newKey = "";
                    newValue = "";
                }
            }
            
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
        }

        private void DrawPrefsList()
        {
            EditorGUILayout.LabelField($"PlayerPrefs 列表 ({prefEntries.Count})", EditorStyles.boldLabel);
            
            if (prefEntries.Count == 0)
            {
                EditorGUILayout.HelpBox("没有找到 PlayerPrefs 数据", MessageType.Info);
                return;
            }
            
            // 表头
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
            GUILayout.Label("键名", GUILayout.Width(200));
            GUILayout.Label("值", GUILayout.Width(200));
            GUILayout.Label("类型", GUILayout.Width(60));
            GUILayout.Label("操作", GUILayout.Width(150));
            EditorGUILayout.EndHorizontal();
            
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
            
            int displayedCount = 0;
            var filteredPrefs = string.IsNullOrEmpty(searchFilter) 
                ? prefEntries 
                : prefEntries.Where(p => p.key.ToLower().Contains(searchFilter.ToLower())).ToList();
            
            for (int i = 0; i < filteredPrefs.Count; i++)
            {
                var entry = filteredPrefs[i];
                
                // 跳过系统键（如果需要）
                if (!showSystemPrefs && IsSystemKey(entry.key))
                    continue;
                
                EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
                
                // 键名
                EditorGUILayout.LabelField(entry.key, GUILayout.Width(200));
                
                // 值显示/编辑
                if (entry.isEditing)
                {
                    entry.editValue = EditorGUILayout.TextField(entry.editValue, GUILayout.Width(200));
                }
                else
                {
                    EditorGUILayout.LabelField(entry.GetValueString(), GUILayout.Width(200));
                }
                
                // 类型
                EditorGUILayout.LabelField(entry.type.ToString(), GUILayout.Width(60));
                
                // 操作按钮
                EditorGUILayout.BeginHorizontal(GUILayout.Width(150));
                
                if (entry.isEditing)
                {
                    if (GUILayout.Button("保存", GUILayout.Width(40)))
                    {
                        entry.UpdateValue(entry.editValue);
                        entry.isEditing = false;
                        RefreshPrefs();
                    }
                    
                    if (GUILayout.Button("取消", GUILayout.Width(40)))
                    {
                        entry.isEditing = false;
                    }
                }
                else
                {
                    if (GUILayout.Button("编辑", GUILayout.Width(40)))
                    {
                        entry.isEditing = true;
                        entry.editValue = entry.GetValueString();
                    }
                    
                    if (GUILayout.Button("删除", GUILayout.Width(40)))
                    {
                        if (EditorUtility.DisplayDialog("确认删除", $"确定要删除键 '{entry.key}' 吗？", "删除", "取消"))
                        {
                            PlayerPrefs.DeleteKey(entry.key);
                            PlayerPrefs.Save();
                            RefreshPrefs();
                        }
                    }
                    
                    if (GUILayout.Button("复制", GUILayout.Width(40)))
                    {
                        GUIUtility.systemCopyBuffer = $"{entry.key}: {entry.GetValueString()}";
                        EditorUtility.DisplayDialog("复制成功", "已复制到剪贴板", "确定");
                    }
                }
                
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.EndHorizontal();
                
                displayedCount++;
            }
            
            EditorGUILayout.EndScrollView();
            
            if (displayedCount == 0 && filteredPrefs.Count > 0)
            {
                EditorGUILayout.HelpBox("搜索无结果或已过滤系统键", MessageType.Info);
            }
        }

        private bool IsSystemKey(string key)
        {
            return key.StartsWith("Unity") || 
                   key.StartsWith("GraphicsJobs") || 
                   key.StartsWith("cloud.") ||
                   key.Contains("Editor") ||
                   key.Contains("Cache");
        }

        private void RefreshPrefs()
        {
            prefEntries.Clear();
            
            // 在Windows编辑器下从注册表获取
            #if UNITY_EDITOR_WIN
            GetPrefsFromWindowsRegistry();
            #endif
            
            // 在其他平台或作为备用的通用方法
            GetPrefsGeneric();
            
            prefEntries = prefEntries.OrderBy(p => p.key).ToList();
        }

        #if UNITY_EDITOR_WIN
        private void GetPrefsFromWindowsRegistry()
        {
            try
            {
                // 尝试不同的注册表路径
                string[] registryPaths = {
                    @"Software\" + PlayerSettings.companyName + @"\" + PlayerSettings.productName,
                    @"Software\Unity\UnityEditor\" + PlayerSettings.companyName + @"\" + PlayerSettings.productName
                };
                
                foreach (string registryPath in registryPaths)
                {
                    try
                    {
                        var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(registryPath);
                        if (key != null)
                        {
                            foreach (string valueName in key.GetValueNames())
                            {
                                if (string.IsNullOrEmpty(valueName)) continue;
                                
                                object value = key.GetValue(valueName);
                                AddPrefEntry(valueName, value);
                            }
                            key.Close();
                        }
                    }
                    catch { }
                }
            }
            catch (Exception e)
            {
                Debug.LogWarning("从注册表读取 PlayerPrefs 失败: " + e.Message);
            }
        }
        #endif

        private void GetPrefsGeneric()
        {
            // 尝试常见的数据类型
            TryGetPrefsByPattern();
        }

        private void TryGetPrefsByPattern()
        {
            // 这里可以添加你知道的键名模式
            string[] knownKeys = GetAllPossibleKeys();
            
            foreach (string key in knownKeys)
            {
                if (PlayerPrefs.HasKey(key))
                {
                    // 检查数据类型
                    if (PlayerPrefs.GetString(key, null) != null)
                    {
                        var entry = new PrefEntry
                        {
                            key = key,
                            stringValue = PlayerPrefs.GetString(key),
                            type = PrefType.String
                        };
                        AddIfNotExists(entry);
                    }
                }
            }
        }

        private string[] GetAllPossibleKeys()
        {
            List<string> keys = new List<string>();
            
            // 常见的Unity PlayerPrefs键
            keys.AddRange(new string[]
            {
                // 图形设置
                "Screenmanager Resolution Width",
                "Screenmanager Resolution Height",
                "Screenmanager Is Fullscreen mode",
                "UnityGraphicsQuality",
                "UnitySelectMonitor",
                
                // 音频设置
                "MasterVolume",
                "MusicVolume",
                "SFXVolume",
                "VoiceVolume",
                
                // 游戏设置
                "Language",
                "Subtitles",
                "InvertY",
                "MouseSensitivity",
                "ControllerSensitivity",
                
                // 进度
                "CurrentLevel",
                "HighScore",
                "TotalScore",
                "PlayTime",
                "LastSave",
                
                // 存档
                "SaveSlot",
                "AutoSave",
                "Checkpoint",
                
                // 成就
                "Achievement_",
                "Trophy_",
                "Unlocked_",
                
                // 货币
                "Coins",
                "Gems",
                "Gold",
                "Diamonds",
                
                // 玩家
                "PlayerName",
                "PlayerLevel",
                "PlayerEXP",
                "PlayerHealth",
                "PlayerMana",
                
                // 系统
                "FirstLaunch",
                "TutorialComplete",
                "AgreedToTerms"
            });
            
            return keys.ToArray();
        }

        private void AddPrefEntry(string key, object value)
        {
            if (string.IsNullOrEmpty(key) || prefEntries.Any(p => p.key == key))
                return;
            
            var entry = new PrefEntry { key = key };
            
            if (value is int intVal)
            {
                entry.type = PrefType.Int;
                entry.intValue = intVal;
            }
            else if (value is float floatVal)
            {
                entry.type = PrefType.Float;
                entry.floatValue = floatVal;
            }
            else if (value is string strVal)
            {
                entry.type = PrefType.String;
                entry.stringValue = strVal;
                
                // 尝试解析为数字
                if (int.TryParse(strVal, out int parsedInt))
                {
                    entry.type = PrefType.Int;
                    entry.intValue = parsedInt;
                }
                else if (float.TryParse(strVal, out float parsedFloat))
                {
                    entry.type = PrefType.Float;
                    entry.floatValue = parsedFloat;
                }
            }
            else
            {
                entry.type = PrefType.String;
                entry.stringValue = value?.ToString() ?? "";
            }
            
            prefEntries.Add(entry);
        }

        private void AddIfNotExists(PrefEntry newEntry)
        {
            if (!prefEntries.Any(p => p.key == newEntry.key))
            {
                prefEntries.Add(newEntry);
            }
        }

        private void ExportToJson()
        {
            var exportData = new PrefsExportData
            {
                exportTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                prefs = new List<PrefExportEntry>()
            };
            
            foreach (var entry in prefEntries)
            {
                exportData.prefs.Add(new PrefExportEntry
                {
                    key = entry.key,
                    value = entry.GetValueString(),
                    type = entry.type.ToString()
                });
            }
            
            string json = JsonUtility.ToJson(exportData, true);
            string path = EditorUtility.SaveFilePanel("导出 PlayerPrefs", "", "playerprefs_export.json", "json");
            
            if (!string.IsNullOrEmpty(path))
            {
                System.IO.File.WriteAllText(path, json, Encoding.UTF8);
                EditorUtility.DisplayDialog("导出成功", $"已导出 {exportData.prefs.Count} 条数据到:\n{path}", "确定");
            }
        }

        private void ImportFromJson()
        {
            string path = EditorUtility.OpenFilePanel("导入 PlayerPrefs", "", "json");
            
            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    string json = System.IO.File.ReadAllText(path, Encoding.UTF8);
                    var importData = JsonUtility.FromJson<PrefsExportData>(json);
                    
                    int importedCount = 0;
                    foreach (var entry in importData.prefs)
                    {
                        switch (entry.type.ToLower())
                        {
                            case "string":
                                PlayerPrefs.SetString(entry.key, entry.value);
                                break;
                            case "int":
                                if (int.TryParse(entry.value, out int intVal))
                                    PlayerPrefs.SetInt(entry.key, intVal);
                                break;
                            case "float":
                                if (float.TryParse(entry.value, out float floatVal))
                                    PlayerPrefs.SetFloat(entry.key, floatVal);
                                break;
                        }
                        importedCount++;
                    }
                    
                    PlayerPrefs.Save();
                    RefreshPrefs();
                    
                    EditorUtility.DisplayDialog("导入成功", $"成功导入 {importedCount} 条数据", "确定");
                }
                catch (Exception e)
                {
                    EditorUtility.DisplayDialog("导入失败", "导入JSON时出错: " + e.Message, "确定");
                }
            }
        }
        
        [System.Serializable]
        private class PrefsExportData
        {
            public string exportTime;
            public List<PrefExportEntry> prefs;
        }
        
        [System.Serializable]
        private class PrefExportEntry
        {
            public string key;
            public string value;
            public string type;
        }
    }
}
#endif