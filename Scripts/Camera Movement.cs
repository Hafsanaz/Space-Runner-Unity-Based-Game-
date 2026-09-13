using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed = 2f;

    void Update()
    {
        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
    }
}