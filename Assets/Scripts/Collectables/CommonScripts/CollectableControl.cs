using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour
{
    public TextMeshProUGUI coinCountText;
    public TextMeshProUGUI distanceCountText;
    public static int coinCount = 0;
    public static int distanceCount = 0;
    public bool addingDistance = false;
    Mover mover;


    void Update()
    {
        coinCountText.text = coinCount.ToString();
        distanceCountText.text = distanceCount.ToString();
        if(!GameConditions.gameStarted) return;
        if (addingDistance == false)
        {
            addingDistance = true;
            StartCoroutine(AddingDistance());
        }
        if (GameConditions.gameEnded == false) return;
        coinCount = 0;
        distanceCount = 0;
    }
    IEnumerator AddingDistance()
    {
        distanceCount++;
        yield return new WaitForSeconds(0.25f);
        addingDistance = false;
    }
}
