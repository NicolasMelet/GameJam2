using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFlip : MonoBehaviour
{
    public Transform switchObj;
    public Transform customPivot;
    public bool rotateBool;
    private int layerIndex;
    // Start is called before the first frame update
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Perso");
    }

    // Update is called once per frame
    void Update()
    {
        float rayDistance = 1;
        RaycastHit2D hitInfo = Physics2D.Raycast(switchObj.position, Vector3.right, rayDistance);
        
        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
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
}
