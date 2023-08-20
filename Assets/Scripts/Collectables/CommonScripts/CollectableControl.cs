using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour
{
    //INSIDE OF GAME LABELS
    public TextMeshProUGUI gameCoinCountText, gameFoodCount, gameMedicCount, gameTotalScoreCount;
    //GAMEOVER MENU LABELS
    public TextMeshProUGUI gameOverFoodCount, gameOverMedicCount, gameOverTotalScoreCount;
    public static int coinCount = 0;
    //public static int foodCount = 0;
    //public static int medicCount = 0;
    public static int totalScoreCount = 0;
    //  public static int scoreCount = 0;
    public bool addingDistance = false;
    Mover mover;


    void Update()
    {
        gameCoinCountText.text = coinCount.ToString();
        gameTotalScoreCount.text = totalScoreCount.ToString();
        if (!GameConditions.gameStarted) return;
        if (addingDistance == false)
        {
            addingDistance = true;
            StartCoroutine(AddingScore());
        }
    }
    IEnumerator AddingScore()
    {
        totalScoreCount++;
        yield return new WaitForSeconds(0.25f);
        addingDistance = false;
    }
}
