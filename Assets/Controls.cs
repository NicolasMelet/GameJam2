using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed = 1f;
    public float jumpForce = 5000f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, -3);
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed;

        rigid.velocity = new Vector2(horizontal, rigid.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigid.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }
}
