using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider MusicVolumeSlider;
    public Slider EffectVolumeSlider;

    private void Start() {
        MusicVolumeSlider.value = SaveSystem.GetMusicVolume();
        EffectVolumeSlider.value = SaveSystem.GetEffectsVolume();
    }

    private void Update() {
        SaveSystem.SetMusicVolume(MusicVolumeSlider.value);
        SaveSystem.SetEffectsVolume(EffectVolumeSlider.value);
    }
}
