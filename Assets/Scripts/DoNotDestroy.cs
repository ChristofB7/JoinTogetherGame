using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] menu = GameObject.FindGameObjectsWithTag("MenuMusic");
        foreach(GameObject musicP in menu)
        {
            Destroy(musicP.gameObject);
        }


        GameObject[] music = GameObject.FindGameObjectsWithTag("LevelMusic");
        if (music.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
