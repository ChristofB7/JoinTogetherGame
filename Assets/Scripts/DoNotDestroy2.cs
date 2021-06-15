using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] music = GameObject.FindGameObjectsWithTag("MenuMusic");
        if (music.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        if (PlayerPrefs.GetFloat("sens") == 0)
        {
            PlayerPrefs.SetFloat("sense", 0.5f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
