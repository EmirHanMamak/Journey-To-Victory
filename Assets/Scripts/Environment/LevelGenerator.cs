using System.Collections;
using UnityEngine;
public class LevelGenerator : MonoBehaviour
{
    // For 3 diffrent env
    public GameObject[] levels;
    public static int zPos = 200;
    public int secRandNum = -1;
    public bool createSection = false;
    public static int levelindex = 0;
    private void Awake()
    {
        levelindex = 0;
    }
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
        while (true)
        {
            if (PlayerMotor.moverCurrentZPos > (zPos * levelindex) / 2)
            {
                secRandNum = Random.Range(0, 4);
                levelindex++;
                Instantiate(levels[secRandNum], new Vector3(0, 0, zPos * levelindex), Quaternion.identity);
                createSection = false;
            }
            yield return new WaitForSeconds(0.1f);

        }


    }
}
