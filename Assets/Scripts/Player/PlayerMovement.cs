using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Tooltip("Ground Layers")]
    private LayerMask groundLayer;

    private Transform playerBody;

    private PlayerInput controls;
    private CharacterController controller;

    private Vector3 velocity;
    private float playerHeight;
    private float gravity = -30f;

    [Header("Movement variables")]
    private float moveSpeed;
    private float baseSpeed = 6f;
    private float sprintSpeed = 8f;
    private Vector2 moveDirection;

    [Header("Jump variables")]
    private bool isGrounded;
    private float jumpHeight = 3f;

    [Header("Blink variables")]
    private float blinkDistance = 6f;



    private void Awake()
    {
        controls = new PlayerInput();
        controller = GetComponent<CharacterController>();
        playerBody = transform.Find("PlayerBody").GetComponent<Transform>();

        playerHeight = controller.height;
    }

    private void Update()
    {
        Gravity();
        MovePlayer();
        Jump();
        Sprint();
        Blink();
    }

    private void Gravity()
    {
        isGrounded = Physics.Raycast(playerBody.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void MovePlayer()
    {
        moveDirection = controls.Player.Movement.ReadValue<Vector2>();

        Vector3 movement = (moveDirection.y * transform.forward) + (moveDirection.x * transform.right);
        controller.Move(movement.normalized * moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        controller.stepOffset = isGrounded ? 0.3f : 0f;

        bool canJump = controls.Player.Jump.triggered && isGrounded;
        if (canJump)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void Sprint()
    {
        moveSpeed = controls.Player.Sprint.IsPressed() ? sprintSpeed : baseSpeed;
    }

    private void Blink()
    {
        bool canBlink = controls.Player.Blink.triggered;
        if (canBlink)
        {
            //controller.Move(transform.forward * blinkDistance);
            controller.enabled = false;

            Vector3 dashDirection = (moveDirection.y * transform.forward) + (moveDirection.x * transform.right);
            transform.position = transform.position + dashDirection * blinkDistance;

            controller.enabled = true;
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
