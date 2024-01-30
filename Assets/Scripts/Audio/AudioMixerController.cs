using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerController : MonoBehaviour
{

    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _bgmVolumeSlider;
    [SerializeField] private Slider _sfxVolumeSlider;


    private void Awake()
    {
        _audioMixer = Resources.Load<AudioMixer>("Audio/AudioMixer/AudioMixer");


        _masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        _bgmVolumeSlider.onValueChanged.AddListener(SetBGMVolume);
        _sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void SetMasterVolume(float value)
    {
        _audioMixer.SetFloat("Master", Mathf.Log10(value)*20);
    }

    private void SetBGMVolume(float value)
    {
        _audioMixer.SetFloat("BGM", Mathf.Log10(value) * 20);
    }

    private void SetSFXVolume(float value)
    {
        _audioMixer.SetFloat("SFX", Mathf.Log10(value) * 20);
    }
}
