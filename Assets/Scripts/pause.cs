using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Input" + Input.GetKeyDown(KeyCode.Escape));
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.SetInt("index", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings-1);
        }
    }
}
