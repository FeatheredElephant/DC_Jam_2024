using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;


    public void SetMusicVol()
    {
        float vol = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(vol)*20);
    }

    public void SetEffectsVol()
    {
        float SFXvol = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(SFXvol)*20);
    }
}
