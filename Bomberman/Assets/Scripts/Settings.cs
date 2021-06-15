using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Start()
    {
        GameObject.Find("Toggle").GetComponent<Toggle>().isOn = Screen.fullScreen;
        GameObject.Find("Slider").GetComponent<Slider>().value = GetVolumeLevel() ;
    }
    private float GetVolumeLevel()
    {
        float masterVol;
        audioMixer.GetFloat("masterVol", out masterVol);
        return masterVol;
    }
    public void SetVolumeLevel(float masterVol)
    {
        audioMixer.SetFloat("masterVol", masterVol);
    }

    public void Fullscreen(bool isFullscreen)
    {        
        if(!isFullscreen)
            Screen.SetResolution(1280, 720, false);
        else
            Screen.SetResolution(1920, 1080, true);
    }
}
