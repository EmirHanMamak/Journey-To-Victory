using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimations : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(!GameConditions.isPlayerCrushed) return;
        GetComponent<Animator>().enabled = true;
    }
}
