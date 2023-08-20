using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GameMenuCanvasManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    private void Update() {
        Debug.Log("SUAN UPDATE CALSIYOR");
        if(!GameConditions.isPlayerCrushed) return;
            Debug.Log("Suan Settactive0");
            gameOverMenu.SetActive(true);
    }
}
