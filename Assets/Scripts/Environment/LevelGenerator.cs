using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class LevelGenerator : MonoBehaviour
{
    // For 3 diffrent env
    public GameObject[] levels;
    public static int zPos = 200;
    public int secRandNum = -1;
    public bool createSection = false;
    public static int levelindex = 0;
    [SerializeField] int secondOfCreate = 6;
    private void Update()
    {
        if (createSection == false)
        {
            createSection = true;
            StartCoroutine(GenerateSection());
        }
    }
    IEnumerator GenerateSection()
    {
        // For 3 diffrent env
        secRandNum = Random.Range(0, 3);
        levelindex++;
        Instantiate(levels[secRandNum], new Vector3(0, 0, zPos * levelindex), Quaternion.identity);
        yield return new WaitForSeconds(secondOfCreate);
        createSection = false;
    }
}
