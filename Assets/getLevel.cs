using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class getLevel : MonoBehaviour
{

    TextMeshProUGUI me;
    // Start is called before the first frame update
    void Start()
    {
        me = gameObject.GetComponent<TextMeshProUGUI>();
        me.text = (PlayerPrefs.GetInt("index")-1).ToString();
    }

    public void back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("index"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
