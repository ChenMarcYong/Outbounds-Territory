using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    
    public  InputAction playerControls;
    public float moveSpeed = 25.0f;
    
    public InputActionReference move;
    public InputActionReference ascend;
    public InputActionReference rotate;

    private Vector2 moveDirection = Vector2.zero;
    private float ascendSpeed = 5.0f;
    private Rigidbody rb;


    public float verticalMove;
    public float horizontalMove;
    public float mouseInputX;
    public float mouseInputY;
    public float rollInput;

    [SerializeField]
    float speedMult = 1.0f;

    [SerializeField]
    float speedMultAngle = 0.5f;

    [SerializeField]
    float speedRollMultAngle = 0.05f;

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;


        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();
        ascendSpeed = ascend.action.ReadValue<float>();
        UnityEngine.Debug.Log(rb.position);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(- moveDirection.x * moveSpeed, ascendSpeed * moveSpeed, - moveDirection.y * moveSpeed) ;
    }

    /*public void OnMove() 
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }*/


    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
