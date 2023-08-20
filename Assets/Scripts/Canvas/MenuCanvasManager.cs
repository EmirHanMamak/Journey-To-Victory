using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCanvasManager : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel;
    [SerializeField] Animator animator;
    SettingsManager settingsManager;
    private void Start() {
        animator.SetTrigger("isOnMenu"); 
    }
    //Temp Functions
    public void PlayButton()
    {
        StartCoroutine(PlayButtonPress());
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
    IEnumerator PlayButtonPress()
    {
        animator.SetTrigger("isOnMenuPlayButton");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
        GameConditions.gameEnded = false;
        GameConditions.gameStarted = false;
        Time.timeScale = 1f;
    }
}