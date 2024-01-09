using System;
using UnityEngine;
using System.Collections.Generic;

public class ParticleInstance : MonoBehaviour
{
    private Animator[] mAnimator;
    private Animation[] mAnimation;
    private ParticleSystem[] mParticleSystem;
    private int mParticlesCount;
    private int mParticleDestroyCallbackFrameInterval;
    private int mParticleDestroyCallbackFrame;
    private Action mParticleDestroyCallback;

    //tween particle
    private Vector3 tweenTarget;
    private float tweenDelay, tweenDuration;
    private bool tweenParticle;
    private Dictionary<uint, Vector3> seed2pos;

    public void Awake()
    {
        mParticleSystem = gameObject.GetComponentsInChildren<ParticleSystem>(true);
        mAnimator = gameObject.GetComponentsInChildren<Animator>(true);
        mAnimation = gameObject.GetComponentsInChildren<Animation>(true);

        this.enabled = false;
        this.mParticlesCount = 0;
    }

    public void Update()
    {
        var count = 0;
        var alive = false;
        foreach (var sys in mParticleSystem)
        {
            count += sys.particleCount;
            if (!alive && sys.IsAlive())
                alive = true;
        }
        if (!alive) this.enabled = false;

        if (tweenParticle)
            TweenParticle();

        if (count < mParticlesCount && Time.frameCount - mParticleDestroyCallbackFrame >= mParticleDestroyCallbackFrameInterval)
        {
            mParticleDestroyCallback();
            mParticleDestroyCallbackFrame = Time.frameCount;
        }
        mParticlesCount = count;
    }

    public void SetTweenParticle(float x, float y, float z, float delay, float duration, int frame, Action callback)
    {
        tweenParticle = true;
        tweenTarget = new Vector3(x, y, z);
        tweenDelay = delay;
        tweenDuration = duration;
        mParticleDestroyCallbackFrameInterval = frame;
        mParticleDestroyCallback = callback;
        seed2pos = new Dictionary<uint, Vector3>(15);
        this.enabled = true;
    }

    private void TweenParticle()
    {
        foreach (ParticleSystem system in mParticleSystem)
        {
            var particles = new ParticleSystem.Particle[system.particleCount];
            int count = system.GetParticles(particles);
            for (int i = 0; i < count; i++)
            {
                float t = particles[i].startLifetime - particles[i].remainingLifetime - tweenDelay;
                if (t > 0)
                {
                    if (seed2pos.TryGetValue(particles[i].randomSeed, out Vector3 pos))
                    {
                        particles[i].position = Vector3.Lerp(pos, tweenTarget, t / tweenDuration);
                    }
                    else
                    {
                        seed2pos.Add(particles[i].randomSeed, particles[i].position);
                    }
                }
            }
            system.SetParticles(particles);
        }
    }

    public void SetScale(float scale)
    {
        for (int i = mParticleSystem.Length - 1; i >= 0; i--)
        {
            var main = mParticleSystem[i].main;
            main.startSizeMultiplier = main.startSizeMultiplier * scale;
        }
    }

    public void Play()
    {
        for (int i = 0; i < mAnimator.Length; i++)
        {
            mAnimator[i].Play(0, -1, 0);
        }
        for (int b = 0; b < mAnimation.Length; b++)
        {
            mAnimation[b].Play();
        }
        for (int i = mParticleSystem.Length - 1; i >= 0; i--)
        {
            // mParticleSystem[i].Stop();
            mParticleSystem[i].time = 0;
            mParticleSystem[i].Clear(false);
            mParticleSystem[i].Play(false);
        }
    }

    public float CalcLifeTime()
    {
        var t = 0.0f;
        if (mParticleSystem != null && mParticleSystem.Length > 0)
        {
            for (int i = mParticleSystem.Length - 1; i >= 0; i--)
            {
                ParticleSystem ps = mParticleSystem[i];
                float tmpTotal = 0f;
                tmpTotal += ps.main.startDelayMultiplier;
                tmpTotal += ps.main.startLifetimeMultiplier;

                // duration的意思是发射的持续时间，如果发射率为0 或者是循环特效的话，就不需要把发射持续时间算进去了
                if (!ps.main.loop && (ps.emission.rateOverTimeMultiplier >= 0.01f || ps.emission.burstCount > 0))
                {
                    tmpTotal += ps.main.duration;
                }
                if (tmpTotal > t)
                {
                    t = tmpTotal;
                }
            }
        }
        else if (mAnimator != null && mAnimator.Length > 0)
        {
            AnimatorStateInfo asi = mAnimator[0].GetCurrentAnimatorStateInfo(0);
            t = asi.length;
        }
        else if (mAnimation != null && mAnimation.Length > 0)
        {
            for (int i = 0; i < mAnimation.Length; i++)
            {
                Animation ani = mAnimation[i];
                float aniTime = ani.clip.length;
                if (aniTime > t)
                {
                    t = aniTime;
                }
            }
        }
        return t;
    }

    public void ClearParticles()
    {
        if (this.mParticleSystem == null)
            return;

        for (int i = this.mParticleSystem.Length - 1; i >= 0; i--)
        {
            if (this.mParticleSystem[i] != null)
            {
                this.mParticleSystem[i].Stop();
                this.mParticleSystem[i].Clear();
            }
        }
    }

    public void SetParticleMaxNum(int num)
    {
        foreach (ParticleSystem p in mParticleSystem)
        {
            var m = p.main;
            m.maxParticles = num;
        }
    }

    public void SetStartSize(float size)
    {
        foreach (ParticleSystem p in mParticleSystem)
        {
            var m = p.main;
            m.startSize = size;
        }
    }
}