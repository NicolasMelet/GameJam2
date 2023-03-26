using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pantin : MonoBehaviour
{
    Rigidbody2D rigid;
    public grap_object player_grab;
    public GameObject player;
    public Controls move_p;
    public Transform rayPointR;
    public Transform rayPointL;
    public float rayDistance;
    private int layerIndex;
    public bool is_grab = false;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        layerIndex = LayerMask.NameToLayer("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfoR = Physics2D.Raycast(rayPointR.position, transform.right, rayDistance);
        RaycastHit2D hitInfoL = Physics2D.Raycast(rayPointL.position, transform.right, rayDistance * -1);

        if (player_grab.is_holding)
        {
            if (is_grab == false)
            {
                transform.position = new Vector2(player.transform.position.x, transform.position.y);
            }
            is_grab = true;
            if ((hitInfoR.collider != null && hitInfoR.collider.gameObject.layer == layerIndex && move_p.horizontal > 0) || 
                (hitInfoL.collider != null && hitInfoL.collider.gameObject.layer == layerIndex && move_p.horizontal < 0))
            {
                move_p.horizontal = 0;
            }
            else
            {
                rigid.velocity = new Vector2(move_p.horizontal, 0);
            }
        }
        else
        {
            if (is_grab)
            {
                rigid.velocity = new Vector2(0, 0);
            }
            is_grab = false;
        }
    }
}
