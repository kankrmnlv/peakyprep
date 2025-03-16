using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    float xRotation;
    float yRotation;

    InputReader inputReader;

    [SerializeField] LayerMask targetMask;

    [SerializeField] float rayDistance = 100f;

    private void Awake()
    {
        inputReader = FindFirstObjectByType<InputReader>();
    }

    private void OnEnable()
    {
        inputReader.OnShootInput += OnShoot;
    }
    private void OnDisable()
    {
        inputReader.OnShootInput -= OnShoot;
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
    void OnShoot()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, rayDistance, targetMask))
        {
            hit.collider.GetComponent<EnemyHealth>().OnEnemyTakeDamage?.Invoke(1);
        }
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
