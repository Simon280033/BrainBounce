using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] 
    private Text TimerText; 
    private float Timer;

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1f){
  
            Timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(Timer / 60F);
            int seconds = Mathf.FloorToInt(Timer % 60F);
            int milliseconds = Mathf.FloorToInt((Timer * 100F) % 100F);
            TimerText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00") + ":" + milliseconds.ToString("00");
        }
    }
}
