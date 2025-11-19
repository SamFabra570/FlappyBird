using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerNewInput : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public float jumpHeight = 1.5f;
    public float gravityValue = -9.81f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private MyInputMap mapa;
    
    private Vector2 inputData;

    private bool isJumping;
    
    public Transform camTransform;

    public float charRotationSpeed = 10.0f;

    private void Awake()
    {
        controller = gameObject.AddComponent<CharacterController>();
        
        mapa = new MyInputMap();

        mapa.PlayerWorld.Movement.performed += Movement_performed =>
        {
            inputData = Movement_performed.ReadValue<Vector2>();
        };
        
        mapa.PlayerWorld.Movement.canceled += Movement_canceled =>
        {
            inputData = Movement_canceled.ReadValue<Vector2>();
        };

        mapa.PlayerWorld.Jump.performed += Jumping_performed =>
        {
            isJumping = Jumping_performed.ReadValueAsButton();
        };
        
        mapa.PlayerWorld.Jump.canceled += Jumping_canceled =>
        {
            isJumping = Jumping_canceled.ReadValueAsButton();
        };
        
        // mapa.PlayerWorld.Aim.performed += Aiming_performed =>
        // {
        //     
        // }
    }

    private void OnEnable()
    {
        mapa.Enable();
    }

    private void OnDisable()
    {
        mapa.Disable();
    }
    

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer == true && playerVelocity.y < 0.0f)
        {
            playerVelocity.y = 0f;
        }

        if (camTransform != null)
        {
            Vector3 camForward = camTransform.forward;
            
            camForward.y = 0f;
            camForward.Normalize();
            
            move = camForward * inputData.y + transform.right * inputData.x;
        }
        else
        {
            move = transform.forward * inputData.y + transform.right * inputData.x;
        }

        if (move.magnitude > 1.0f)
        {
            move.Normalize();
        }

        // Read input
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 move = new Vector3(inputData.x, 0.0f, inputData.y);
        move = Vector3.ClampMagnitude(move, 1f);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        // Jump
        if (isJumping && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Combine horizontal and vertical movement
        Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
        controller.Move(finalMove * Time.deltaTime);
    }
}