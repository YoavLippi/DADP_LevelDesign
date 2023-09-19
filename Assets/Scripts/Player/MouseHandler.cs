using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    // horizontal rotation speed
    [SerializeField] private float horizontalSpeed = 1f;
    // vertical rotation speed
    [SerializeField] private float verticalSpeed = 1f;
    [SerializeField] private CapsuleCollider body;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    private Camera cam;
    
 
    void Start()
    {
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }
 
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;
 
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
 
        cam.transform.eulerAngles = new Vector3(xRotation, yRotation, 0.0f);
        transform.eulerAngles = new Vector3(0.0f, yRotation, 0.0f);
    }
}
