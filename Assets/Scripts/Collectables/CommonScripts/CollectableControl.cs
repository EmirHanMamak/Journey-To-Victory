using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour
{
    public TextMeshProUGUI coinCountText;
    public static int coinCount = 0;

    void Update()
    {
        coinCountText.text = coinCount.ToString();
        if(GameConditions.gameEnded == false) return;
        coinCount = 0;
    }
}
