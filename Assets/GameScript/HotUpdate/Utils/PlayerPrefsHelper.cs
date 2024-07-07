using System;
using UnityEngine;

public static class PlayerPrefsHelper
{
    const string encryptKey = "1234567890HYFFra";// Must be 16 bytes
    const string encryptVector = "1234567890Client";
    static string projectPath = Application.dataPath;

    public static bool HasKey(string prefKey)
    {
        return PlayerPrefs.HasKey(prefKey);
    }

    public static void DeleteKey(string prefKey)
    {
        PlayerPrefs.DeleteKey(prefKey);
    }

    public static void ClearAll()
    {
        PlayerPrefs.DeleteAll();
    }

    #region SetData

    public static void SetFloat(string prefKey, float value)
    {
        prefKey = $"{prefKey}_{projectPath}";
        PlayerPrefs.SetFloat(prefKey, value);
    }

    public static void SetInteger(string prefKey, int value)
    {
        prefKey = $"{prefKey}_{projectPath}";
        PlayerPrefs.SetInt(prefKey, value);
    }

    public static void SetBool(string prefKey, bool value)
    {
        prefKey = $"{prefKey}_{projectPath}";
        int convertedValue = BoolToInteger(value);
        PlayerPrefs.SetInt(prefKey, convertedValue);
    }

    public static void SetString(string prefKey, string value)
    {
        prefKey = $"{prefKey}_{projectPath}";
        string encryptedValue = EncryptUtils.DESEncrypt(value, encryptKey, encryptVector);
        Debuger.Log($"保存key:[{prefKey}],内容:[{value}]");
        PlayerPrefs.SetString(prefKey, encryptedValue);
    }

    public static void SetEnum(string prefKey, Enum value)
    {
        prefKey = $"{prefKey}_{projectPath}";
        string encryptedStrValue = EncryptUtils.DESEncrypt(value.ToString(), encryptKey, encryptVector);
        PlayerPrefs.SetString(prefKey, encryptedStrValue);
    }

    public static void SetDateTime(string prefKey, DateTime? value)
    {
        prefKey = $"{prefKey}_{projectPath}";
        string encryptedDateTime = EncryptUtils.DESEncrypt(value.ToString(), encryptKey, encryptVector);
        PlayerPrefs.SetString(prefKey, encryptedDateTime);
    }

    public static void SetCustom<T>(string prefKey, T value)
    {
        prefKey = $"{prefKey}_{projectPath}";
        string json = JsonUtility.ToJson(value);
        string encryptedJson = EncryptUtils.DESEncrypt(json, encryptKey, encryptVector);
        PlayerPrefs.SetString(prefKey, encryptedJson);
    }

    #endregion

    #region GetData

    public static float GetFloat(string prefKey, float defaultValue = 0f)
    {
        prefKey = $"{prefKey}_{projectPath}";
        if (!PlayerPrefs.HasKey(prefKey))
            return defaultValue;
        return PlayerPrefs.GetFloat(prefKey);
    }

    public static int GetInteger(string prefKey, int defaultValue = 0)
    {
        prefKey = $"{prefKey}_{projectPath}";
        if (!PlayerPrefs.HasKey(prefKey))
            return defaultValue;
        return PlayerPrefs.GetInt(prefKey);
    }

    public static bool GetBool(string prefKey, bool defaultValue = false)
    {
        prefKey = $"{prefKey}_{projectPath}";
        if (!PlayerPrefs.HasKey(prefKey))
            return defaultValue;
        int intValue = PlayerPrefs.GetInt(prefKey);
        return IntToBool(intValue);
    }

    public static string GetString(string prefKey, string defaultValue = "")
    {
        prefKey = $"{prefKey}_{projectPath}";
        string encryptedValue = PlayerPrefs.GetString(prefKey);
        if (!PlayerPrefs.HasKey(prefKey) || encryptedValue == "")
            return defaultValue;
        return EncryptUtils.DESDecrypt(encryptedValue, encryptKey, encryptVector);
    }

    public static T GetEnum<T>(string prefKey, T defaultValue) where T : Enum
    {
        prefKey = $"{prefKey}_{projectPath}";
        string encryptedStrValue = PlayerPrefs.GetString(prefKey);
        if (!PlayerPrefs.HasKey(prefKey) || encryptedStrValue == "")
            return defaultValue;

        string strValue = EncryptUtils.DESDecrypt(encryptedStrValue, encryptKey, encryptVector);
        var value = Enum.Parse(typeof(T), strValue);
        return (T)value;
    }

    public static DateTime? GetDateTime(string prefKey, DateTime? defaultValue = null)
    {
        prefKey = $"{prefKey}_{projectPath}";
        string encryptedDateTimeString = PlayerPrefs.GetString(prefKey);
        if (!PlayerPrefs.HasKey(prefKey))
            return defaultValue;

        string dateTimeString = EncryptUtils.DESDecrypt(encryptedDateTimeString, encryptKey, encryptVector);
        DateTime? loadedDateTime;
        try
        {
            loadedDateTime = DateTime.Parse(dateTimeString);
        }
        catch
        {
            loadedDateTime = null;
        }

        return loadedDateTime;
    }

    public static T GetCustom<T>(string prefKey, T defaultValue = default)
    {
        prefKey = $"{prefKey}_{projectPath}";
        if (!PlayerPrefs.HasKey(prefKey))
        {
            return defaultValue;
        }

        string json = GetString(prefKey);
        var result = JsonUtility.FromJson<T>(json);
        return result;
    }

    #endregion

    #region Convertion

    private static int BoolToInteger(bool value)
    {
        if (value)
            return 1;
        return 0;
    }

    private static bool IntToBool(int value)
    {
        return value != 0;
    }

    #endregion
}