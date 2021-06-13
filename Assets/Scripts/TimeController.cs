using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;

    public TextMeshProUGUI timeText,victoryText;

    private bool timeGoing;

    private TimeSpan timePlaying;
    private float elapsedTime;



    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = "00:00.00";
        timeGoing = false;

        StartTime();
    }

    public void StartTime()
    {
        timeGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTime());
    }

    public void EndTime()
    {
        timeGoing = false;
        victoryText.text = "Click to continue";
    }

    IEnumerator UpdateTime()
    {
        while (timeGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            timeText.text = timePlaying.ToString("mm':'ss'.'f");
            yield return null;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
