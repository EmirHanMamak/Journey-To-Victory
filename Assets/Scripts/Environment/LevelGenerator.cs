using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class LevelGenerator : MonoBehaviour
{
    // For 3 diffrent env
    public GameObject [] levels;
    public int zPos = 200;
    public int secRandNum = -1;
    public bool createSection = false;
    [SerializeField] int levelindex = 0;
    [SerializeField] int secondOfCreate = 15;


    private void Update() {
        if(createSection == false)
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
