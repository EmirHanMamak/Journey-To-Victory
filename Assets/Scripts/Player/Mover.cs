using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    private void FixedUpdate() {
        transform.Translate(Vector3.forward * moveSpeed * Time.fixedDeltaTime);
    }
}
