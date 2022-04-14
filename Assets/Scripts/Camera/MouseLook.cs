using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{

    private PlayerInput controls;

    private float mouseSensitivity = 100f;

    private Transform playerBody;
    [SerializeField]
    private Transform playerArm;

    private Vector2 mouseLook;

    private float xRotation = 0f;
    private float yRotation = 0f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        controls = new PlayerInput();

        playerBody = transform.parent;
    }

    void Update()
    {
        Look();
    }

    private void Look()
    {
        mouseLook = controls.Player.Look.ReadValue<Vector2>();

        float mouseX = mouseLook.x * Time.deltaTime * mouseSensitivity;
        float mouseY = mouseLook.y * Time.deltaTime * mouseSensitivity;

        xRotation -= mouseY;
        yRotation -= mouseY;    
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
