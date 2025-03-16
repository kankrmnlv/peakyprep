using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class InputReader : MonoBehaviour
{
    public event Action OnRestartRequest;
    public event Action OnShootInput;

    private PlayerInput playerInput;

    public Vector2 mouseLook;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerInput.actions["Restart"].performed += OnRestart;
        playerInput.actions["Fire"].performed += OnFire;
        playerInput.actions["MouseLook"].performed += OnMouseLook;
    }

    private void OnDisable()
    {
        playerInput.actions["Restart"].performed -= OnRestart;
        playerInput.actions["MouseLook"].performed -= OnMouseLook;
        playerInput.actions["Fire"].performed -= OnFire;
    }
    void OnRestart(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnRestartRequest?.Invoke();
        }
    }

    void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnShootInput?.Invoke();
        }
    }

    void OnMouseLook(InputAction.CallbackContext context)
    {
        mouseLook = context.ReadValue<Vector2>();
    }
}
