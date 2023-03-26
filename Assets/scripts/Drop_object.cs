using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_object : MonoBehaviour
{
    Rigidbody2D rigid;
    public Transform objectCheck;
    public LayerMask objectLayer;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.AddComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            rigid.Sleep();
        }
        if (Input.GetKeyDown("d"))
        {
            rigid.WakeUp();
        }
    }

    private bool IsObjected()
    {
        return Physics2D.OverlapCircle(objectCheck.position, 0.5f, objectLayer);
    }
}
