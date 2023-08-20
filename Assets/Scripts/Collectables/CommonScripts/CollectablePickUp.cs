using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePickUp : MonoBehaviour
{
    public AudioSource collectablePickUpSound;
    void OnTriggerEnter(Collider other) {
        collectablePickUpSound.Play();
        CollectableControl.coinCount++;
        Destroy(this.gameObject);
    }
}
