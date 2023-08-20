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
    public static int healthCount = 0;
    public static int gunCount = 0;

    public static int hightScoreCount = 0;
    public static int scoreCount = 0;
    public bool addingScore = false;
    Mover mover;


    void Update()
    {
        UpadateText();
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
        gameMedicCount.text = healthCount.ToString();
        gameGunCount.text = gunCount.ToString();
        gameScoreCount.text = scoreCount.ToString();
    }
    IEnumerator AddingScore()
    {
        scoreCount++;
        yield return new WaitForSeconds(0.25f);
        addingScore = false;
    }
}
