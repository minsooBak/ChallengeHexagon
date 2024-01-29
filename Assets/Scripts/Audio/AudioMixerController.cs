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
        _masterVolumeSlider.onValueChanged.AddListener();
        _bgmVolumeSlider.onValueChanged.AddListener();
        _sfxVolumeSlider.onValueChanged.AddListener();
    }

    private void SetMasterVolume(float value)
    {
        _audioMixer.SetFloat();

    }
}
