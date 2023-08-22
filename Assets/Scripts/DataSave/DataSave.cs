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
        totalGunCountForCheck = PlayerPrefs.GetInt(TagList.gunPickUpTag);
        totalFoodCountForCheck = PlayerPrefs.GetInt(TagList.foodPickUpTag);
        totalMedicCountForCheck = PlayerPrefs.GetInt(TagList.medicPickUpTag);
        bestScoreForCheck = PlayerPrefs.GetInt(TagList.bestScoreTag);
        if (GameConditions.isPlayerCrushed && canSave)
        {
            AddToData(TagList.coinPickUpTag, totalCoinCount);
            AddToData(TagList.gunPickUpTag, totalGunCount);
            AddToData(TagList.foodPickUpTag, totalFoodCount);
            AddToData(TagList.medicPickUpTag, totalMedicCount);
            BestScoreSave();
            PlayerPrefs.Save();
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
        /*if (!PlayerPrefs.HasKey(TagList.coinPickUpTag))
        {
            PlayerPrefs.SetInt(TagList.coinPickUpTag, 0);
        }
        if (!PlayerPrefs.HasKey(TagList.gunPickUpTag))
        {
            PlayerPrefs.SetInt(TagList.gunPickUpTag, 0);
        }
        if (!PlayerPrefs.HasKey(TagList.foodPickUpTag))
        {
            PlayerPrefs.SetInt(TagList.foodPickUpTag, 0);
        }
        if (!PlayerPrefs.HasKey(TagList.medicPickUpTag))
        {
            PlayerPrefs.SetInt(TagList.medicPickUpTag, 0);
        }
        if (!PlayerPrefs.HasKey(TagList.bestScoreTag))
        {
            PlayerPrefs.SetInt(TagList.bestScoreTag, 0);
        }*/
    }
    public void AddToData(string dataName, int score)
    {
        PlayerPrefs.SetInt(dataName, score + PlayerPrefs.GetInt(dataName));
    }
    public void BestScoreSave()
    {
        if (CollectableControl.scoreCount > bestScore)
        {
            bestScore = CollectableControl.scoreCount;
            PlayerPrefs.SetInt(TagList.bestScoreTag, bestScore);
        }
    }
    public void LoadDataInt(TagList tagName)
    {
        PlayerPrefs.GetInt(tagName.ToString());
    }
}
