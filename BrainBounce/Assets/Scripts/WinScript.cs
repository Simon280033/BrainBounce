using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    [SerializeField] 
    private GameObject levelWinUI;
    [SerializeField] 
    private Text timerText;

    [SerializeField] 
    private TextMeshProUGUI yourTimeText;
    [SerializeField] 
    private TextMeshProUGUI bestTimeText;
    
    [SerializeField] 
    private TextMeshProUGUI newRecordText;

    delegate void WinDelegate();
    private WinDelegate win;

    private void Start()
    {
        // We add methods to our delegates
        // Win delegate
        win += SetConditions;
        win += SaveTime;
        win += SetLabels;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && win != null)
        {
            FindObjectOfType<AudioManager>().Play("LevelWin");
            win();
        }
    }

    // These are the conditions necessary for the pause menu to work properly
    private void SetConditions()
    {
        levelWinUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void SetLabels()
    {
        yourTimeText.text = timerText.text;
        
        bestTimeText.text = TimerConverter.MilliSecondsToTimeString(PlayerPrefs.GetInt(SceneManager.GetActiveScene().name));
    }

    private void SaveTime()
    {
        string time = timerText.text;
            
        int thisScore = TimerConverter.TimeStringToMilliSeconds(time);
        
        if (!PlayerPrefs.HasKey(SceneManager.GetActiveScene().name))
        {
            // We set the highscore in seconds in playerprefs with scene name as name
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, thisScore);
            newRecordText.gameObject.SetActive(true);
            newRecordText.text = "New level unlocked!";
        }
        else
        {
            int highScore = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name);
            if (highScore > thisScore)
            {
                // We set the highscore in seconds in playerprefs with scene name as name
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, thisScore);
                newRecordText.gameObject.SetActive(true);
                newRecordText.text = "New record!";
                bestTimeText.color = Color.yellow;
            }
            else
            {
                newRecordText.gameObject.SetActive(false);
            }
        }
        
    }
}
