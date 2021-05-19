using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerConverter : MonoBehaviour
{
    static TimerConverter()
    {
        
    }
    
    public static int TimeStringToMilliSeconds(string time)
    {
        char[] separators = new char[] { ':', '.' };

        string[] subs = time.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        int minutes = Int32.Parse(subs[0]);
        int seconds = Int32.Parse(subs[1]);
        int millis = Int32.Parse(subs[2]);

        return (minutes*60000) + (seconds*1000) + (millis*10);
    }

    public static string MilliSecondsToTimeString(int millis)
    {
        TimeSpan time = TimeSpan.FromMilliseconds(millis);

        return time.ToString(@"mm\:ss\:ff");
    }
}
