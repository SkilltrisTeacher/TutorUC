using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D myRigidBody2D;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float jumpForce = 1000f;
    [SerializeField] private KeyCode jumpButton = KeyCode.Space;
    private SpriteRenderer spriteRenderer;
    private Animator myAnimator;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Collider2D feetCollider;

    private void Awake()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
    }

    private void Flip(float direction)
    {
        if (direction > 0) spriteRenderer.flipX = false;
        if (direction < 0) spriteRenderer.flipX = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        float playerInput = Input.GetAxis("Horizontal");
        Move(playerInput);
        Flip(playerInput);
        SwitchAnimation(playerInput);
        bool isGrounded = feetCollider.IsTouchingLayers(groundLayer);
        if (Input.GetKeyDown(jumpButton)&&isGrounded) Jump();
    }

    private void Jump()
    {
        Vector2 jumpVector = new Vector2(0f, jumpForce);
        myRigidBody2D.AddForce(jumpVector);
    }

    private void Move(float direction)
    {
        Vector2 velocity = myRigidBody2D.velocity;
        myRigidBody2D.velocity = new Vector2(speed * direction, velocity.y);
    }

    private void SwitchAnimation(float playerInput)
    {
        myAnimator.SetBool("Run", playerInput != 0);
    }
}
