using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YooAsset;
using Random = UnityEngine.Random;

/// <summary>
/// 声效   后面应该用导表来控制吧
/// </summary>
public class AudioMgr : Singleton<AudioMgr>
{
    private Transform _soundRootTr; //默认父节点
    private Queue<AudioSource> _audioPools; //普通池
    private AudioSource _audioBGM; //bgm不入池   独占
    private const string _prefsKey = "bgm_music_volume";
    private AssetHandle _bgmAssHandle;
    private float mCurTimeNum = 0; //当前运行的时间
    private Dictionary<float, AudioSource> mLoadAudioPool; //加载完后 等待加入队列池的对象
    private Dictionary<float, AssetHandle> mLoadAssetHandes; //加载完后 等待加入 释放的handler   跟audioClip的时长有关

    protected override void OnInit()
    {
        base.OnInit();
        _audioPools = new Queue<AudioSource>();
        mLoadAudioPool = new Dictionary<float, AudioSource>(); //加载完后 等待加入队列池的对象
        mLoadAssetHandes = new Dictionary<float, AssetHandle>(); //加载完后 等待加入 释放的handler   跟audioClip的时长有关
        var tRoot = new GameObject("SoundRoot");
        GameObject.DontDestroyOnLoad(tRoot);
        _soundRootTr = tRoot.transform; // _soundRootTr.localPosition = Vector3.zero;// _soundRootTr.localScale = Vector3.one;// _soundRootTr.localEulerAngles = Vector3.zero;

        var bgm = new GameObject("bgm");
        bgm.transform.SetParent(_soundRootTr);
        _audioBGM = bgm.AddComponent<AudioSource>();

        var bgm_music_volume = PlayerPrefs.GetString(_prefsKey, "0.66;0.66");
        var bm = bgm_music_volume.Split(";");
        AppConfig.bgmVolume = float.Parse(bm[0]);
        AppConfig.musicVolume = float.Parse(bm[1]);

        FairyGUI.Timers.inst.Add(1, -1, (cb) =>
        {
            mCurTimeNum += 1;
            UpdateTime();
        });
    }

    protected override void OnDispose()
    {
        base.OnDispose();
        SaveSoundPrefsKey();
        ReleaseAll();
    }

    public void SaveSoundPrefsKey()
    {
        var bgm_music_volume = $"{AppConfig.bgmVolume};{AppConfig.musicVolume}";
        PlayerPrefs.SetString(_prefsKey, bgm_music_volume);
    }

    private AudioSource GetOrCreateSound()
    {
        AudioSource tAudio;
        int poolCount = _audioPools.Count;
        if (poolCount > 0)
        {
            tAudio = _audioPools.Dequeue(); //取出队列
        } else
        {
            var sound = new GameObject("sound");
            sound.transform.SetParent(_soundRootTr);
            tAudio = sound.AddComponent<AudioSource>();
        }

        tAudio.volume = AppConfig.musicVolume;
        tAudio.mute = false; //非静音
        tAudio.loop = false;

        return tAudio;
    }

    private void ReleaseAll()
    {
        if (_bgmAssHandle != null)
        {
            _bgmAssHandle.Release();
        }

        foreach (var item in mLoadAssetHandes)
        {
            item.Value.Release();
        }

        mLoadAssetHandes.Clear();
    }

    public void PlayBGM(string name, bool isLoop = true)
    {
        if (_audioBGM != null)
        {
            _audioBGM.volume = AppConfig.bgmVolume;
            _audioBGM.loop = isLoop;
            _audioBGM.mute = false; //非静音

            if (_audioBGM.clip != null && _bgmAssHandle != null)
            {
                _bgmAssHandle.Release();
            } //bgm可以切换的呀

            LoadSound(name, delegate(AssetHandle ah)
            {
                var clip = ah.AssetObject as AudioClip;
                _audioBGM.clip = clip;
                _bgmAssHandle = ah;
                _audioBGM.Play(); //load成功才能播放哦
            });
        }
    }

    public void PlayBGM_Id(string id, bool isLoop = true)
    {
        var cfg = ConfigMgr.Instance.LoadConfigOne<SoundConfig>(id);
        if (cfg != null)
        {
            PlayBGM(cfg.yooPath, isLoop);
        }
    }

    public void StopBGM()
    {
        if (_audioBGM != null)
        {
            _audioBGM.Stop();
        }
    }

    public void PlayMusic(string name)
    {
        var music = GetOrCreateSound();
        if (music != null)
        {
            LoadSound(name, delegate(AssetHandle ah)
            {
                var clip = ah.AssetObject as AudioClip;
                // Debug.LogError($"音效时长:{clip.length}");
                music.clip = clip;
                music.Play(); //load成功才能播放哦

                CheckTimeDicUpdate(music, clip.length, ah);
            });
        }
    }

    public void PlayMusic_Id(string id)
    {
        var cfg = ConfigMgr.Instance.LoadConfigOne<SoundConfig>(id);
        if (cfg != null)
        {
            PlayMusic(cfg.yooPath);
        }
    }

    private void CheckTimeDicUpdate(AudioSource tAudio, float timeClip, AssetHandle ah)
    {
        var rangeTime = mCurTimeNum + timeClip + Random.Range(0.31f, 0.99f); //同一帧 可能被n多次调用 给个随机数
        mLoadAudioPool.Add(rangeTime, tAudio);
        mLoadAssetHandes.Add(rangeTime, ah);
    }

    /// <summary> 每秒 监听一下  看播放完的入队列或释放   1.把gameObject的组件加入池中   2.把AssetHandle释放 </summary>
    private void UpdateTime()
    {
        for (int i = 0; i < mLoadAudioPool.Count; i++)
        {
            var item = mLoadAudioPool.ElementAt(i);
            if (item.Key < mCurTimeNum)
            {
                item.Value.clip = null;
                this._audioPools.Enqueue(item.Value); //加入队列
                mLoadAudioPool.Remove(item.Key);
            }
        }

        for (int i = 0; i < mLoadAssetHandes.Count; i++)
        {
            var item = mLoadAssetHandes.ElementAt(i);
            if (item.Key < mCurTimeNum)
            {
                item.Value.Release(); //释放 AssetHandle       用时间来监听
                mLoadAssetHandes.Remove(item.Key);
            }
        }
    }

    /// <summary> bgm 声音大小 设置 </summary>
    public void SetBGMVolume(float volume)
    {
        if (_audioBGM != null)
        {
            _audioBGM.volume = volume;
            AppConfig.bgmVolume = volume;
        }
    }

    /// <summary> 音效  声音大小 设置 </summary>
    public void SetMusicVolume(float volume)
    {
        foreach (var item in _audioPools)
        {
            if (item.clip != null)
            {
                item.volume = volume;
            }
        }

        AppConfig.musicVolume = volume;
    }

    /// <summary> 停止当前所有的声效 </summary>
    public void StopMusic()
    {
        foreach (var item in _audioPools)
        {
            if (item.clip != null)
            {
                item.Stop();
            }
        }
    }

    void LoadSound(string name, Action<AssetHandle> clipAH)
    {
        var package = YooAssets.GetPackage("DefaultPackage");
        var handle = package.LoadAssetAsync<AudioClip>(name);
        handle.Completed += clipAH;
    }
}