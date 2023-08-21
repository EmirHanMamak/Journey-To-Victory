using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrush : MonoBehaviour
{
    Player player;
    public AudioSource crushSound;
    public GameObject camera;
    private void OnTriggerEnter(Collider other)
    {
        GameConditions.isPlayerCrushed = true;
        DataSave.canSave = true;
        GameConditions.gameEnded = true;
        GameConditions.gameStarted = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        camera.GetComponent<Animator>().enabled = true;
        Debug.Log("Suan Triggerlandi");
        crushSound.Play();
    }
}
