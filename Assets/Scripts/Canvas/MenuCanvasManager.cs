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
    [SerializeField] TextMeshProUGUI totalScore, totalCoin, totalgun, totalfood, totalmedic;
    [SerializeField] Button swipeButton, accelerationButton;
    private void Start()
    {
        animator.SetTrigger("isOnMenu");
        soundSlider.GetComponent<Slider>();
        totalScore.text = PlayerPrefs.GetInt(TagList.bestScoreTag).ToString();
        LoadSound();

    }
    /*Button Selection Functions*/
    public void SelectButton(Button isGonnaSelect)
    {
        isGonnaSelect.GetComponent<Image>().color = Color.green;
    }
    public void DeSelectButton(Button isGonnaDeSelect)
    {
        //isGonnaDeSelect.GetComponent<Image>().color = Color.red;
        //isGonnaDeSelect.GetComponent<Image>().color = Color.red;
        isGonnaDeSelect.GetComponent<Image>().color = new Vector4(227f, 50f, 0f, 0.8f);


    }
    //Temp Functions


    public void PlayButton()
    {
        StartCoroutine(PlayButtonPress());
    }
    public void SettingsButton()
    {
        settingsPanel.SetActive(true);
        if (PlayerPrefs.HasKey("inputMode") == false)
        {
            PlayerPrefs.SetInt("inputMode", 0);
        }
        if (PlayerPrefs.GetInt("inputMode") == 0)
        {
            SelectButton(swipeButton);
            DeSelectButton(accelerationButton);
        }
        if (PlayerPrefs.GetInt("inputMode") == 1)
        {
            SelectButton(accelerationButton);
            DeSelectButton(swipeButton);
        }
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
        PlayerPrefs.SetInt(TagList.settingsSoundVolume, (int)soundSlider.value);
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