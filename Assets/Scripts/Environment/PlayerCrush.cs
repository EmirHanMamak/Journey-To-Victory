using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrush : MonoBehaviour
{
    Player player;
    public AudioSource crushSound;
    public GameObject camera;
    private void OnTriggerEnter(Collider other) {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        camera.GetComponent<Animator>().enabled = true;
        GameConditions.isPlayerCrushed = true;
        crushSound.Play();
        GameConditions.gameEnded = true;
        GameConditions.gameStarted = false;
    }
}
