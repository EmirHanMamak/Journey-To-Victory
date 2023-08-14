using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConditions : MonoBehaviour
{
    public static bool gameStarted = false;
    private void Start() {
        
    }
    IEnumerator GameStart()
    {
        yield return 0;
    }
}
