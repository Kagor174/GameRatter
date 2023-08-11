using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float moveInput;

    private Rigidbody2D rb;
    private bool facingRight = true;

    private bool isGraunded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGraund;

    private Animator anim;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
            Flip();
        if (facingRight == true && moveInput < 0)
            Flip();

        if (moveInput == 0)
            anim.SetBool("isRunning", false);
        else
            anim.SetBool("isRunning", true);

    }

    private void Update()
    {
        isGraunded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGraund);

        if (isGraunded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("TakeOf");
        }

        if (isGraunded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
