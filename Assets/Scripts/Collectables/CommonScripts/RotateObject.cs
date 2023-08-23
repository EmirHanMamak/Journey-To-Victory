using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0f, rotateSpeed, 0f, Space.Self);
    }
}
