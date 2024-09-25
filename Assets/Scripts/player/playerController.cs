using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb2D;
    private RaycastHit2D rH2D;

    [Header("Configuracion del Raycast")]
    [SerializeField]
    private float raycastDistance = 25f;
    [SerializeField]
    private LayerMask terrainMask;

    [Header("Velocidad del Personaje")]
    [SerializeField]
    private float jumpForce = 10f;

    [SerializeField]
    private float fallForce = 5f;

    private bool isCrouch = false;
    public bool touchingGround = false;

    private bool jump;
    private bool crouch;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rH2D = Physics2D.Raycast(gameObject.transform.position, Vector2.down, raycastDistance, terrainMask);

        touchingGround = IsGrounded();
        Jumping();
        Crouching();

        anim.SetBool("grounded", touchingGround);
        anim.SetBool("crouching", isCrouch);
    }
    public void Jump(bool val)
    {
        jump = val;
    }

    private void Jumping()
    {
        if (jump && touchingGround)
        {
            rb2D.AddForce(new Vector2(0f, jumpForce * 1 * Time.deltaTime), ForceMode2D.Impulse);
        }
    }

    public void Crouch(bool val)
    {
        crouch = val;
        isCrouch = val;
    }
    private void Crouching()
    {
        if (crouch && !touchingGround)
        {
            rb2D.AddForce(Vector2.down * fallForce);
        }
    }

    private bool IsGrounded() => rH2D.collider != null;
}

