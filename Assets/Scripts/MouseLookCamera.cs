using UnityEngine;

public class MouseLookCamera : MonoBehaviour
{
    public Transform target;  // The target to follow (the player).
    public float sensitivity = 2.0f;  // Mouse sensitivity for camera rotation.
    public Vector2 rotationLimit = new Vector2(80, 360);  // Vertical and horizontal rotation limits.

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get mouse input for camera rotation.
        rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationY += Input.GetAxis("Mouse X") * sensitivity;

        // Clamp the vertical rotation to the specified limits.
        rotationX = Mathf.Clamp(rotationX, -rotationLimit.x, rotationLimit.x);

        // Rotate the camera based on the input.
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
    }

    void LateUpdate()
    {
        // Follow the target (player) with the camera.
        transform.position = target.position;
    }
}
