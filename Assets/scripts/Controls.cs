using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed = 1f;
    public float jumpForce = 5000f;
    public float horizontal = 0;
    public Transform groundCheck;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigid.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal") * speed;
    }

    private void LateUpdate()
    {
        print(horizontal);
        rigid.velocity = new Vector2(horizontal, rigid.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }
}
