using UnityEditor;
public class TextureImporterSetting : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
        TextureImporter teximporter = this.assetImporter as TextureImporter;
        if (Is_Ignore(teximporter.assetPath))
            return;

        teximporter.sRGBTexture = true;
        teximporter.mipmapEnabled = false;

        TextureImporterPlatformSettings windowSetting = teximporter.GetPlatformTextureSettings("Standalone");
        windowSetting.overridden = true;
        windowSetting.format = TextureImporterFormat.DXT5Crunched;

        TextureImporterPlatformSettings webGLSetting = teximporter.GetPlatformTextureSettings("WebGL");
        webGLSetting.overridden = true;
        webGLSetting.maxTextureSize = 1024;
        webGLSetting.format = TextureImporterFormat.DXT5;

        TextureImporterPlatformSettings androidSetting = teximporter.GetPlatformTextureSettings("Android");
        androidSetting.overridden = true;
        TextureImporterPlatformSettings iPhoneSetting = teximporter.GetPlatformTextureSettings("iPhone");
        iPhoneSetting.overridden = true;


        bool is_UIFguiRes = Is_UI_FguiRes(teximporter.assetPath);
        if (is_UIFguiRes)
        {
            teximporter.textureType = TextureImporterType.Default;
            teximporter.textureShape = TextureImporterShape.Texture2D;
            teximporter.alphaIsTransparency = true;
        }

        if (teximporter.textureType == TextureImporterType.NormalMap) //法线贴图
        {
            androidSetting.format = TextureImporterFormat.ASTC_5x5;
            iPhoneSetting.format = TextureImporterFormat.ASTC_5x5;
        }
        else
        {
            if (is_UIFguiRes || Is_Effects(teximporter.assetPath))
            {
                if (androidSetting.format == TextureImporterFormat.Automatic) //导入时 默认使用8*8
                {
                    androidSetting.format = TextureImporterFormat.ASTC_8x8;
                    iPhoneSetting.format = TextureImporterFormat.ASTC_8x8;
                }
            }
            else if (teximporter.DoesSourceTextureHaveAlpha())
            {
                if (androidSetting.format == TextureImporterFormat.Automatic) //导入时 默认使用6*6
                {
                    androidSetting.format = TextureImporterFormat.ASTC_6x6;
                    iPhoneSetting.format = TextureImporterFormat.ASTC_6x6;
                }
            }
            else
            {
                androidSetting.format = TextureImporterFormat.ASTC_8x8;
                iPhoneSetting.format = TextureImporterFormat.ASTC_8x8;
            }
        }

        teximporter.SetPlatformTextureSettings(windowSetting);
        teximporter.SetPlatformTextureSettings(androidSetting);
        teximporter.SetPlatformTextureSettings(iPhoneSetting);
        teximporter.SetPlatformTextureSettings(webGLSetting);
    }

    
    static bool Is_UI_FguiRes(string path)
    {
        return path.Replace("\\", "/").Contains(@"GameRes/fgui");
    }

    static bool Is_Effects(string path)
    {
        return path.Replace("\\", "/").Contains(@"GameArt/Effect/");
    }

    static bool Is_Ignore(string path)
    {
        return path.Contains("/Editor/") || path.Contains("/3rd/") || path.Contains("/Unity-Logs-Viewer/");
    }
}
