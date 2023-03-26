using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string levelToLoad;
    public string ActuelLevel;
    private int layerIndex;
    
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("CenterObj");
    }
    // Start is called before the first frame update
    
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(ActuelLevel);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layerIndex)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
