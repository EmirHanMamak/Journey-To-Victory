
using UnityEngine;

public class PlayerCrush : MonoBehaviour
{
    Player player;
    public AudioSource crushSound;
    //public GameObject camera;
    private void OnTriggerEnter(Collider other)
    {
        //crushSound.Play();
        GameConditions.isPlayerCrushed = true;
        DataSave.canSave = true;
        GameConditions.gameEnded = true;
        GameConditions.gameStarted = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        Debug.Log("Suan Triggerlandi");
    }
}
