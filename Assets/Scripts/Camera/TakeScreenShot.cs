using UnityEngine;
using System.Collections.Generic;
using System;
 
public class TakeScreenShot : MonoBehaviour
{
    [SerializeField]
    private string path;
    private string fileName;
    [SerializeField]
    [Range(1, 5)]
    private int size = 1;
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            fileName = "screenshot ";
            fileName += System.Guid.NewGuid().ToString() + ".png";
            Debug.Log("Cekti");
            ScreenCapture.CaptureScreenshot(path + fileName, size);
        }
    }
}