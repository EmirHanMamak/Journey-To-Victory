using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    int scoreCount = 0;
    int coinCount, foodCount, medicalCount = 0;
    int coinTotalCount, foodTotalCount, medicalTotalCount = 0;

    void Start()
    {
        coinCount = CollectableControl.coinCount;
        //foodCount = CollectableControl.f
    }

    // Update is called once per frame
    void Update()
    {

    }
}
