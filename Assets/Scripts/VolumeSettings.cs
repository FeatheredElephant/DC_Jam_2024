using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    
    public void SetMusicVol()
    {
        float vol = musicSlider.value;
        myMixer.SetFloat("music", vol);
    }
}
