using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider music;
    public Slider SFX;
    public Slider sens;
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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        music.value = PlayerPrefs.GetFloat("Music");
        SFX.value = PlayerPrefs.GetFloat("SFX");
        sens.value = PlayerPrefs.GetFloat("sens");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
