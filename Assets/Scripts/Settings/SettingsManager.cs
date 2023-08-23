
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public enum ControlType
    {
        CT_SWIPE = 0,
        CT_ACCELERATION = 1
    };
    public GameObject swipeSetting, accelerationSetting;
    public GameObject gameOverMenu;
    int inputMode = -1;
    private void Awake()
    {
        inputMode = PlayerPrefs.GetInt("inputMode");
        if (inputMode == 0)
        {
            swipeSetting.SetActive(true);
            accelerationSetting.SetActive(false);
        }
        else if (inputMode == 1)
        {
            swipeSetting.SetActive(false);
            accelerationSetting.SetActive(true);
        }
    }
    private void Update() {
        if(!GameConditions.isPlayerCrushed) return;

    }
}
