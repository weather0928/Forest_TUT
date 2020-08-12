using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    [SerializeField] AudioMixerGroup bgmMixerGroup;
    [SerializeField] AudioMixerGroup seMixerGroup;
    [SerializeField] AudioClip bgm;

    AudioSource bgmAudioSource;
    [System.NonSerialized] public static AudioSource seAudioSource;

    private void Awake()
    {

        bgmAudioSource = gameObject.AddComponent<AudioSource>();
        seAudioSource = gameObject.AddComponent<AudioSource>();

        bgmAudioSource.outputAudioMixerGroup = bgmMixerGroup;
        seAudioSource.outputAudioMixerGroup = seMixerGroup;

    }

    private void Start()
    {
        StartBGM(bgm);
        Screen.SetResolution(1600, 900, false, 60);
    }

    private void StartBGM(AudioClip clip)
    {
        bgmAudioSource.loop = true;
        bgmAudioSource.clip = clip;
        bgmAudioSource.Play();
    }
    
}
