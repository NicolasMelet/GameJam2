using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grap_object : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform grabPoint;
    public Transform rayPoint;
    public float rayDistance;
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

        if (hitInfo.collider == null)
        {
            Debug.Log("null");
        }
        else if (hitInfo.collider.gameObject.layer != layerIndex)
        {
            Debug.Log("bad layer");
        }
        
        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            Debug.Log("in if");
            if (Input.GetKeyDown("s") && grabbedObject == null)
            {
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
                Debug.Log("g_key");
            }

            else if (Input.GetKeyDown("s"))
            {
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
                Debug.Log("f_key");
            }
        }
    }
}
