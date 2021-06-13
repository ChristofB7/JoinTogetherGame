using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class audio : MonoBehaviour
{

    public AudioClip Hit;
    public AudioClip LetGo;
    public AudioClip Miss;
    public AudioClip Drive;

    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayHit()
    {
        source.PlayOneShot(Hit);
    }
    public void PlayLetGo()
    {
        source.PlayOneShot(LetGo);
    }
    public void PlayMiss()
    {
        source.PlayOneShot(Miss);
    }
    public void PlayDrive()
    {
        source.clip = Drive;
        source.Play();
    }
    public void Stop()
    {
        source.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
