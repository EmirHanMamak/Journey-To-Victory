using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;
    public Vector3 offSet = new Vector3(0, 5f, -5f);
    void Awake()
    {
        transform.position = lookAt.position + offSet;
    }
    private void LateUpdate()
    {
        Vector3 desiredPosition = lookAt.position + offSet;
        desiredPosition.x = 0;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
    }
}
