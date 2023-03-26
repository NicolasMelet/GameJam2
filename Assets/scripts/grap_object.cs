using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grap_object : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform grabPoint;
    public Transform rayPoint;
    public float rayDistance;
    public bool is_holding = false;
    public GameObject pantin;
    private GameObject grabbedObject;
    private int layerIndex;
    
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Object");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);
        
        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            if (Input.GetKeyDown("s") && grabbedObject == null)
            {
                is_holding = true;
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
            }

            else if (Input.GetKeyDown("s"))
            {
                is_holding = false;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
            }
        }
    }
}
