using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCanvasManager : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel;
    [SerializeField] Animator animator;
    [SerializeField] Slider soundSlider;
    [SerializeField] TextMeshProUGUI volumeAmount;
    private void Start()
    {
        animator.SetTrigger("isOnMenu");
        soundSlider.GetComponent<Slider>();
        LoadSound();

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
        PlayerPrefs.Save();
    }
    public void SetSound()
    {
        AudioListener.volume = soundSlider.value / 100f;
        volumeAmount.text = ((int)soundSlider.value).ToString();
        SaveSound();
    }
    public void SaveSound()
    {
        PlayerPrefs.SetInt(TagList.settingsSoundVolume, ((int)AudioListener.volume));
    }
    public void LoadSound()
    {
        AudioListener.volume = PlayerPrefs.GetInt(TagList.settingsSoundVolume);
        soundSlider.value = PlayerPrefs.GetInt(TagList.settingsSoundVolume);
        float textValue = PlayerPrefs.GetInt(TagList.settingsSoundVolume);
        volumeAmount.text = ((int)textValue).ToString();
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