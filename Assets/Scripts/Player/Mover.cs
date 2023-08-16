using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] float leftRightSpeed = 70f;
    NavMeshAgent navMeshAgent;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        if (!GameConditions.gameStarted) return;
        if (GameConditions.isPlayerCrushed) return;
        navMeshAgent.transform.Translate(Vector3.forward * moveSpeed * Time.fixedDeltaTime, Space.World);
#if UNITY_ANDROID
#endif
#if UNITY_EDITOR_WIN
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //   if (this.gameObject.transform.position.x < LevelBoundary.leftSide) return;
            navMeshAgent.transform.Translate(Vector3.left * leftRightSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //if (this.gameObject.transform.position.x > LevelBoundary.rightSide) return;
            navMeshAgent.transform.Translate(-Vector3.left * leftRightSpeed * Time.fixedDeltaTime);
        }
#endif
    }
    public void Move(bool isRight)
    {
        if (GameConditions.isOnBoundery) return;
        if (isRight)
        {
            //if (this.gameObject.transform.position.x > LevelBoundary.rightSide) return;
            navMeshAgent.transform.Translate(Vector3.right * leftRightSpeed * Time.fixedDeltaTime);           // transform.position = Vector3.MoveTowards(currentPos, targetPos, leftRightSpeed * Time.fixedDeltaTime);
            // transform.position.Set(4f, transform.position.y, transform.position.z);
            Debug.LogError("girdi");
            //transform.Translate(Vector3.right * leftRightSpeed * Time.fixedDeltaTime);
        }
        else
        {
            //if (this.gameObject.transform.position.x < LevelBoundary.leftSide) return;
            //transform.position.Set(-4f, transform.position.y, transform.position.z);
            navMeshAgent.transform.Translate(Vector3.left * leftRightSpeed * Time.fixedDeltaTime);
        }
    }
    /*private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Wall")
        {
            Debug.Log("Trigger CAlisti");
        }
    }*/
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Debug.Log("Carpoti");
            GameConditions.isOnBoundery = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Debug.Log("carpma bitti");

            GameConditions.isOnBoundery = false;
        }
    }
}
