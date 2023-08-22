using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePickUp : MonoBehaviour
{
    private AudioSource collectablePickUpSound;
    private void Start() {
        collectablePickUpSound = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        collectablePickUpSound.volume = 1000f;
        collectablePickUpSound.Play();
         Debug.Log($"Clip: {collectablePickUpSound.clip.name}");
        CollectableIncrease();

        Destroy(this.gameObject);
    }
    void CollectableIncrease()
    {
        /*
         * Gun = 30, Coin = 20, Health = 15, Food = 10 Point
         */
        if (!GameConditions.gameStarted) return;
        if (this.gameObject.tag == TagList.coinPickUpTag)
        {
            CollectableControl.coinCount++;
            CollectableControl.scoreCount += 20;
        }
        else if (this.gameObject.tag == TagList.foodPickUpTag)
        {
            CollectableControl.foodCount++;
            CollectableControl.scoreCount += 10;

        }
        else if (this.gameObject.tag == TagList.medicPickUpTag)
        {
            CollectableControl.medicCount++;
            CollectableControl.scoreCount += 15;

        }
        else if (this.gameObject.tag == TagList.gunPickUpTag)
        {
            CollectableControl.gunCount++;
            CollectableControl.scoreCount += 30;

        }
    }
}
