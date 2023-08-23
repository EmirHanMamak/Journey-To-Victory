using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDestroyer : MonoBehaviour
{
    string thisObjectName;
    const string destroyObjectName = "Env(Clone)";
    //public Mover mover;
    private void Awake()
    {
        thisObjectName = transform.name;
    }
    private void Start()
    {
        if (thisObjectName == destroyObjectName)
        {
            StartCoroutine(DestroyClone());
        }

    }
    IEnumerator DestroyClone()
    {
        while (true)
        {
            //Debug.LogWarning(Mover.moverCurrentZPos);
            if (Mover.moverCurrentZPos > this.transform.position.z + this.transform.position.z)
            {
                //Debug.LogError(this.gameObject.transform.position);
                Destroy(this.gameObject);
                //Debug.Log("DestroyClone");
            }
            yield return new WaitForSeconds(0.1f);
        }

    }
}
