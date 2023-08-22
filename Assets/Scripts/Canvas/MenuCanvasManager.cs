using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCanvasManager : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel, infoPanel;
    [SerializeField] Animator animator;
    [SerializeField] Slider soundSlider;
    [SerializeField] TextMeshProUGUI volumeAmount;
    [SerializeField] TextMeshProUGUI totalScore, totalCoin, totalgun, totalfood, totalmedic;
    [SerializeField] Button swipeButton, accelerationButton;
    private void Awake()
    {
        if (PlayerPrefs.GetInt(TagList.gameFirstOpen) == 0)
        {
            //First Start Game 
            InfoPanelOpen(infoPanel);
            PlayerPrefs.SetInt(TagList.settingsSoundVolume, 50);
            soundSlider.value = PlayerPrefs.GetInt(TagList.settingsSoundVolume);
        }
        LoadTotalCollectable();
        LoadSound();
        SetSound();
        animator.SetTrigger("isOnMenu");
    }
    private void Start()
    {

        soundSlider.GetComponent<Slider>();

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
    public void InfoCloseButton(GameObject infoPanel)
    {
        infoPanel.SetActive(false);
        PlayerPrefs.SetInt(TagList.gameFirstOpen, 1);
    }
    public void InfoPanelOpen(GameObject infoPanel)
    {
        infoPanel.SetActive(true);
        PlayerPrefs.SetInt(TagList.gameFirstOpen, 1);
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
    public void SettingsRestartGameButton(GameObject restartButtonMenu)
    {
        restartButtonMenu.SetActive(true);
    }
    public void SettingsRestartGameNoButon(GameObject restartButtonMenu)
    {
        restartButtonMenu.SetActive(false);
    }
    public void SettingsRestartGameYesButon(GameObject restartButtonMenu)
    {
        PlayerPrefs.DeleteKey(TagList.coinPickUpTag);
        settingsPanel.SetActive(false);
        PlayerPrefs.DeleteKey(TagList.foodPickUpTag);
        PlayerPrefs.DeleteKey(TagList.gunPickUpTag);
        PlayerPrefs.DeleteKey(TagList.medicPickUpTag);
        PlayerPrefs.DeleteKey(TagList.bestScoreTag);
        PlayerPrefs.SetInt(TagList.gameFirstOpen, 0);
        PlayerPrefs.SetInt(TagList.settingsSoundVolume, 50);

        Awake();
        restartButtonMenu.SetActive(false);

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
    void LoadTotalCollectable()
    {
        totalScore.text = PlayerPrefs.GetInt(TagList.bestScoreTag).ToString();
        totalCoin.text = PlayerPrefs.GetInt(TagList.coinPickUpTag).ToString();
        totalgun.text = PlayerPrefs.GetInt(TagList.gunPickUpTag).ToString();
        totalfood.text = PlayerPrefs.GetInt(TagList.foodPickUpTag).ToString();
        totalmedic.text = PlayerPrefs.GetInt(TagList.medicPickUpTag).ToString();
    }
}