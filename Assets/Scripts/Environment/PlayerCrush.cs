using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrush : MonoBehaviour
{
    Player player;
    private void OnTriggerEnter(Collider other) {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        GameConditions.isPlayerCrushed = true;
        GameConditions.gameEnded = true;
        GameConditions.gameStarted = false;

    }
}
