using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFlip : MonoBehaviour
{
    public Transform customPivot;
    public bool rotateBool;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q") && rotateBool)
        {
            transform.RotateAround(customPivot.position, Vector3.forward, 90);
            rotateBool = false;
        }
        else if (Input.GetKeyDown("q"))
        {
            transform.RotateAround(customPivot.position, Vector3.forward, -90);
            rotateBool = true;
        }
    }
}
