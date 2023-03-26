using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    Rigidbody2D rigid;
    Rigidbody2D pantin_rigid;
    public float speed = 1f;
    public float jumpForce = 5000f;
    public float horizontal = 0;
    public float rayDistance;
    private int layerIndex;
    public Transform rayPointR;
    public Transform rayPointL;
    public Transform ownR;
    public Transform ownL;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public grap_object player_grab;
    public GameObject pantin;
    private bool is_grab = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        pantin_rigid = pantin.GetComponent<Rigidbody2D>();
        layerIndex = LayerMask.NameToLayer("Ground");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigid.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D hitInfoR = Physics2D.Raycast(rayPointR.position, Vector3.right, rayDistance);
        RaycastHit2D hitInfoL = Physics2D.Raycast(rayPointL.position, Vector3.right, rayDistance * -1);
        RaycastHit2D ownInfoR = Physics2D.Raycast(ownR.position, Vector3.right, rayDistance);
        RaycastHit2D ownInfoL = Physics2D.Raycast(ownL.position, Vector3.right, rayDistance * -1);

        horizontal = Input.GetAxis("Horizontal") * speed;
        if (player_grab.is_holding)
        {
            if (is_grab == false)
            {
                is_grab = true;
            }
            if ((hitInfoR.collider != null && hitInfoR.collider.gameObject.layer == layerIndex && horizontal > 0) ||
                (hitInfoL.collider != null && hitInfoL.collider.gameObject.layer == layerIndex && horizontal < 0) ||
                (ownInfoR.collider != null && ownInfoR.collider.gameObject.layer == layerIndex && horizontal > 0) ||
                (ownInfoL.collider != null && ownInfoL.collider.gameObject.layer == layerIndex && horizontal < 0))
            {
                horizontal = 0;
            }
        }
        else
        {
            if (is_grab)
            {
                pantin_rigid.velocity = new Vector2(0, 0);
            }
            is_grab = false;
        }
    }

    private void LateUpdate()
    {
        if (player_grab.is_holding)
        {
            pantin_rigid.velocity = new Vector2(horizontal, 0);
        }
        rigid.velocity = new Vector2(horizontal, rigid.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }
}
