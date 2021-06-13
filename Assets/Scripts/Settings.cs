using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider music;
    public Slider SFX;
    public AudioMixer audioMixer;

    public void SetMusic (float volume)
    {
        PlayerPrefs.SetFloat("Music", volume);
        audioMixer.SetFloat("Music", volume);
    }
    public void SetSFX (float volume)
    {
        PlayerPrefs.SetFloat("SFX", volume);
        audioMixer.SetFloat("SFX", volume);
    }
    public void SetSensitivity(float sens)
    {
        PlayerPrefs.SetFloat("sens", sens);
    }

    // Start is called before the first frame update
    void Start()
    {
        music.value = PlayerPrefs.GetFloat("Music");
        SFX.value = PlayerPrefs.GetFloat("SFX");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
