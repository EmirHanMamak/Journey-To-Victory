using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GameMenuCanvasManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    private void Update() {
        if(!GameConditions.isPlayerCrushed) return;
            gameOverMenu.SetActive(true);
    }
}
