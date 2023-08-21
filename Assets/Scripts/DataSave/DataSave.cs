using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSave : MonoBehaviour
{
    public static int totalCoinCount;
    public static int totalGunCount;
    public static int totalFoodCount;
    public static int totalMedicCount;
    public static int bestScore;
    public int totalCoinCountForCheck;
    public int totalGunCountForCheck;
    public int totalFoodCountForCheck;
    public int totalMedicCountForCheck;
    public int bestScoreForCheck;
    public static bool canSave = true;

    void Start()
    {
        HasKeyExist();
    }
    private void Update()
    {
        totalCoinCountForCheck = PlayerPrefs.GetInt(TagList.coinPickUpTag);
        if (GameConditions.isPlayerCrushed && canSave)
        {
            AddToData(TagList.coinPickUpTag, totalCoinCount);
            AddToData(TagList.gunPickUpTag, totalGunCount);
            AddToData(TagList.foodPickUpTag, totalFoodCount);
            AddToData(TagList.healthPickUpTag, totalMedicCount);
            canSave = false;
        }
        /*totalCoinCountForCheck = totalCoinCount;
        totalGunCountForCheck = totalGunCount;
        totalFoodCountForCheck = totalFoodCount;
        totalMedicCountForCheck = totalMedicCount;
        bestScoreForCheck = bestScore;*/

    }

    void HasKeyExist()
    {
        if (!PlayerPrefs.HasKey("totalCoinCount"))
        {
            PlayerPrefs.SetInt("totalCoinCount", 0);
        }
        if (!PlayerPrefs.HasKey("totalGunCount"))
        {
            PlayerPrefs.SetInt("totalGunCount", 0);
        }
        if (!PlayerPrefs.HasKey("totalFoodCount"))
        {
            PlayerPrefs.SetInt("totalFoodCount", 0);
        }
        if (!PlayerPrefs.HasKey("totalMedicCount"))
        {
            PlayerPrefs.SetInt("totalMedicCount", 0);
        }
        if (!PlayerPrefs.HasKey("bestScore"))
        {
            PlayerPrefs.SetInt("bestScore", 0);
        }
    }
    public void AddToData(string dataName, int score)
    {
        PlayerPrefs.SetInt(dataName, score + PlayerPrefs.GetInt(dataName));
        PlayerPrefs.Save();
    }
}
