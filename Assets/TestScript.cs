using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private PlayerInput controls;

    private void Awake()
    {
        controls = new PlayerInput();
    }

    void Update()
    {
        bool canBlink = controls.Player.Blink.triggered;
        if (canBlink)
        {
            transform.position = transform.position + transform.forward * 5f;
        }
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
