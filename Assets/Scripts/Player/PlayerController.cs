using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInputControll inputControl;
    public Vector2 inputDirection;
    private Rigidbody2D rb;
    [Header("基本参数")]
    public float speed;
    public float jumpForce;

    private void Awake() 
    {
        inputControl = new PlayerInputControll();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() 
    {
        inputControl.Enable();
    }

    private void OnDisable() 
    {
        inputControl.Disable();
    }

    private void Update() 
    {
        inputDirection = inputControl.GamePlay.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate() 
    {
        Move();
    }

    public void Move()
    {
        rb.velocity = new Vector2(inputDirection.x * speed, rb.velocity.y);
        

        int faceDir = (int)transform.localScale.x;

        if (inputDirection.x > 0)
            faceDir = 1;
        else if (inputDirection.x < 0)
            faceDir = -1;

        transform.localScale = new Vector3(faceDir, 1, 1);
    }
}
