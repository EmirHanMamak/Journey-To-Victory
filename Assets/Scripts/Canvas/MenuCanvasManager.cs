using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCanvasManager : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel;
    SettingsManager settingsManager;
    //Temp Functions
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void SettingsButton()
    {
        settingsPanel.SetActive(true);
    }
    public void SettingsSwipeButton()
    {
        PlayerPrefs.SetInt("inputMode", 0);
    }
    public void SettingsAccelerationButton()
    {
        PlayerPrefs.SetInt("inputMode", 1);
    }
    public void SettingsReturnButton()
    {
        settingsPanel.SetActive(false);
    }
}