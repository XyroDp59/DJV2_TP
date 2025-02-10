using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Slider mainVolume;
    [SerializeField] Slider musicVolume;
    [SerializeField] Slider sfxVolume;
    [SerializeField] AudioMixer audioMixer;

    // Update is called once per frame
    private void Start()
    {
        float v;
        audioMixer.GetFloat("MasterVolume", out v); mainVolume.value = Mathf.Exp(v) * 20f;
        audioMixer.GetFloat("MusicVolume", out v); musicVolume.value = Mathf.Exp(v) * 20f;
        audioMixer.GetFloat("SFXVolume", out v); sfxVolume.value = Mathf.Exp(v) * 20f;

        mainVolume.onValueChanged.AddListener(UpdateMaster);
        musicVolume.onValueChanged.AddListener(UpdateMusic);
        sfxVolume.onValueChanged.AddListener(UpdateSFX);

    }

    void UpdateAudioMixer(float v, string param)
    {
        audioMixer.SetFloat(param, Mathf.Log(v / 20f));
    }
    void UpdateMaster(float v) { UpdateAudioMixer(v, "MasterVolume");  }
    void UpdateSFX(float v) { UpdateAudioMixer(v, "SFXVolume"); }
    void UpdateMusic(float v) { UpdateAudioMixer(v, "MusicVolume"); }

}
