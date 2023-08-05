using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public Text timerMinutes;
    public Text timerSecond;
    public Text timerSecond100;
    private float startTime;
    private float stopTime;
    private float timerTime;
    private bool isRuning = false;
    void Start()
    {
        TimerReset();
        TimerStart();
    }

    // Update is called once per frame
    void Update()
    {
        timerTime = stopTime + (Time.time - startTime);
        int minutesInt = (int)timerTime / 60;
        int secondsInt = (int)timerTime % 60;
        int seconds100Int = (int)(Mathf.Floor((timerTime - (secondsInt + minutesInt * 60)) * 100));
        if (isRuning)
        {
            timerMinutes.text =(minutesInt <10)?"0"+minutesInt: minutesInt.ToString();
            timerSecond.text = (secondsInt < 10) ? "0" + secondsInt : secondsInt.ToString();
            timerSecond100.text = (seconds100Int < 10) ? "0" + seconds100Int : seconds100Int.ToString();

        }
    }
    public void TimerStart()
    {
        if (!isRuning)
        {
            print("Start");
            isRuning = true;
            startTime = Time.time;

        }
    }
    public void TimerStop()
    {

        if (isRuning)
        {
            print("Stop");
            isRuning = false;
            stopTime = timerTime;
        }

    }
    public void TimerReset()
    {
        print("Reset");
        timerMinutes.text = timerSecond.text = timerSecond100.text = "00";
    }
}
