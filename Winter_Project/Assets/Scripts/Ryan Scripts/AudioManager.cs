using UnityEngine.Audio;
using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance = null;

    [Header("Atmospheric Music Shift")]
    private float atmosphereTimer;
    [SerializeField] private float atmosphereTimerMinDelay;
    [SerializeField] private float atmosphereTimerMaxDelay;
    [SerializeField] private float atmosphereMusicMinDuration;
    [SerializeField] private float atmosphereMusicMaxDuration;
    private bool atmosphereActive = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.AudioMixerGroup;
        }
    }

    private void Start()
    {
        StartCoroutine(Play("Winter's Bite Grand Piano"));
        atmosphereTimer = UnityEngine.Random.Range(atmosphereMusicMinDuration, atmosphereMusicMaxDuration);
    }

    private void FixedUpdate()
    {
        atmosphereTimer = atmosphereTimer - Time.deltaTime;
        if(atmosphereTimer <= 0)
        {
            if(atmosphereActive)
            {
                StartCoroutine(Stop("Winter's Bite Atmosphere Pad"));
                atmosphereActive = false;
                atmosphereTimer = UnityEngine.Random.Range(atmosphereTimerMinDelay, atmosphereTimerMaxDelay);
            }
            else
            {
                StartCoroutine(Play("Winter's Bite Atmosphere Pad"));
                atmosphereActive = true;
                atmosphereTimer = UnityEngine.Random.Range(atmosphereMusicMinDuration, atmosphereMusicMaxDuration);
            }
        }
    }

    public IEnumerator Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        float fadeTime = s.FadeTime;

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            yield return null;
        }
        if(s.source.isPlaying != true)
        {
            s.source.Play();
            if (s.FadeIn == true) { StartCoroutine(FadeMixerGroup.StartFade(s.source.outputAudioMixerGroup.audioMixer, s.source.outputAudioMixerGroup.name, fadeTime, s.volume)); }
        }
    }

    public IEnumerator Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            yield return null;
        }
        if (s.source.isPlaying == true)
        {
            yield return StartCoroutine(FadeMixerGroup.StartFade(s.source.outputAudioMixerGroup.audioMixer, s.source.outputAudioMixerGroup.name, 0.1f, 0));
            s.source.Stop();
        }
    }
}
