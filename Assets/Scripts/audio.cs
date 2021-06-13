using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class audio : MonoBehaviour
{

    public AudioClip dragHit;
    public AudioClip dragDrop;
    public AudioClip dragMiss;
    public AudioClip drive;
    public AudioClip menu;
    public AudioClip level;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex > 2)
        {
            //TODO: Play level music
        }
        else
        {
            //TODO Play Menu Music
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
