using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    float xRotation;
    float yRotation;

    InputReader inputReader;
    private void Awake()
    {
        inputReader = GetComponent<InputReader>();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void LateUpdate()
    {
        OnMouseLook();
    }

    void OnMouseLook()
    {
        yRotation += inputReader.mouseLook.x * Time.deltaTime * sensX;
        xRotation -= inputReader.mouseLook.y * Time.deltaTime * sensY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation = Mathf.Clamp(yRotation, -90f, 20f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
