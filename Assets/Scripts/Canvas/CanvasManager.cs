using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject fader, countdown3, countdown2, countdown1, countdowngo;
    private void Start() {
        StartCoroutine(CountSequence());
    }
    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(0.5f);
        countdown3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        countdown2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        countdown1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        countdowngo.SetActive(true);
        GameConditions.gameStarted = true;
    }
}