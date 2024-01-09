using UnityEditor;
using UnityEngine;
// https://blog.csdn.net/nanyupeng/article/details/121577122
public class AudioImportSetting : AssetPostprocessor
{
    void OnPostprocessAudio(AudioClip audio)
    {
        AudioImporter audioImpoter = this.assetImporter as AudioImporter;
        audioImpoter.forceToMono = true;//单声道
                                        // Debug.Log(audio.length);

        AudioImporterSampleSettings windowSetting = audioImpoter.GetOverrideSampleSettings("Standalone");
        AudioImporterSampleSettings androidSetting = audioImpoter.GetOverrideSampleSettings("Android");
        AudioImporterSampleSettings iPhoneSetting = audioImpoter.GetOverrideSampleSettings("iPhone");

        if (IsBackgroundMusic(audioImpoter.assetPath))
        {//BGM 长音频 播放时间>=5秒
            windowSetting.loadType = androidSetting.loadType = iPhoneSetting.loadType = AudioClipLoadType.Streaming;
            windowSetting.compressionFormat = androidSetting.compressionFormat = iPhoneSetting.compressionFormat = AudioCompressionFormat.Vorbis;
        }
        else if (IsFGUIMusic(audioImpoter.assetPath))
        {//时延敏感的短音频 播放时间<1秒
            windowSetting.loadType = androidSetting.loadType = iPhoneSetting.loadType = AudioClipLoadType.DecompressOnLoad;//加载后解压缩（适合小音效）
            windowSetting.compressionFormat = androidSetting.compressionFormat = iPhoneSetting.compressionFormat = AudioCompressionFormat.ADPCM;
        }
        else
        {
            if (audio.length < 1.1f)
            {
                windowSetting.loadType = androidSetting.loadType = iPhoneSetting.loadType = AudioClipLoadType.DecompressOnLoad;//小于1秒的 用 DecompressOnLoad
                windowSetting.compressionFormat = androidSetting.compressionFormat = iPhoneSetting.compressionFormat = AudioCompressionFormat.Vorbis;
            }
            else if (audio.length > 3.0f)
            {
                windowSetting.loadType = androidSetting.loadType = iPhoneSetting.loadType = AudioClipLoadType.Streaming;//大于3秒的 用 Streaming
                windowSetting.compressionFormat = androidSetting.compressionFormat = iPhoneSetting.compressionFormat = AudioCompressionFormat.Vorbis;
            }
            else
            {
                windowSetting.loadType = androidSetting.loadType = iPhoneSetting.loadType = AudioClipLoadType.CompressedInMemory;
                windowSetting.compressionFormat = androidSetting.compressionFormat = iPhoneSetting.compressionFormat = AudioCompressionFormat.Vorbis;
            }
        }
        //采样率
        windowSetting.sampleRateSetting = androidSetting.sampleRateSetting = iPhoneSetting.sampleRateSetting = AudioSampleRateSetting.OverrideSampleRate;
        windowSetting.sampleRateOverride = androidSetting.sampleRateOverride = iPhoneSetting.sampleRateOverride = 22050;


        var isPre = PreloadLoadBG(audioImpoter.assetPath);
        if (isPre)
        {
            audioImpoter.loadInBackground = true;  //不去做设置   true=多线程加载   类似于UI异步加载的样子 怕不同步 阻塞   
            // audioImpoter.preloadAudioData = false;
        }
   

        audioImpoter.SetOverrideSampleSettings("Standalone", windowSetting);
        audioImpoter.SetOverrideSampleSettings("Android", androidSetting);
        audioImpoter.SetOverrideSampleSettings("iPhone", iPhoneSetting);
    }

    static bool IsBackgroundMusic(string path)
    {
        return path.Replace("\\", "/").Contains(@"GameRes/Audio/");
    }

    static bool PreloadLoadBG(string path)
    {
        return path.Contains("effect") || path.Contains("Effect");
    }

    static bool IsFGUIMusic(string path)
    {
        return path.Replace("\\", "/").Contains(@"GameRes/fgui/");
    }
}
