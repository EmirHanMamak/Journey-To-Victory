using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour
{
    //INSIDE OF GAME LABELS
    public TextMeshProUGUI gameCoinCountText, gameFoodCount, gameMedicCount, gameGunCount, gameScoreCount;
    //GAMEOVER MENU LABELS
    public TextMeshProUGUI gameOverFoodCount, gameOverMedicCount, gameOverTotalScoreCount;
    public static int coinCount = 0;
    public static int foodCount = 0;
    public static int medicCount = 0;
    public static int gunCount = 0;

    public static int hightScoreCount = 0;
    public static int scoreCount = 0;
    public bool addingScore = false;
    bool saveData = true;
    // bool canSave = false;
    Mover mover;
    private void Awake()
    {
        RestartData();
    }

    void Update()
    {
        UpadateText();
        if (GameConditions.isPlayerCrushed && saveData)
        {
            CollectableSave();
            saveData = false;
        }

        if (!GameConditions.gameStarted) return;
        if (addingScore == false)
        {
            addingScore = true;
            StartCoroutine(AddingScore());
        }
    }
    void UpadateText()
    {
        gameCoinCountText.text = coinCount.ToString();
        gameFoodCount.text = foodCount.ToString();
        gameMedicCount.text = medicCount.ToString();
        gameGunCount.text = gunCount.ToString();
        gameScoreCount.text = scoreCount.ToString();
    }
    public void CollectableSave()
    {
        {
            Debug.Log("SAVE THE DATA");
            DataSave.totalCoinCount += coinCount;
            DataSave.totalFoodCount += foodCount;
            DataSave.totalMedicCount += medicCount;
            DataSave.totalGunCount += gunCount;
        }
    }
    IEnumerator AddingScore()
    {
        scoreCount++;
        yield return new WaitForSeconds(0.25f);
        addingScore = false;
    }
    public static void RestartData()
    {
        coinCount = 0;
        foodCount = 0;
        medicCount = 0;
        gunCount = 0;
        scoreCount = 0;
    }
}
