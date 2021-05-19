using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsMenu : MonoBehaviour
{
    [SerializeField] 
    private Button level1Button;
    [SerializeField] 
    private Button level2Button;
    [SerializeField] 
    private Button level3Button;
    [SerializeField] 
    private Button level4Button;
    [SerializeField] 
    private Button level5Button;
    [SerializeField] 
    private Button level6Button;

    private Button[] levelButtons;
    
    public void Awake()
    {
        RefreshButtons();
    }

    private void RefreshButtons()
    {
        if (levelButtons == null)
        {
            levelButtons = new Button[] { level1Button, level2Button, level3Button, level4Button, level5Button, level6Button };
        }
        SetButtonInteractivity();
    }
    
    public void UnlockAllLevels()
    {
        // We check if there is a time for each level. If there isn't we set it to 15 minutes
        for (int i = 1; i < levelButtons.Length + 1; i++)
        {
            if (!PlayerPrefs.HasKey("level" + (i))) // If a time has not been saved in playerprefs
            {
                PlayerPrefs.SetInt("level" + (i), 900000); // 15 mins in millisecs
            }
        }
        
        // We reset the interactivity
        SetButtonInteractivity();
    }

    private void SetButtonInteractivity()
    {
        // Level 1 is always unlocked
        levelButtons[0].interactable = true;
        setButtonTime(levelButtons[0], 0);
        
        // We check which levels are unlocked
        for (int i = 1; i < levelButtons.Length; i++)
        {
            if (PlayerPrefs.HasKey("level" + (i))) // If a time has been saved in playerprefs
            {
                levelButtons[i].interactable = true;
                setButtonTime(levelButtons[i], i);
            }
            else
            {
                TextMeshProUGUI timeText = levelButtons[i].transform.Find("TimeText").GetComponent<TextMeshProUGUI>();
                timeText.text = "00:00:00";
                levelButtons[i].interactable = false;
            }
        }
    }

    private void setButtonTime(Button button, int i)
    {
        TextMeshProUGUI timeText = button.transform.Find("TimeText").GetComponent<TextMeshProUGUI>();
        
        TimeSpan time = TimeSpan.FromMilliseconds(PlayerPrefs.GetInt("level" + (i+1)));
        
        timeText.text = time.ToString(@"mm\:ss\:ff");
    }
    public void PlayLevel1()
    {
        SceneManager.LoadScene(1);
    }
    
    public void PlayLevel2()
    {
        SceneManager.LoadScene(2);
    }
    
    public void PlayLevel3()
    {
        SceneManager.LoadScene(3);
    }
    
    public void PlayLevel4()
    {
        SceneManager.LoadScene(4);
    }
    
    public void PlayLevel5()
    {
        SceneManager.LoadScene(5);
    }
    
    public void PlayLevel6()
    {
        SceneManager.LoadScene(6);
    }

    public void ResetTimes()
    {
        PlayerPrefs.DeleteAll();
        
        RefreshButtons();
    }
}
