using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{
    private bool win;
    // Start is called before the first frame update
    void Start()
    {
        win = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.transform.gameObject.layer == 0)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            TimeController.instance.EndTime();
            Dragging drag = other.GetComponent<Dragging>();
            if (drag != null)
            {
                Destroy(drag);
            }
            win = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetMouseButtonDown(0) && win)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
