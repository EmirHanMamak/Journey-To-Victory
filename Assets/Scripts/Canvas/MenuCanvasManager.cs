using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCanvasManager : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel;
    //Temp Functions
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void SettingsButton()
    {
        settingsPanel.SetActive(true);
    }
        public void SettingsReturnButton()
    {
        settingsPanel.SetActive(false);
    }
}